//----------------------------------------------------------------
// @Description: Just a dummy script to test things with a dummy
// database.
//
// @Author: Luis Betancourt
//
// @Date: 23/07/2022
//
// @Copyright (c) 2022 D&DPedia
//----------------------------------------------------------------

//--Namespaces----------------------------------------------------
using System.Collections;
using System.Collections.Generic;
using System.Data;
using Mono.Data.Sqlite;
using UnityEngine;
//----------------------------------------------------------------

namespace DnDPedia.SQLite
{
    public class SQLiteTest : MonoBehaviour
    {
        void Start()
        {
            // Path to the database
            string dbPath = "URI=file:" + Application.dataPath + "/_DnDPedia/Databases/test.db";

            // Start the connection to the database
            IDbConnection dbConnection;
            dbConnection = (IDbConnection) new SqliteConnection(dbPath);

            // Open the connection
            dbConnection.Open();

            // Create the query command
            IDbCommand dbcmd = dbConnection.CreateCommand();
            dbcmd.CommandText = "SELECT string FROM TEST";

            // Reading the result of the query
            IDataReader reader = dbcmd.ExecuteReader();
			while (reader.Read())
			{
                // Get the field
                string value = reader.GetString(0);

                // Print the field
                print("Query result: " + value);
			}

            // Dispose the reader
            reader.Close();
            reader = null;

            // Dìspose the database command
            dbcmd.Dispose();
            dbcmd = null;

            // Dispose the database connection
            dbConnection.Close();
            dbConnection = null;
        }
    }
}
