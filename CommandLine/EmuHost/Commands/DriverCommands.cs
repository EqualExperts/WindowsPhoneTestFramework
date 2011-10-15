﻿// ----------------------------------------------------------------------
// <copyright file="DriverCommands.cs" company="Expensify">
//     (c) Copyright Expensify. http://www.expensify.com
//     This source is subject to the Microsoft Public License (Ms-PL)
//     Please see license.txt on https://github.com/Expensify/WindowsPhoneTestFramework
//     All other rights reserved.
// </copyright>
// 
// Author - Stuart Lodge, Cirrious. http://www.cirrious.com
// ------------------------------------------------------------------------

using System;
using System.ComponentModel;
using WindowsPhoneTestFramework.CommandLineHost;
using WindowsPhoneTestFramework.EmuDriver;

namespace WindowsPhoneTestFramework.EmuHost.Commands
{
    public class DriverCommands
    {
        public IDriver Driver { get; set; }
        public AppLaunchingCommandLine CommandLine;

        [CommandLineCommand("install")]
        [Description("installs the app - e.g. 'install'")]
        public void Install(string ignored)
        {
            var result = Driver.Install(CommandLine.ProductId, CommandLine.Name, CommandLine.IconPath, CommandLine.XapPath);
            Console.WriteLine("install:" + result);
        }

        [CommandLineCommand("forceInstall")]
        [Description("installs the app - shutting it down first if required - e.g. 'forceInstall'")]
        public void ForceInstall(string ignored)
        {
            var result = Driver.ForceInstall(CommandLine.ProductId, CommandLine.Name, CommandLine.IconPath, CommandLine.XapPath);
            Console.WriteLine("forceInstall:" + result);
        }

        [CommandLineCommand("uninstall")]
        [Description("uninstalls the app - e.g. 'uninstall'")]
        public void Uninstall(string ignored)
        {
            var result = Driver.Uninstall(CommandLine.ProductId);
            Console.WriteLine("uninstall:" + result);
        }

        [CommandLineCommand("forceUninstall")]
        [Description("uninstalls the app - shutting it down first if required - e.g. 'forceUninstall'")]
        public void ForceUninstall(string ignored)
        {
            var result = Driver.ForceUninstall(CommandLine.ProductId);
            Console.WriteLine("forceUninstall:" + result);
        }

        [CommandLineCommand("launch")]
        [Description("launches the app - e.g. 'launch'")]
        public void Launch(string ignored)
        {
            var result = Driver.Start(CommandLine.ProductId);
            Console.WriteLine("launch:" + result);
        }

        [CommandLineCommand("stop")]
        [Description("stop the app - e.g. 'stop'")]
        public void Stop(string ignored)
        {
            var result = Driver.Stop(CommandLine.ProductId);
            Console.WriteLine("stop:" + result);
        }
    }
}