//----------------------------------------------------------------
// @Description: The error management tool of the application.
// 
// @Author: Luis Betancourt
// 
// @Date: 23/07/2022
// 
// @Copyright (c) 2022 D&DPedia
//----------------------------------------------------------------

//--Namespaces----------------------------------------------------
using System;
using System.Collections.Generic;
using System.IO;

using UnityEngine;

using static DnDPedia.Tools.GlobalConstants;
//----------------------------------------------------------------

namespace DnDPedia.Tools
{
	public struct Error
	{
		public int code;
		public string msg;

		// Public constructor to create an error
		public Error(int code, string msg)
		{
			this.code = code;
			this.msg = msg;
		}

		// Set the format to write the error
		public override string ToString() => string.Format("Error {0}: {1}", this.code, this.msg);
	}

	public static class Errors
	{
		// The errors stack for the whole application
		private static Stack<Error> errors = new Stack<Error>();

		/// <summary>
		/// Create a new error and push it into the errors stack.
		/// </summary>
		/// <param name="code">THe error code.</param>
		/// <param name="msg">The error message.</param>
		public static void PushError(int code, string msg)
		{
			Error error = new Error(code, msg);
			errors.Push(error);
		}

		/// <summary>
		/// Get all errors stored in a printable format.
		/// </summary>
		/// <returns>A string that contains all errors.</returns>
		private static string GetErrors()
		{
			// Initialize the return value
			string allErrors = "";

			// Write all errors in a single string
			foreach (Error error in errors)
				allErrors += error.ToString() + "\n";

			return allErrors;
		}

		public static void WriteErrors()
		{
			try
			{
				// Opening the log file in append mode
				StreamWriter writer = new StreamWriter(Application.dataPath + LOG_PATH, true);
				
				// Write the errors in the log file
				writer.Write(string.Format("Errors ({0}): \n", errors.Count));
				writer.Write(GetErrors());
			}
			catch(IOException e)
			{
				// If an error ocurred while opening the log file write it to the console
				Console.WriteLine("Error opening the log file: " + e.ToString());
			}
		}

		/// <summary>
		/// Check the number of errors stored in the stack to determinate if an error has ocurred during execution.
		/// </summary>
		/// <returns>True if at least one error is stored in the stack, False otherwise.</returns>
		public static bool HasErrorOcurred() => errors.Count > 0;
	}
}
