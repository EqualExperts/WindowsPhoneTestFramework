﻿// ----------------------------------------------------------------------
// <copyright file="GestureBase.cs" company="Expensify">
//     (c) Copyright Expensify. http://www.expensify.com
//     This source is subject to the Microsoft Public License (Ms-PL)
//     Please see license.txt on https://github.com/Expensify/WindowsPhoneTestFramework
//     All other rights reserved.
// </copyright>
// 
// Author - Stuart Lodge, Cirrious. http://www.cirrious.com
// ------------------------------------------------------------------------

namespace WindowsPhoneTestFramework.EmuDriver
{
    public abstract class GestureBase : IGesture
    {
        public abstract void Perform(EmulatorDisplayInputController emulatorDisplayInputController);
    }
}