//----------------------------------------------------------------
// @Description: All error codes of the application.
// 
// @Author: Luis Betancourt
// 
// @Date: 23/072022
// 
// @Copyright (c) 2022 D&DPedia
//----------------------------------------------------------------

//--Namespaces----------------------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//----------------------------------------------------------------

namespace DnDPedia.Tools
{
    public struct GlobalErrorCodes
    {
		//----------------------------------------------------------------
		// Define the error types logic:
		// 
		// An error has the following naming structure ABBCCC / 122333.
		//
		// -A/1			Associated module.
		// -BB/22		Associated object or class.
		// -CCC/333		The error itself.
		//
		// Modules:
		//		1 - SQLite
		//		2 - Parser
		//		3 - GUI
		//		4 - Query Backend
		//		5 - Data Manager
		//		6 - Lists Administrator
		//
		// Objects of SQLite module:
		//		00 - Inserter
		//
		// Objects of Parser module:
		// Objects of GUI module:
		// Objects of Query Backend module:
		// Objects of Data Manager module:
		// Objects of Lists Administrator module:
		//----------------------------------------------------------------

		//----------------------------------------------------------------
		// List of errors
		#region

		public const int SINAEU = 100000;	// Attempt to extract unsopported data.

		#endregion
	}
}
