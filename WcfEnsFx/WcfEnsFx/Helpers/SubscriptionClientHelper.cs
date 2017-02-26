using System;
using System.Diagnostics;
using System.ServiceModel;
using System.Threading;
using System.Collections.Generic;

namespace WcfEnsFx
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TS">Type of subscription that implements service contract.</typeparam>
    /// <typeparam name="T">Subscription callback(Event) contract.</typeparam>
    public class SubscriptionClientHelper<TS, T>
        where TS : class
        where T : class
    {
        public event SubscriptionStateChangedEventHandler OnSubscriptionStateChanged;

        public string AnyThing
        {
            get { return MethodNames.AnyThing; }
        }

        private readonly string subscriberName;

        public string SubscriberName
        {
            get { return subscriberName; }
        }

        internal SubscriptionState<TS, T> UnconnectedState { get; private set; }
        internal SubscriptionState<TS, T> ConnectedState { get; private set; }
        internal SubscriptionState<TS, T> SubscribedState { get; private set; }
        internal SubscriptionState<TS, T> FaultedState { get; private set; }

        SubscriptionState<TS, T> currentState;
        
        internal SubscriptionState<TS, T> CurrentState
        {
            get { return currentState; }
            set
            {
                currentState = value;

                State = currentState.State;
            }
        }

        private readonly SubscriptionClientProxyWrapper<TS, T> proxyWrapper;

        internal ISubscription ProxyWrapper
        {
            get { return proxyWrapper; }
        }

        private SubscriberState state = SubscriberState.Disconnected;
        public SubscriberState State
        {
            get { return state; }
            private set
            {
                state = value;

                if (OnSubscriptionStateChanged != null)
                    OnSubscriptionStateChanged(state);
            }
        }

        private bool isCommunicationThreadWorking;

        private bool stopWorking = true;

        private bool keepSubscriptionValid;
        public bool KeepSubscriptionValid
        {
            get { return keepSubscriptionValid; }
            set
            {
                keepSubscriptionValid = value;

                if (!value)
                {
                    Unsubscribe(AnyThing);
                }
                else
                {
                    Subscribe(subscriberName, AnyThing);
                }
            }
        }

        Thread commValidatorThread;

        Dictionary<string, object> subscribedEvents;

        public SubscriptionClientHelper(string subscriberName, T callbackInstance)
        {
            if(callbackInstance == null) throw new ArgumentNullException("callbackInstance");

            this.subscriberName = subscriberName;

            proxyWrapper = new SubscriptionClientProxyWrapper<TS, T>(callbackInstance);

            InitStates();
        }

        public void ConnectToServer()
        {
            if (isCommunicationThreadWorking) return;

            stopWorking = false;
            commValidatorThread = new Thread(KeepValidWorker) { Name = "CommunicationValidatorThread" };
            commValidatorThread.Start();
        }

        void KeepValidWorker()
        {
            if (isCommunicationThreadWorking) return;

            try
            {
                isCommunicationThreadWorking = true;
                DoWork();
            }
            finally
            {
                isCommunicationThreadWorking = false;
            }
        }

        void DoWork()
        {
            Debug.WriteLine(string.Format("'{0}' is working now!", Thread.CurrentThread.Name));

            while (!stopWorking)
            {// For each loop, first check if the server is available.
                var connected = IsConnected();

                if (!connected)
                {// Server is not available, build a communication channel to the server.
                    Connect();
                }

                if (CommunicationState.Opened == proxyWrapper.State 
                    && keepSubscriptionValid && !IsSubscribed(string.Empty))
                {// If server is fine(communication channel is fine) and should be subscribed but not.
                    Subscribe(subscriberName, string.Empty);
                }

                // Wait a while and check again.
                for (var i = 0; i < 200; i++)
                {
                    // ReSharper disable once ConditionIsAlwaysTrueOrFalse
                    if (!stopWorking) Thread.Sleep(100);
                }
            }

            Debug.WriteLine(string.Format("'{0}' has stopped working!", Thread.CurrentThread.Name));
        }

        private bool IsConnected()
        {
            object o = false;
            if(Invoke(ref o, MethodNames.IsConnected, null))
                return (bool)o;
    
            return false;
        }

        public void DisconnectFromServer()
        {
            if (isCommunicationThreadWorking)
            {
                // 'stopWorking' controls the loop of 'commValidatorThread', so true to break the loop.
                stopWorking = true;

                // Wait 'commValidatorThread' to exit.
                commValidatorThread.Join();

                Unsubscribe(AnyThing);

                Disconnect();
            }
        }

        public void InformWhen(string eventOpeartion)
        {
            if (string.IsNullOrEmpty(eventOpeartion))
            {
                subscribedEvents = null;
                return;
            }

            if (subscribedEvents == null)
            {
                subscribedEvents = new Dictionary<string, object>();
            }

            if (!subscribedEvents.ContainsKey(eventOpeartion))
            {
                subscribedEvents.Add(eventOpeartion, null);
            }
        }

        public void DoNotInformWhen(string eventOpeartion)
        {
            if (string.IsNullOrEmpty(eventOpeartion))
            {
                subscribedEvents = null;

                Unsubscribe(AnyThing);
                return;
            }

            if (subscribedEvents != null && subscribedEvents.ContainsKey(eventOpeartion))
            {
                Unsubscribe(eventOpeartion);
            }
        }

        public bool Invoke(ref object returnValue, string methodName, params object[] args)
        {
            return CurrentState.Invoke(ref returnValue, methodName, args);
        }

        public bool Invoke(string methodName, params object[] args)
        {
            return CurrentState.Invoke(methodName, args);
        }

        void Subscribe(string name, string eventOperation)
        {
            CurrentState.Subscribe(name, eventOperation);
        }

        bool IsSubscribed(string eventOperation)
        {
            return CurrentState.IsSubscribed(eventOperation);
        }

        void Unsubscribe(string eventOperation)
        {
            CurrentState.Unsubscribe(eventOperation);
        }              

        void InitStates()
        {
            UnconnectedState = new UnconnectedState<TS, T>(this);
            ConnectedState = new ConnectedState<TS, T>(this);
            SubscribedState = new SubscribedState<TS, T>(this);
            FaultedState = new FaultedState<TS, T>(this);

            currentState = UnconnectedState;
        }

        void Connect()
        {
            State = SubscriberState.Connecting;
            CurrentState.Connect();
        }

        void Disconnect()
        {
            State = SubscriberState.Disconnecting;
            CurrentState.Disconnect();
        }
       
    }
}
