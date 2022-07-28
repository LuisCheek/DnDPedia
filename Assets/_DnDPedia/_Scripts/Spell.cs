//----------------------------------------------------------------
// @Description: This class represents a spell. It is used to work internally.
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
using System.Linq;

using static DnDPedia.Tools.GlobalEnumerations;
//----------------------------------------------------------------

namespace DnDPedia
{
	[System.Serializable]
    public class Spell
    {
		public string name;
		public string source;
		public int level;
		public Schools school;
		public List<Classes> classes;
		public bool verbal;
		public bool somatic;
		public bool material;
		public string materials;
		public string time;
		public Areas area;
		public int range;
		public string duration;
		public bool concentration;
		public bool ritual;
		public string spell;
		public bool attack;
		public List<DamageTypes> damage;
		public bool save;
		public SaveTypes saveType;
		public bool higherLevels;
		public List<Conditions> conditions;
		public List<Tags> tags;

		/// <summary>
		/// Etablish the printing format for a spell object.
		/// </summary>
		/// <returns>The fields and values of the Spell object in a single string.</returns>
		public override string ToString()
		{
			string spellData = "";

			// Loop through all class attributes in order
			foreach (var field in this.GetType().GetFields().OrderBy(field => field.MetadataToken))
			{
				// When the attribute is a list it requeres extra steps
				if (field.FieldType.IsGenericType && field.FieldType.GetGenericTypeDefinition() == typeof(List<>))
				{
					IEnumerable auxList = (IEnumerable) field.GetValue(this);
					string listValues = "";

					foreach (var element in auxList)
						listValues += element.ToString() + "; ";

					// Removing the last "; " of the list of values
					listValues = listValues[0..^2];

					spellData += field.Name + ":" + listValues + ", ";

					// Jump to the next field
					continue;
				}

				spellData += field.Name + ":" + field.GetValue(this) + ", ";
			}

			// Removing the last ", " of the string
			spellData = spellData[0..^2];

			return spellData;
		}
	}
}
