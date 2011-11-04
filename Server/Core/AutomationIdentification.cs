﻿// ----------------------------------------------------------------------
// <copyright file="AutomationIdentification.cs" company="Expensify">
//     (c) Copyright Expensify. http://www.expensify.com
//     This source is subject to the Microsoft Public License (Ms-PL)
//     Please see license.txt on https://github.com/Expensify/WindowsPhoneTestFramework
//     All other rights reserved.
// </copyright>
// 
// Author - Stuart Lodge, Cirrious. http://www.cirrious.com
// ------------------------------------------------------------------------

using System;

namespace WindowsPhoneTestFramework.Server.Core
{
    [Flags]
    public enum AutomationIdentification
    {
        TryAutomationName = 0x01,
        TryElementName = 0x02,
        TryDisplayedText = 0x04,
        TryEverything = TryAutomationName | TryElementName | TryDisplayedText
    }
}