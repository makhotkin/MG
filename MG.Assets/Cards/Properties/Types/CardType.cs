using System;
using System.Collections.Generic;
using System.Linq;

namespace MG.Assets.Cards.Properties.Types
{
	public class CardType
	{
		private static readonly string[] emptyStringArray = new string[] {};

		private SuperType superType;
		private CoreType coreType;
		private string[] subTypes; // https://mtg.gamepedia.com/Subtype

		public SuperType SuperType => superType;
		public CoreType Type => coreType;


		private String calculatedType; // since obj is immutable, this Is calc'd once

		public CardType(CoreType type, SuperType superType, IEnumerable<string> subTypes = null)
		{
			this.coreType = type;
			this.superType = superType;
			if (subTypes == null)
				this.subTypes = emptyStringArray;
			else if (subTypes is string[])
				this.subTypes = subTypes as string[];
			else {
				this.subTypes = subTypes.ToArray();
				if (this.subTypes.Length == 0)
					this.subTypes = emptyStringArray;
			}
		}

		public bool hasSubType(string type)
		{
			return subTypes.Contains(type);
		}

		public override String ToString()
		{
			return calculatedType ?? (calculatedType = ToStringImpl());
		}

		private String ToStringImpl()
		{
			List<string> types = new List<string>();
			if (superType.HasFlag(SuperType.Basic)) types.Add("Basic");
			if (superType.HasFlag(SuperType.Legendary)) types.Add("Legendary");
			if (superType.HasFlag(SuperType.Snow)) types.Add("Snow");
			if (superType.HasFlag(SuperType.Elite)) types.Add("Elite");
			if (superType.HasFlag(SuperType.World)) types.Add("World");

			if (coreType.HasFlag(CoreType.Tribal)) types.Add("Tribal");
			if (coreType.HasFlag(CoreType.Land)) types.Add("Land");
			if (coreType.HasFlag(CoreType.Creature)) types.Add("Creature");
			if (coreType.HasFlag(CoreType.Artifact)) types.Add("Artifact");
			if (coreType.HasFlag(CoreType.Enchantment)) types.Add("Enchantment");
			if (coreType.HasFlag(CoreType.Planeswalker)) types.Add("Planeswalker");
			if (coreType.HasFlag(CoreType.Instant)) types.Add("Instant");
			if (coreType.HasFlag(CoreType.Sorcery)) types.Add("Sorcery");

			string typesBeforeDash = String.Join(" ", types);

			return subTypes.Any() ? String.Format("{0} — {1}", typesBeforeDash, String.Join(" ", subTypes)) : typesBeforeDash;
		}

		public int CompareTo(CardType other)
		{
			return other == null ? 1 : String.CompareOrdinal(ToString(), other.ToString());
		}

	}
}

