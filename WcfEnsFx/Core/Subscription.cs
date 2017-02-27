using System;
using System.Runtime.Serialization;

namespace WcfEnsFx.Core
{
    [DataContract]
    public class Subscription<T> where T : class
    {
        readonly T subscriber;
        string subscriberName;
                
        public T Subscriber
        {
            get { return subscriber; }
        }

        [DataMember]
        public string SubscriberName
        {
            get { return subscriberName; }
            set { subscriberName = value; }
        }

        [DataMember]
        public int Key { get; set; }

        public Subscription(string subscriberName, T subscriber)
        {
            if (null == subscriber)
            {
                throw new ArgumentNullException(nameof(subscriber));
            }

            Key = subscriber.GetHashCode();
            this.subscriberName = subscriberName;
            this.subscriber = subscriber;
        }

        public override string ToString()
        {
            return subscriberName;
        }
    }
}