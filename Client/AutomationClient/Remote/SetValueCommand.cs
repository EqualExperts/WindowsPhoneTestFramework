﻿// ----------------------------------------------------------------------
// <copyright file="SetValueCommand.cs" company="Expensify">
//     (c) Copyright Expensify. http://www.expensify.com
//     This source is subject to the Microsoft Public License (Ms-PL)
//     Please see license.txt on https://github.com/Expensify/WindowsPhoneTestFramework
//     All other rights reserved.
// </copyright>
// 
// Author - Stuart Lodge, Cirrious. http://www.cirrious.com
// ------------------------------------------------------------------------

namespace WindowsPhoneTestFramework.Client.AutomationClient.Remote
{
    public partial class SetValueCommand
    {
        protected override void DoImpl()
        {
            var element = GetUIElement();
            if (element == null)
                return;

            if (AutomationElementFinder.SetElementProperty<string>(element, "Text", TextValue))
            {
                SendSuccessResult();
                return;
            }

            if (AutomationElementFinder.SetElementProperty<string>(element, "Password", TextValue))
            {
                SendSuccessResult();
                return;
            }

            bool boolValue;
            if (bool.TryParse(TextValue, out boolValue))
            {
                if (AutomationElementFinder.SetElementProperty<bool>(element, "IsChecked", boolValue))
                {
                    SendSuccessResult();
                    return;
                }
            }

            int intValue;
            if (int.TryParse(TextValue, out intValue))
            {
                if (AutomationElementFinder.SetElementProperty<int>(element, "Value", intValue))
                {
                    SendSuccessResult();
                    return;
                }
            }

            double doubleValue;
            if (double.TryParse(TextValue, out doubleValue))
            {
                if (AutomationElementFinder.SetElementProperty<double>(element, "Value", doubleValue))
                {
                    SendSuccessResult();
                    return;
                }
            }


            // if text, password IsChecked, Value are all missing... then give up
            SendNotFoundResult();
        }
    }
}