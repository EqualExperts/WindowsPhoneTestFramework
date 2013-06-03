using System;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using WindowsPhoneTestFramework.Client.AutomationClient.Helpers;

namespace WindowsPhoneTestFramework.Client.AutomationClient.Remote
{
    public partial class ListBoxItemScrollIntoViewCommand
    {
        protected override void DoImpl()
        {
            var element = GetFrameworkElementParent<ListBoxItem>();
            if (element == null)
            {
                SendNotFoundResult(string.Format("ListBoxItemScrollIntoViewCommand: Could not find element : {0}", AutomationIdentifier.ToIdOrName()));
                return;
            }

            element.InvokeAutomationPeer<ListBoxItem, IScrollItemProvider>(PatternInterface.Selection,
                                                                                 (pattern) =>
                                                                                     {
                                                                                         try
                                                                                         {
                                                                                             pattern.ScrollIntoView();
                                                                                         }
                                                                                         catch (Exception exception)
                                                                                         {
                                                                                             throw new TestAutomationException
                                                                                                 ("Exception while invoking list box select pattern",
                                                                                                  exception);
                                                                                         }
                                                                                     });
        }
    }
}