using System;
using System.Diagnostics;
using System.ServiceModel;

namespace WcfEnsFx
{
    class ServiceWrapper<T> where T : class
    {
        internal event ServiceStateChangedEventHandler StateChanged;

        private ServiceHost serviceHost;

        internal ServerState<T> ClosedState { get; private set; }

        internal ServerState<T> OpenedState { get; private set; }

        internal ServerState<T> FaultedState { get; private set; }

        internal ServerState<T> CurrentState { get; set; }

        internal CommunicationState State
        {
            get
            {
                return serviceHost == null ? CommunicationState.Closed : serviceHost.State;
            }
        }
             
        internal ServiceWrapper()
        {
            InitState();
        }

        /// <summary>
        /// An implementation of Design Pattern: State Pattern.
        /// 
        /// ServiceHost actually has three states, here they are reduced to only
        /// three. States like Opening, Closing and Created states are not managed
        /// here in this class.
        /// </summary>
        private void InitState()
        {
            var context = this;
            ClosedState = new ClosedState<T>(context);
            OpenedState = new OpenedState<T>(context);
            FaultedState = new FaultedState<T>(context);

            CurrentState = ClosedState;
        }

        internal void OpenService()
        {
            CurrentState.Open();
        }

        internal void CloseService()
        {
            CurrentState.Close();
        }

        internal bool Open()
        {
            try
            {
                serviceHost = new ServiceHost(typeof(T));

                serviceHost.Opened += OnStateChanged;
                serviceHost.Opening += OnStateChanged;
                serviceHost.Closing += OnStateChanged;
                serviceHost.Closed += OnStateChanged;
                serviceHost.Faulted += OnStateChanged;

                serviceHost.Open();
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return false;
            }
        }
        
        internal bool Close()
        {
            try
            {
                serviceHost.Close();
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return false;
            }
        }

        private void OnStateChanged(object sender, EventArgs e)
        {
            if (StateChanged != null)
                StateChanged(serviceHost.State);
        }
    }
}
