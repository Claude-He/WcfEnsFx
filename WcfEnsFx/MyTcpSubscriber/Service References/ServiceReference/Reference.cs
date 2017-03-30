﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MyTcpSubscriber.ServiceReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="https://github.com/Claude-He/WcfEnsFx", ConfigurationName="ServiceReference.IMyService", CallbackContract=typeof(MyTcpSubscriber.ServiceReference.IMyServiceCallback))]
    public interface IMyService {
        
        // CODEGEN: Generating message contract since the wrapper namespace (http://tempuri.org/) of message SubscribeRequest does not match the default value (https://github.com/Claude-He/WcfEnsFx)
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEnsSubscription/Subscribe", ReplyAction="http://tempuri.org/IEnsSubscription/SubscribeResponse")]
        MyTcpSubscriber.ServiceReference.SubscribeResponse Subscribe(MyTcpSubscriber.ServiceReference.SubscribeRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEnsSubscription/Subscribe", ReplyAction="http://tempuri.org/IEnsSubscription/SubscribeResponse")]
        System.Threading.Tasks.Task<MyTcpSubscriber.ServiceReference.SubscribeResponse> SubscribeAsync(MyTcpSubscriber.ServiceReference.SubscribeRequest request);
        
        // CODEGEN: Generating message contract since the wrapper namespace (http://tempuri.org/) of message UnsubscribeRequest does not match the default value (https://github.com/Claude-He/WcfEnsFx)
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEnsSubscription/Unsubscribe", ReplyAction="http://tempuri.org/IEnsSubscription/UnsubscribeResponse")]
        MyTcpSubscriber.ServiceReference.UnsubscribeResponse Unsubscribe(MyTcpSubscriber.ServiceReference.UnsubscribeRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEnsSubscription/Unsubscribe", ReplyAction="http://tempuri.org/IEnsSubscription/UnsubscribeResponse")]
        System.Threading.Tasks.Task<MyTcpSubscriber.ServiceReference.UnsubscribeResponse> UnsubscribeAsync(MyTcpSubscriber.ServiceReference.UnsubscribeRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="https://github.com/Claude-He/WcfEnsFx/IMyService/GetTime", ReplyAction="https://github.com/Claude-He/WcfEnsFx/IMyService/GetTimeResponse")]
        System.DateTime GetTime();
        
        [System.ServiceModel.OperationContractAttribute(Action="https://github.com/Claude-He/WcfEnsFx/IMyService/GetTime", ReplyAction="https://github.com/Claude-He/WcfEnsFx/IMyService/GetTimeResponse")]
        System.Threading.Tasks.Task<System.DateTime> GetTimeAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IMyServiceCallback {
        
        [System.ServiceModel.OperationContractAttribute(Action="https://github.com/Claude-He/WcfEnsFx/IMyService/DemoEvent", ReplyAction="https://github.com/Claude-He/WcfEnsFx/IMyService/DemoEventResponse")]
        void DemoEvent(string eventMessage);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="Subscribe", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class SubscribeRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public string subscriberName;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=1)]
        public string eventName;
        
        public SubscribeRequest() {
        }
        
        public SubscribeRequest(string subscriberName, string eventName) {
            this.subscriberName = subscriberName;
            this.eventName = eventName;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="SubscribeResponse", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class SubscribeResponse {
        
        public SubscribeResponse() {
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="Unsubscribe", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class UnsubscribeRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public string eventName;
        
        public UnsubscribeRequest() {
        }
        
        public UnsubscribeRequest(string eventName) {
            this.eventName = eventName;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="UnsubscribeResponse", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class UnsubscribeResponse {
        
        public UnsubscribeResponse() {
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IMyServiceChannel : MyTcpSubscriber.ServiceReference.IMyService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class MyServiceClient : System.ServiceModel.DuplexClientBase<MyTcpSubscriber.ServiceReference.IMyService>, MyTcpSubscriber.ServiceReference.IMyService {
        
        public MyServiceClient(System.ServiceModel.InstanceContext callbackInstance) : 
                base(callbackInstance) {
        }
        
        public MyServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName) : 
                base(callbackInstance, endpointConfigurationName) {
        }
        
        public MyServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, string remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public MyServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public MyServiceClient(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        MyTcpSubscriber.ServiceReference.SubscribeResponse MyTcpSubscriber.ServiceReference.IMyService.Subscribe(MyTcpSubscriber.ServiceReference.SubscribeRequest request) {
            return base.Channel.Subscribe(request);
        }
        
        public void Subscribe(string subscriberName, string eventName) {
            MyTcpSubscriber.ServiceReference.SubscribeRequest inValue = new MyTcpSubscriber.ServiceReference.SubscribeRequest();
            inValue.subscriberName = subscriberName;
            inValue.eventName = eventName;
            MyTcpSubscriber.ServiceReference.SubscribeResponse retVal = ((MyTcpSubscriber.ServiceReference.IMyService)(this)).Subscribe(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<MyTcpSubscriber.ServiceReference.SubscribeResponse> MyTcpSubscriber.ServiceReference.IMyService.SubscribeAsync(MyTcpSubscriber.ServiceReference.SubscribeRequest request) {
            return base.Channel.SubscribeAsync(request);
        }
        
        public System.Threading.Tasks.Task<MyTcpSubscriber.ServiceReference.SubscribeResponse> SubscribeAsync(string subscriberName, string eventName) {
            MyTcpSubscriber.ServiceReference.SubscribeRequest inValue = new MyTcpSubscriber.ServiceReference.SubscribeRequest();
            inValue.subscriberName = subscriberName;
            inValue.eventName = eventName;
            return ((MyTcpSubscriber.ServiceReference.IMyService)(this)).SubscribeAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        MyTcpSubscriber.ServiceReference.UnsubscribeResponse MyTcpSubscriber.ServiceReference.IMyService.Unsubscribe(MyTcpSubscriber.ServiceReference.UnsubscribeRequest request) {
            return base.Channel.Unsubscribe(request);
        }
        
        public void Unsubscribe(string eventName) {
            MyTcpSubscriber.ServiceReference.UnsubscribeRequest inValue = new MyTcpSubscriber.ServiceReference.UnsubscribeRequest();
            inValue.eventName = eventName;
            MyTcpSubscriber.ServiceReference.UnsubscribeResponse retVal = ((MyTcpSubscriber.ServiceReference.IMyService)(this)).Unsubscribe(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<MyTcpSubscriber.ServiceReference.UnsubscribeResponse> MyTcpSubscriber.ServiceReference.IMyService.UnsubscribeAsync(MyTcpSubscriber.ServiceReference.UnsubscribeRequest request) {
            return base.Channel.UnsubscribeAsync(request);
        }
        
        public System.Threading.Tasks.Task<MyTcpSubscriber.ServiceReference.UnsubscribeResponse> UnsubscribeAsync(string eventName) {
            MyTcpSubscriber.ServiceReference.UnsubscribeRequest inValue = new MyTcpSubscriber.ServiceReference.UnsubscribeRequest();
            inValue.eventName = eventName;
            return ((MyTcpSubscriber.ServiceReference.IMyService)(this)).UnsubscribeAsync(inValue);
        }
        
        public System.DateTime GetTime() {
            return base.Channel.GetTime();
        }
        
        public System.Threading.Tasks.Task<System.DateTime> GetTimeAsync() {
            return base.Channel.GetTimeAsync();
        }
    }
}
