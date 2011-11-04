﻿// ----------------------------------------------------------------------
// <copyright file="MultipointGestureBase.cs" company="Expensify">
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
using System.Drawing;

namespace WindowsPhoneTestFramework.Server.Core.Gestures
{
    public abstract class MultipointGestureBase : GestureBase
    {
        public int NumberOfIntermediatePoints { get; set; }
        public TimeSpan PeriodBetweenPoints { get; set; }

        protected MultipointGestureBase()
        {
            NumberOfIntermediatePoints = 10;
            PeriodBetweenPoints = TimeSpan.FromMilliseconds(20.0);
        }

        public override void Perform(IDisplayInputController displayInputController)
        {
            var screenPoints = GetScreenPoints();
            if (screenPoints != null)
                PerformScreenPoints(displayInputController, screenPoints);
        }

        private void PerformScreenPoints(IDisplayInputController displayInputController, IEnumerable<Point> points)
        {
            var translatedPoints = displayInputController.TranslatePhonePositionsToHostPositions(points);
            PerformTranslatedPoints(displayInputController, translatedPoints);
        }

        private void PerformTranslatedPoints(IDisplayInputController displayInputController, IEnumerable<Point> translatedPoints)
        {
            displayInputController.PerformMouseDownMoveUp(translatedPoints, PeriodBetweenPoints);
        }

        protected abstract IEnumerable<Point> GetScreenPoints();
    }
}