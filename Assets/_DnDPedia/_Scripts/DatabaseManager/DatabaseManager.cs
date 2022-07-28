//----------------------------------------------------------------
// @Description: A manager class to execute all the database operations
// from the Unity Editor.
// 
// @Author: Luis Betancourt
// 
// @Date: 24/07/2022
// 
// @Copyright (c) 2022 D&DPedia
//----------------------------------------------------------------

//--Namespaces----------------------------------------------------
using System.Collections.Generic;
using System.Data;
using System.IO;

using Mono.Data.Sqlite;

using UnityEngine;

using static DnDPedia.Tools.Errors;
using static DnDPedia.Tools.Parser;
using static DnDPedia.Tools.GlobalConstants;
using static DnDPedia.Tools.GlobalErrorCodes;
//----------------------------------------------------------------

namespace DnDPedia.DatabaseManager
{
	public class DatabaseManager : MonoBehaviour
    {
		// Database connection object
		private IDbConnection dbConnection;
	
        private List<List<Spell>> spellBooks = new List<List<Spell>>();
		
		// SQLite objects to manage the database
		private Inserter inserter;
		private Deleter deleter;
		private Reader reader;

		private void Start()
		{
			// Create the dabase connection
			dbConnection = new SqliteConnection("URI=file:" + Application.dataPath + DATABASE_PATH);

			// Set the connection to the objects
			inserter = new Inserter(dbConnection);
			deleter = new Deleter(dbConnection);
			reader = new Reader(dbConnection);
		}

		/// <summary>
		/// Create the database connection objecto to the SpellDB database.
		/// </summary>
		public void InitializeConnection()
		{
			// Open the connection
			dbConnection.Open();

			// TODO: Put this information in the log.
			#if UNITY_EDITOR
				Debug.Log("Connection to database openAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA.");
			#endif
		}

		/// <summary>
		/// Dispose the database connection object.
		/// </summary>
		public void CloseConnection()
		{
			dbConnection.Close();

			// TODO: Put this information in the log.
			#if UNITY_EDITOR
				Debug.Log("Connection to database closed.");
			#endif
		}

		/// <summary>
		/// Create the SPELLS table in the database 
		/// using the text file that contains the command line to create it.
		/// </summary>
		public void CreateSpellTable()
		{
			if (dbConnection.State.ToString().Equals("Open"))
			{
				// Create the SPELLS table
				inserter.CreateTable(SPELLS_TABLE_PATH);

				// TODO: this message covers the sqlite exception raised just before
				#if UNITY_EDITOR
					Debug.Log("SPELLS table created.");
				#endif

			}else
			{
				PushError(DDMCNO, "Error: Database connection is not open.");
			}
		}

		/// <summary>
		/// Create the SOURCES table in the database 
		/// using the text file that contains the command line to create it.
		/// </summary>
		public void CreateSourcesTable()
		{
			// Create the SOURCES table
			inserter.CreateTable(SOURCES_TABLE_PATH);

			#if UNITY_EDITOR
				Debug.Log("SOURCES table created.");
			#endif
		}

		/// <summary>
		/// Create a list of lists of spells from several json files. 
		/// A json file in this context represents a sourcebook, so every json contains 
		/// all the spells of a book. This function stores them in a list of spells, 
		/// and then, store this list in a list o spellbooks.
		/// </summary>
		public void CreateSpellBooks()
		{
			// Search for all *.json in the path
            foreach (string file in Directory.GetFiles(Application.dataPath + JSON_SPELL_BOOKS, "*.json"))
			{
				try
				{
					// Create a list for the spells of each json file
					List<Spell> spellBook = new List<Spell>();

					// Opening the json file
					StreamReader reader = new StreamReader(file);
					
					// Deserialize the json to a lsit of spells
					spellBook = JsonToSpells(reader.ReadToEnd());

					// Storing the spellbook into the list of spellbooks
					spellBooks.Add(spellBook);

					// Closing the file
					reader.Close();
				}
				catch(IOException e)
				{
					// Push error into the stack
					PushError(DDMOSJ, "Error opening a json file: " + e.ToString());
				}
			}

			// TODO: Put this information in the log.
			#if UNITY_EDITOR
				Debug.Log("SpellBooks created.");
			#endif
		}

		/// <summary>
		/// Insert all SpellBooks into the database.
		/// </summary>
		public void InsertSpellBooks()
		{
			foreach(List<Spell> spellBook in spellBooks)
			{
				foreach(Spell spell in spellBook)
				{
					// Get the fields and values from the spell object
					string[] spellData = SpellToSQL(spell);

					// Insert the spell into the SPELLS table from the database
					inserter.Insert(SPELLS_TABLE, spellData[0], spellData[1]);
				}
			}

			// TODO: Put this information in the log.
			#if UNITY_EDITOR
				Debug.Log("SpellBooks inserted.");
			#endif
		}

		/// <summary>
		/// Call the deleter object to delete all the entries from the spells table in the database.
		/// </summary>
		public void DeleteAllSpellsFromDatabase()
		{
			deleter.DeleteTable(SPELLS_TABLE);

			// TODO: Put this information in the log.
			#if UNITY_EDITOR
				Debug.Log("All spells deleted from database.");
			#endif
		}

		/// <summary>
		/// Call the deleter object to delete all the entries from the sources table in the database.
		/// </summary>
		public void DeleteAllSourcesFromDatabase()
		{
			deleter.DeleteTable(SOURCES_TABLE);

			// TODO: Put this information in the log.
			#if UNITY_EDITOR
				Debug.Log("All sources deleted from database.");
			#endif
		}

		/// <summary>
		/// Call the deleter object to erase the Spells table from the database scheme.
		/// </summary>
		public void DropSpellsTableFromDatabase()
		{
			// Drop the SPELLS table
			deleter.DropTable(SPELLS_TABLE);

			// TODO: Put this information in the log.
			#if UNITY_EDITOR
				Debug.Log("Spells table dropped from the database.");
			#endif
		}

		/// <summary>
		/// Call the deleter object to erase the Sources table from the database scheme.
		/// </summary>
		public void DropSourcesTableFromDatabase()
		{
			// Drop the SPELLS table
			deleter.DropTable(SOURCES_TABLE);

			// TODO: Put this information in the log.
			#if UNITY_EDITOR
				Debug.Log("Sources table dropped from the database.");
			#endif
		}

		/// <summary>
		/// Call the deleter object to vacuum the free space from the database.
		/// </summary>
		public void VacuumDatabase()
		{
			deleter.VacuumDB();

			// TODO: Put this information in the log.
			#if UNITY_EDITOR
				Debug.Log("Vacuum done.");
			#endif
		}
	}
}
