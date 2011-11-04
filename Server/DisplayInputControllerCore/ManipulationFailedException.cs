﻿// ----------------------------------------------------------------------
// <copyright file="ManipulationFailedException.cs" company="Expensify">
//     (c) Copyright Expensify. http://www.expensify.com
//     This source is subject to the Microsoft Public License (Ms-PL)
//     Please see license.txt on https://github.com/Expensify/WindowsPhoneTestFramework
//     All other rights reserved.
// </copyright>
// 
// Author - Stuart Lodge, Cirrious. http://www.cirrious.com
// ------------------------------------------------------------------------

using System;
using System.Runtime.Serialization;
using WindowsPhoneTestFramework.Server.Core;

namespace WindowsPhoneTestFramework.Server.DisplayInputControllerCore
{
    [Serializable]
    public class ManipulationFailedException : AutomationException
    {
        public ManipulationFailedException()
        {
            
        }

        public ManipulationFailedException(string message, params object[] args)
            : base(string.Format(message, args))
        {            
        }

        public ManipulationFailedException(string message, Exception innerException)
            : base (message, innerException)
        {            
        }

        public ManipulationFailedException(SerializationInfo info, StreamingContext context)
            : base (info, context)
        {            
        }    
    }
}