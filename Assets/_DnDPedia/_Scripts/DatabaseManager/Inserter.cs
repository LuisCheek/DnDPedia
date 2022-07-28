//----------------------------------------------------------------
// @Description: The Inserter's job is to create new tables in the database
// and insert new entries in those tables.
// 
// @Author: Luis Betancourt
// 
// @Date: 23/07/2022
// 
// @Copyright (c) 2022 D&DPedia
//----------------------------------------------------------------

//--Namespaces----------------------------------------------------
using System;
using System.Data;
using System.IO;

using Mono.Data.Sqlite;

using UnityEngine;

using static DnDPedia.Tools.Errors;
using static DnDPedia.Tools.GlobalErrorCodes;
//----------------------------------------------------------------

namespace DnDPedia.DatabaseManager
{
	public class Inserter
    {
        public Inserter(IDbConnection dbConnection)
        {
            this.dbConnection = dbConnection;
        }

        // Database connection object
        private IDbConnection dbConnection;

        // Command to insert entry into the spells table
        private static string insertCMD = "INSERT INTO {0} ({1}) VALUES ({2})";

        /// <summary>
        /// Create a table in the database.
        /// </summary>
        /// <param name="tableCommandText">The text file that contains the full SQLite command to create the table.</param>
        public void CreateTable(string tableCommandText)
		{          
            try
			{
                // Create a CRUD operation command
                IDbCommand sqliteCommnad = new SqliteCommand((SqliteConnection) dbConnection);

                // Opening the file that contains the command
                StreamReader reader = new StreamReader(Application.dataPath + tableCommandText);

                // Set the command
                sqliteCommnad.CommandText = reader.ReadToEnd();

                // Executing the command. Create the SPELLS table
                sqliteCommnad.ExecuteNonQuery();

                // Close the file
                reader.Close();

			}
            catch(Exception e)
			{
                if(e is IOException)
                    PushError(DINEOF, "Error opening the command text file: " +e.ToString());

                if(e is SqliteException)
                    PushError(DINTNC, "SQLite exception: Table could not be created." + e.ToString());
			}
        }

        /// <summary>
        /// Insert an item into the provided table.
        /// </summary>
        /// <param name="table">The table where the items will be inserted.</param>
        /// <param name="fields">The fields of the item.</param>
        /// <param name="values">The values of the item's fields.</param>
        public void Insert(string table, string fields, string values)
		{
			try
			{
                // Create a CRUD operation command
                IDbCommand sqliteCommnad = new SqliteCommand((SqliteConnection) dbConnection);
                                		
                // Create the command line to insert the spell
                sqliteCommnad.CommandText = string.Format(insertCMD, table, fields, values);

                // Execute the command. Insert the spell
                sqliteCommnad.ExecuteNonQuery();

			}
			catch (SqliteException e)
			{
                PushError(DININI, "Sqlite exception: item could not be inserted in table. " + e.ToString());
            }
		}

    }
}
