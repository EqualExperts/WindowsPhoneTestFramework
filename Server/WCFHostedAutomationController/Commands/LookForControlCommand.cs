using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace WindowsPhoneTestFramework.Server.WCFHostedAutomationController.Commands
{
    [DataContract]
    public class LookForControlCommand : CommandBase
    {
        [DataMember]
        public Dictionary<string, object> Properties { get; set; }

        [DataMember]
        public string ControlType { get; set; }
    }
}
