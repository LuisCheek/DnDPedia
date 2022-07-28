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
//----------------------------------------------------------------

namespace DnDPedia.Tools
{
	public struct GlobalConstants
	{
		#region Application

		// TODO: Maybe the path changes in the release build. Better to search it out.
		// Path to the application log file
		public const string LOG_PATH = "/_DnDPedia/D&DPedia.log";

		// Path to the folder that contains the spells json files of each book
		public const string JSON_SPELL_BOOKS = "/_DnDPedia/Json/SpellBooks";

		// Path to the folder that contains the user's spell lists
		public const string JSON_SPELL_LISTS = "/_DnDPedia/Json/SpellLists";

		#endregion


		#region Database

		// Path to the spells database
		public const string DATABASE_PATH = "/_DnDPedia/Databases/SpellsDB.db";

		// Table names
		public const string SPELLS_TABLE = "SPELLS";
		public const string SOURCES_TABLE = "SOURCES";

		// Paths to the files that contains the commands to create the tables
		public const string SPELLS_TABLE_PATH = "/_DnDPedia/Databases/SPELLS_CMD.txt";
		public const string SOURCES_TABLE_PATH = "/_DnDPedia/Databases/SOURCES_CMD.txt";

		#endregion
	}
}
