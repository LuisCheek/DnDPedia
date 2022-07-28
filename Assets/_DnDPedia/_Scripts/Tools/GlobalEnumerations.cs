//----------------------------------------------------------------
// @Description: All the global enumerators of the application.
// 
// @Author: Luis Betancourt
// 
// @Date: 23/07/2022
// 
// @Copyright (c) 2022 D&DPedia
//----------------------------------------------------------------

//--Namespaces----------------------------------------------------
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
//----------------------------------------------------------------

namespace DnDPedia.Tools
{
	public struct GlobalEnumerations
    {
		//All spellcaster classes
		[JsonConverter(typeof(StringEnumConverter))]
		public enum Classes
		{
			Artificer,
			Bard,
			Cleric,
			Druid,
			Paladin,
			Ranger,
			Sorcerer,
			Warlock,
			Wizard
		}

		//All magic schools
		[JsonConverter(typeof(StringEnumConverter))]
		public enum Schools
		{
			Abjuration,
			Conjuration,
			Divination,
			Enchantment,
			Evocation,
			Illusion,
			Necromancy,
			Transmutation
		}

		//All types of spell effect area
		[JsonConverter(typeof(StringEnumConverter))]
		public enum Areas
		{
			None,
			Cone,
			Cube,
			Cylinder,
			Line,
			Sphere
		}

		//All types of damage
		[JsonConverter(typeof(StringEnumConverter))]
		public enum DamageTypes
		{
			None,
			Acid,
			Bludgeoning,
			Cold,
			Fire,
			Force,
			Lightning,
			Necrotic,
			Piercing,
			Poison,
			Psychic,
			Radiant,
			Slashing,
			Thunder
		}

		//All types of save rolls
		[JsonConverter(typeof(StringEnumConverter))]
		public enum SaveTypes
		{
			None,
			Strength,
			Dexterity,
			Constitution,
			Intelligence,
			Wisdom,
			Charisma
		}

		//All possible conditions
		[JsonConverter(typeof(StringEnumConverter))]
		public enum Conditions
		{
			None,
			Blinded,
			Charmed,
			Deafened,
			Exhaustion,
			Frightened,
			Grappled,
			Incapacitated,
			Invisible,
			Paralyzed,
			Petrified,
			Poisoned,
			Prone,
			Restrained,
			Stunned,
			Unconscious
		}

		//Extra filters
		[JsonConverter(typeof(StringEnumConverter))]
		public enum Tags
		{
			Appearance,
			Banishment,
			Buff,
			Communication,
			Creation,
			Damage,
			Debuff,
			Defensive,
			Detection,
			Healing,
			Movement,
			Social,
			Summon,
			Utility
		}
	}
}
