﻿// ----------------------------------------------------------------------
// <copyright file="AutomationController.cs" company="Expensify">
//     (c) Copyright Expensify. http://www.expensify.com
//     This source is subject to the Microsoft Public License (Ms-PL)
//     Please see license.txt on https://github.com/Expensify/WindowsPhoneTestFramework
//     All other rights reserved.
// </copyright>
// 
// Author - Stuart Lodge, Cirrious. http://www.cirrious.com
// ------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using WindowsPhoneTestFramework.Server.AndroidDeviceController;
using WindowsPhoneTestFramework.Server.Core;
using WindowsPhoneTestFramework.Server.Utils;
using WindowsPhoneTestFramework.Server.WCFHostedAutomationController;

namespace WindowsPhoneTestFramework.Server.AutomationController.Android.Emulator
{
    public class ParsedInitialisationString
    {
        public Dictionary<string, string> Fields { get; private set; }

        public ParsedInitialisationString(string initialisation)
        {
            FillFrom(initialisation);
        }

        public string SafeGetValue(string key, string defaultValue = "")
        {
            string toReturn;
            if (Fields.TryGetValue(key, out toReturn))
                return toReturn;

            return defaultValue;
        }

        public void FillFrom(string initialisation)
        {
            Fields = new Dictionary<string, string>();

            if (string.IsNullOrEmpty(initialisation))
                return;

            var split = initialisation.Split(new char[] {';'}, StringSplitOptions.RemoveEmptyEntries);
            foreach (var entry in split)
            {
                var entrySplit = entry.Split(new char[] {'='}, 2);
                if (entrySplit.Length != 2)
                    continue;

                var key = entrySplit[0];
                var value = entrySplit[1];
                if (string.IsNullOrEmpty(key))
                    continue;

                Fields[key] = value;
            }
        }
    }

    public class AutomationController : TraceBase, IAutomationController
    {
        private ServiceHostController _hostController;

        public IApplicationAutomationController ApplicationAutomationController { get { return _hostController == null ? null : _hostController.AutomationController; } }
        public IDeviceController DeviceController { get; set; }
        public IDisplayInputController DisplayInputController { get { return DeviceController.DisplayInputController; } }

        public void Dispose()
        {
            Stop();
            GC.SuppressFinalize(this);
        }

        public void Start(string initialisationString = null, AutomationIdentification automationIdentification = AutomationIdentification.TryEverything)
        {
            if (_hostController != null)
                throw new InvalidOperationException("hostController already initialised");

            if (DeviceController != null)
                throw new InvalidOperationException("Driver already initialised");

            var parsedInitialisationString = new ParsedInitialisationString(initialisationString);

            var bindingAddressUrl = parsedInitialisationString.SafeGetValue("BindingAddress");
            var bindingAddressUri = string.IsNullOrEmpty(bindingAddressUrl) ? null : new Uri(bindingAddressUrl);

            StartDriver(parsedInitialisationString);
            StartPhoneAutomationController(automationIdentification, bindingAddressUri);
        }

        private void StartDriver(ParsedInitialisationString parsedInitialisationString)
        {
            var driverConfiguration = new AdbDeviceControllerConfiguration(parsedInitialisationString.Fields);
            var driver = new AdbDeviceController(driverConfiguration);
            driver.Trace += (sender, args) => InvokeTrace(args);
            if (!driver.TryConnect())
                throw new AutomationException("Unable to connect to Android emulator driver");
            DeviceController = driver;
        }

        private void StartPhoneAutomationController(AutomationIdentification automationIdentification, Uri bindingAddress)
        {
            try
            {
                var hostController = new ServiceHostController()
                {
                    AutomationIdentification = automationIdentification,
                };

                if (bindingAddress != null)
                    hostController.BindingAddress = bindingAddress;

                hostController.Trace += (sender, args) => InvokeTrace(args);

                hostController.Start();

                _hostController = hostController;
            }
            catch (Exception exception)
            {
                throw new AutomationException("Failed to start ApplicationAutomationController", exception);
            }
        }

        public void Stop()
        {
            if (_hostController != null)
            {
                _hostController.Stop();
                _hostController = null;
            }
            if (DeviceController != null)
            {
                DeviceController.ReleaseDeviceConnection();
                DeviceController = null;
            }
        }
    }
}
