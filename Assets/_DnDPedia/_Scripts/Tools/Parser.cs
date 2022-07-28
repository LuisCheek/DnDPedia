//----------------------------------------------------------------
// @Description: A parser tool to convert json to spells and spells to json.
// 
// @Author: Luis Betancourt
// 
// @Date: 24/07/2022
// 
// @Copyright (c) 2022 D&DPedia
//----------------------------------------------------------------

//--Namespaces----------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using Newtonsoft.Json;

using static DnDPedia.Tools.Errors;
using static DnDPedia.Tools.GlobalErrorCodes;
//----------------------------------------------------------------

namespace DnDPedia.Tools
{
	public static class Parser
    {
        /// <summary>
        /// Deserialize a json into a spell.
        /// </summary>
        /// <param name="json">The json representation of the spell.</param>
        /// <returns>A spell object populate with the json values.</returns>
        public static List<Spell> JsonToSpells(string json)=> JsonConvert.DeserializeObject<List<Spell>>(json);

        /// <summary>
        /// Serialize a spell into a json.
        /// </summary>
        /// <param name="spell">The spell object to convert.</param>
        /// <returns>A string that is the json representation of the spell object.</returns>
        public static string SpellsToJson(List<Spell> spells) => JsonConvert.SerializeObject(spells);

        /// <summary>
        /// Extract an array of field names and an array of field values from the given spell and
        /// parse them to their equivalent values in a SQLite INSERT command.
        /// </summary>
        /// <param name="spell">The spell object that is going to be insert into the database.</param>
        /// <returns>
        /// A string array of two positions. The first one contains the fields of the spell,
        /// the second one contains the values of the spell fields parsed in a format 
        /// that can be use in a SQLite INSERT command.
        /// </returns>
        public static string[] SpellToSQL(Spell spell)
        {
            string[] fieldsAndValues = new string[2];

            string fields = "";
            string values = "";

            try
            {
                // Loop through all spell attributes in order
                foreach (var field in spell.GetType().GetFields().OrderBy(field => field.MetadataToken))
                {   
                    // The value of the field
                    string value = "";

                    // Format every value to be compatible with a SQL INSERT command

                    // String fields must be between two " chars
                    if (field.FieldType == typeof(string))
                        value = String.Format(@"""{0}""", (string) field.GetValue(spell));

                    // Integer fields must be in string format
                    else if (field.FieldType == typeof(int))
                        value = field.GetValue(spell).ToString();

                    // Boolean fields must be 1 for true and 0 for false
                    else if (field.FieldType == typeof(bool))
                        value = (bool) field.GetValue(spell) ? "1" : "0";

                    // Enumerable fields must be in string format between two " chars
                    else if (field.FieldType.IsEnum)
                        value = String.Format(@"""{0}""", field.GetValue(spell).ToString());

                    // List fields should be parsed based on the type of the elements it contains
                    else if (field.FieldType.IsGenericType && field.FieldType.GetGenericTypeDefinition() == typeof(List<>))
                    {
                        // Gets the list of objects
                        IEnumerable auxList = (IEnumerable) field.GetValue(spell);

                        // Loop through the elements of the list
                        foreach (var element in auxList)
                        {
                            //If the element is an enumerate
                            if (element is Enum)
                                value += element.ToString() + "; "; //i.e.: "Artificer; Cleric;"

                            //If the element is a boolean
                            else if (element.GetType() == typeof(bool))
                                value += (bool) element ? "1; " : "0; ";

                            //Otherwise (string, integer)
                            else
                                value += element.ToString() + "; ";
                        }

                        // Removing the last "; " of the string
                        value = value[0..^2];

                        // Formatting the string to be store correctly (between two " chars)
                        value = String.Format(@"""{0}""", value); //i.e: "Artificer; Cleric"
                    }
                    // Unsupported data type found
                    else
                        throw new Exception(String.Format("Spell field {0} contains a not expected value: {1}", field.Name, field.GetValue(spell).ToString()));

                    fields += field.Name + ", ";
                    values += value + ", ";
                }
            }
            catch (Exception e)
            {
                PushError(TPAUVF, "Unexpected value found during parsing: " + e.ToString());
            }

            // Removing last ", " characters from both strings
            fields = fields[0..^2];
            values = values[0..^2];

            fieldsAndValues[0] = fields;
            fieldsAndValues[1] = values;

            return fieldsAndValues;
        }
    }
}
