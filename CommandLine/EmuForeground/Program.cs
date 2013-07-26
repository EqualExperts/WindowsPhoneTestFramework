﻿//  ----------------------------------------------------------------------
//  <copyright file="Program.cs" company="Expensify">
//      (c) Copyright Expensify. http://www.expensify.com
//      This source is subject to the Microsoft Public License (Ms-PL)
//      Please see license.txt on https://github.com/Expensify/WindowsPhoneTestFramework
//      All other rights reserved.
//  </copyright>
//  
//  Author - Stuart Lodge, Cirrious. http://www.cirrious.com
//  ------------------------------------------------------------------------

using WindowsPhoneTestFramework.Server.WindowsPhoneDeviceController;

namespace WindowsPhoneTestFramework.CommandLine.EmuForeground
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var displayInputController = new WindowsPhoneWindowsEmulatorDisplayInputController();
            displayInputController.EnsureWindowIsInForeground();
        }
    }
}