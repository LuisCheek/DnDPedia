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
		//		1 - (D) Database Manager
		//		2 - (U) UserInterface
		//		3 - (L) ListAdministrator
		//		4 - (T) Tools
		//
		// Objects of DatabaseManager module:
		//		00 - (DM) DatabaseManager
		//		01 - (IN) Inserter
		//		02 - (DE) Deleter
		//		03 - (RE) Reader
		//		04 - (UP) Updater
		//
		// Objects of UserInterface module:
		//		00 - (FI) Filter
		//		01 - (DI) Displayer
		//		02 - (SA) Saver
		//
		// Objects of ListAdministrator module:
		//		00 - (EX) Exporter
		//
		// Objects of Tools module:
		//		00 - (PA) Parser
		//----------------------------------------------------------------

		//----------------------------------------------------------------
		// List of errors

		// To facilitate code reading.
		public const int NOERROR = 0;

		#region DatabaseManager

		public const int DDMOSJ = 100000;   // Error opening a spellbook json file.
		public const int DDMCNO = 100001;	// Error. Datanase connection is not open.
		public const int DININI = 101000;   // SQLite exception. Item could not be inserted.
		public const int DINEOF = 101001;   // Error opening a command text file.
		public const int DINTNC = 101002;   // SQLite exception. Table could not be created.
		public const int DDEIND = 102000;	// SQLite exception. Item could not be deleted.
		public const int DDETND = 102001;	// SQLite exception. Table could not be dropped.
		public const int DDEVND = 102002;   // SQLite exception. Vacuum could not be done.
		public const int DUPSNU = 104000;   // SQLite exception: Item could not be updated.

		#endregion

		#region UserInterface
		#endregion

		#region ListAdministrator
		#endregion

		#region Tools

		public const int TPAUVF = 400000;   // Unexpected value found during parsing.

		#endregion
	}
}
