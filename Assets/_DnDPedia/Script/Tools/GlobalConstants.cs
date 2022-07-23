//----------------------------------------------------------------
// @Description: All the global constants of the application.
// 
// @Author: Luis Betancourt
// 
// @Date: dd/mm/2022
// 
// @Copyright (c) 2022 @ProjectName
//----------------------------------------------------------------

//--Namespaces----------------------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//----------------------------------------------------------------

namespace DnDPedia.Tools
{
	public struct GlobalConstants
	{
		#region Application

		// TODO: Maybe the path changes in the release build. Better to search it out.
		// Path to the application log file
		public const string LOG_PATH = "/_DnDPedia/D&DPedia.log";

		#endregion

		
		#region Database

		// Path to the spells database
		public const string DATABASE_PATH = "/_DnDpedia/DB/Spells.db";

		// Table names
		public const string SPELLS_TABLE = "SPELLS";
		public const string SOURCES_TABLE = "SOURCES";

		#endregion
	}
}
