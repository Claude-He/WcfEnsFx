using System.Runtime.Serialization;

namespace WcfEnsFx
{
    [DataContract]
    public class Subscription<T> where T : class
    {
        string subscriberName;

        [DataMember]
        public string SubscriberName
        {
            get { return subscriberName; }
            set { subscriberName = value; }
        }
        
        
        readonly T subscriber;

        public T Subscriber 
        {
            get { return subscriber; }
        }

        [DataMember]
        public int Key { get; set; }
        
        internal Subscription(string subscriberName, T subscriber)
        {
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
