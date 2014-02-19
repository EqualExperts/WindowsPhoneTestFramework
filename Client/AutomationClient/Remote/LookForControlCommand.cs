using System.Reflection;
using WindowsPhoneTestFramework.Client.AutomationClient.Helpers;

namespace WindowsPhoneTestFramework.Client.AutomationClient.Remote
{
    public partial class LookForControlCommand
    {
        protected override void DoImpl()
        {
            var type = TypeInfo.GetType(ControlType);
            var elementFound = AutomationElementFinder.FindControlByType(type, AutomationElementFinder.GetRootVisual(), Properties);

            if (elementFound)
                SendSuccessResult();
            else
                SendNotFoundResult(string.Format("LookForTextCommand: Could not find the control of Type : {0}", ControlType));
        }
    }
}