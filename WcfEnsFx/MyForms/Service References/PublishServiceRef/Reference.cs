﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MyForms.PublishServiceRef {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="https://github.com/Claude-He/WcfEnsFx", ConfigurationName="PublishServiceRef.IMyEvent")]
    public interface IMyEvent {
        
        [System.ServiceModel.OperationContractAttribute(Action="https://github.com/Claude-He/WcfEnsFx/IMyEvent/DemoEvent", ReplyAction="https://github.com/Claude-He/WcfEnsFx/IMyEvent/DemoEventResponse")]
        void DemoEvent(string strArg);
        
        [System.ServiceModel.OperationContractAttribute(Action="https://github.com/Claude-He/WcfEnsFx/IMyEvent/DemoEvent", ReplyAction="https://github.com/Claude-He/WcfEnsFx/IMyEvent/DemoEventResponse")]
        System.Threading.Tasks.Task DemoEventAsync(string strArg);
        
        [System.ServiceModel.OperationContractAttribute(Action="https://github.com/Claude-He/WcfEnsFx/IMyEvent/DemoEventWithInt", ReplyAction="https://github.com/Claude-He/WcfEnsFx/IMyEvent/DemoEventWithIntResponse")]
        void DemoEventWithInt(string strArg, int intArg);
        
        [System.ServiceModel.OperationContractAttribute(Action="https://github.com/Claude-He/WcfEnsFx/IMyEvent/DemoEventWithInt", ReplyAction="https://github.com/Claude-He/WcfEnsFx/IMyEvent/DemoEventWithIntResponse")]
        System.Threading.Tasks.Task DemoEventWithIntAsync(string strArg, int intArg);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IMyEventChannel : MyForms.PublishServiceRef.IMyEvent, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class MyEventClient : System.ServiceModel.ClientBase<MyForms.PublishServiceRef.IMyEvent>, MyForms.PublishServiceRef.IMyEvent {
        
        public MyEventClient() {
        }
        
        public MyEventClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public MyEventClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MyEventClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MyEventClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void DemoEvent(string strArg) {
            base.Channel.DemoEvent(strArg);
        }
        
        public System.Threading.Tasks.Task DemoEventAsync(string strArg) {
            return base.Channel.DemoEventAsync(strArg);
        }
        
        public void DemoEventWithInt(string strArg, int intArg) {
            base.Channel.DemoEventWithInt(strArg, intArg);
        }
        
        public System.Threading.Tasks.Task DemoEventWithIntAsync(string strArg, int intArg) {
            return base.Channel.DemoEventWithIntAsync(strArg, intArg);
        }
    }
}
