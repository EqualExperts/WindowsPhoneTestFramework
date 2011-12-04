﻿// ----------------------------------------------------------------------
// <copyright file="GetValueCommand.cs" company="Expensify">
//     (c) Copyright Expensify. http://www.expensify.com
//     This source is subject to the Microsoft Public License (Ms-PL)
//     Please see license.txt on https://github.com/Expensify/WindowsPhoneTestFramework
//     All other rights reserved.
// </copyright>
// 
// Author - Stuart Lodge, Cirrious. http://www.cirrious.com
// ------------------------------------------------------------------------

using WindowsPhoneTestFramework.Client.AutomationClient.Helpers;

namespace WindowsPhoneTestFramework.Client.AutomationClient.Remote
{
    public partial class GetValueCommand
    {
        protected override void DoImpl()
        {
            var element = GetFrameworkElement();
            if (element == null)
            {
                return;
            }

            string textValue;
            if (ValueCommandHelper.TryGetValue(element, out textValue))
            {
                SendTextResult(textValue);
                return;
            }

            var value =  AutomationElementFinder.GetValueForFrameworkElement(element);
            if (value != null)
            {
                SendTextResult(value);
                return;
            }

            // if text is missing... then give up
            SendNotFoundResult();
        }
    }
}