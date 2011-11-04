// ----------------------------------------------------------------------
// <copyright file="ActionFailedResult.java" company="Expensify">
//     (c) Copyright Expensify. http://www.expensify.com
//     This source is subject to the Microsoft Public License (Ms-PL)
//     Please see license.txt on https://github.com/Expensify/WindowsPhoneTestFramework
//     All other rights reserved.
// </copyright>
// 
// Author - Stuart Lodge, Cirrious. http://www.cirrious.com
// ------------------------------------------------------------------------

package com.expensify.testframework.remote.results;


public class ActionFailedResult extends FailedResultBase {
	public ActionFailedResult()
	{
        FailureText = "Action failed";    	
	}
}
