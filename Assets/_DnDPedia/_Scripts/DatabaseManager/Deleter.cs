//----------------------------------------------------------------
// @Description: The Deleter is in charge of all operations related to the
// elimination of data and tables in the database.
// 
// @Author: Luis Betancourt
// 
// @Date: 27/07/2022
// 
// @Copyright (c) 2022 D&DPedia
//----------------------------------------------------------------

//--Namespaces----------------------------------------------------
using System.Data;

using Mono.Data.Sqlite;

using static DnDPedia.Tools.Errors;
using static DnDPedia.Tools.GlobalConstants;
using static DnDPedia.Tools.GlobalErrorCodes;
//----------------------------------------------------------------

namespace DnDPedia.DatabaseManager
{
	public class Deleter
    {
        public Deleter (IDbConnection dbConnection)
		{
            this.dbConnection = dbConnection;
        }

        // Database connection object
        private IDbConnection dbConnection;

        // Command to delete all entries from the spells table
        private static string deleteCMD = "DELETE FROM {0}";

        // Command to drop the spells table
        private static string dropCMD = "DROP TABLE {0}";

        // Command to free the space of the deleted entries in tables
        private static string vacuumCMD = "VACUUM";

        /// <summary>
        /// Delete all the entries from the provided table. The size of the table don't change. 
        /// The rows are marked to be overwritten.
        /// </summary>
        public void DeleteTable(string table)
		{
			try
			{
                // Create a CRUD operation command
                IDbCommand sqliteCommnad = new SqliteCommand((SqliteConnection) dbConnection);

                // Assign the command line to delete the rows of the table
                sqliteCommnad.CommandText = string.Format(deleteCMD, table);

                // Execute the command. Delete all rows
                sqliteCommnad.ExecuteNonQuery();

            }
            catch(SqliteException e)
			{
                PushError(DDEIND, "Sqlite exception: rows could not be deleted in table. " + e.ToString());
			}
        }

        /// <summary>
        /// Drop the provided table. The table and its content disappear from the database scheme.
        /// </summary>
        public void DropTable(string table)
        {
            try
            {
                // Create a CRUD operation command
                IDbCommand sqliteCommnad = new SqliteCommand((SqliteConnection) dbConnection);

                // Assign the command line to delete the spells
                sqliteCommnad.CommandText = string.Format(dropCMD, table);

                // Execute the command. Delete all spells
                sqliteCommnad.ExecuteNonQuery();

            }
            catch (SqliteException e)
            {
                PushError(DDETND, "Sqlite exception: table could not be dropped. " + e.ToString());
            }
        }

        /// <summary>
        /// Clean up the space left by a delete command as 'deleted content'. Reduce the size of the database.
        /// </summary>
        public void VacuumDB()
        {
            try
            {
                // Create a CRUD operation command
                IDbCommand sqliteCommnad = new SqliteCommand((SqliteConnection) dbConnection);

                // Assign the command line to delete the spells
                sqliteCommnad.CommandText = vacuumCMD;

                // Execute the command. Delete all spells
                sqliteCommnad.ExecuteNonQuery();

            }
            catch (SqliteException e)
            {
                PushError(DDEVND, "Sqlite exception: Error during vaccum operations. " + e.ToString());
            }
        }
    }
}
