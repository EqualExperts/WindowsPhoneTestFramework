﻿
using System;
using System.Linq;
using NUnit.Framework;
using TechTalk.SpecFlow;
using WindowsPhoneTestFramework.Test.EmuSteps.ExtensionMethods;

namespace WindowsPhoneTestFramework.Test.EmuSteps.StepDefinitions
{
    [Binding]
    public class ExpensifyUniqueStepDefinitions : EmuDefinitionBase
    {
        [Then(@"I create some unique text called ""([^\""]*)""")]
        public void StepICreateANewUniqueStringCalled(string key)
        {
            StepICreateANewUniqueStringCalled(key, string.Empty);
        }

        [Then(@"I create some unique text called ""([^\""]*)"" with prefix ""([^\""]*)""")]
        public void StepICreateANewUniqueStringCalled(string key, string prefix)
        {
            var value = prefix + Guid.NewGuid().ToString("N");
            value.StoreAsNamedUnique(key);
        }

        [Then(@"I create a unique currency amount called ""([^\""]*)"" between ""([^\""]*)"" and ""([^\""]*)""")]
        public void StepICreateANewUniqueCurrencyValueCalledAndBetween(string key, string lowerText, string upperText)
        {
            double lower;
            double upper;
            Assert.IsTrue(double.TryParse(lowerText, out lower));
            Assert.IsTrue(double.TryParse(upperText, out upper));
            var random = StepFlowContextHelpers.GetRandom();
            var doubleValue = random.NextDouble() * (upper - lower) + lower;
            var currencyValue = Math.Round((decimal)doubleValue, 2);
            currencyValue.ToString("0.00").StoreAsNamedUnique(key);
        }

        [Then(@"I enter the unique value ""([^\""]*)"" into the control ""([^\""]*)""")]
        public void StepIEnterTheUniqueValueIntoControl(string whichKey, string whichControl)
        {
            var value = whichKey.ReplaceUniqueKey();
            var subStep = string.Format(@"I enter ""{0}"" into the control ""{1}""", value, whichControl);
            Then(subStep);
        }

        [Then(@"I enter values")]
        public void StepIEnterTheValues(Table table)
        {
            IterateOverNameValueTable(table, (@"I enter ""{1}"" into the control ""{0}"""));
        }

        [Then(@"I see the controls")]
        public void ThenISeeTheControls(Table table)
        {
            IterateOverNameTable(table, @"I see the control ""{0}""");
        }

        [Then(@"I set focus to the control ""([^\""]*)""")]
        public void ThenISetFocusToTheControl(string whichControl)
        {
            Assert.IsTrue(Emu.ApplicationAutomationController.SetFocus(whichControl));
        }
    }
}