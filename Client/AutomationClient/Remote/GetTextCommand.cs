﻿// ----------------------------------------------------------------------
// <copyright file="GetTextCommand.cs" company="Expensify">
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
    public partial class GetTextCommand
    {
        protected override void DoImpl()
        {
            var element = GetFrameworkElement();
            if (element == null)
            {
                SendNotFoundResult();
                return;
            }

            var text =  AutomationElementFinder.GetTextForFrameworkElement(element);
            if (text != null)
            {
                SendTextResult(text);
                return;
            }

            // if text is missing... then give up
            SendNotFoundResult();
        }
    }
}