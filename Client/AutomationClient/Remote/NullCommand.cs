﻿// ----------------------------------------------------------------------
// <copyright file="NullCommand.cs" company="Expensify">
//     (c) Copyright Expensify. http://www.expensify.com
//     This source is subject to the Microsoft Public License (Ms-PL)
//     Please see license.txt on https://github.com/Expensify/WindowsPhoneTestFramework
//     All other rights reserved.
// </copyright>
// 
// Author - Stuart Lodge, Cirrious. http://www.cirrious.com
// ------------------------------------------------------------------------

namespace WindowsPhoneTestFramework.AutomationClient.Remote
{
    public partial class NullCommand
    {
        protected override void DoImpl()
        {
            SkipResult();
            // nothing to do :)
        }
    }
}