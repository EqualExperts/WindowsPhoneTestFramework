using System.Runtime.Serialization;

namespace WindowsPhoneTestFramework.Server.WCFHostedAutomationController.Commands
{
    [DataContract]
    public class EnterTextCommand : AutomationElementCommandBase
    {
        [DataMember]
        public string Text { get; set; }
    }
}