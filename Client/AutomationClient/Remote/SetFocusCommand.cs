// ----------------------------------------------------------------------
// <copyright file="SetFocusCommand.cs" company="Expensify">
//     (c) Copyright Expensify. http://www.expensify.com
//     This source is subject to the Microsoft Public License (Ms-PL)
//     Please see license.txt on https://github.com/Expensify/WindowsPhoneTestFramework
//     All other rights reserved.
// </copyright>
// 
// Author - Stuart Lodge, Cirrious. http://www.cirrious.com
// ------------------------------------------------------------------------

using System.Windows.Controls;
using WindowsPhoneTestFramework.Client.AutomationClient.Helpers;

namespace WindowsPhoneTestFramework.Client.AutomationClient.Remote
{
    public partial class SetFocusCommand
    {
        protected override void DoImpl()
        {
            var element = GetFrameworkElement();
            if (element == null)
                return;

            var control = element as Control;
            if (control == null)
            {
                SendNotFoundResult(string.Format("SetFocusCommand: Could not find the control : {0}", AutomationIdentifier.ToIdOrName()));
                return;
            }

            control.Focus();
            SendSuccessResult();
        }
    }
}