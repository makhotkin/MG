using System.Collections.Generic;

namespace MG.Assets.Cards.Properties.Types
{
	public static class CardTypeExtensions
	{
		public static string TypeToString(this CardType coreType)
		{
			List<string> types = new List<string>();
			if (coreType.HasFlag(CardType.Tribal)) types.Add("Tribal");
			if (coreType.HasFlag(CardType.Land)) types.Add("Land");
			if (coreType.HasFlag(CardType.Creature)) types.Add("Creature");
			if (coreType.HasFlag(CardType.Artifact)) types.Add("Artifact");
			if (coreType.HasFlag(CardType.Enchantment)) types.Add("Enchantment");
			if (coreType.HasFlag(CardType.Planeswalker)) types.Add("Planeswalker");
			if (coreType.HasFlag(CardType.Instant)) types.Add("Instant");
			if (coreType.HasFlag(CardType.Sorcery)) types.Add("Sorcery");
			return string.Join(" ", types);
		}

		public static string TypeToString(this SuperType superType)
		{
			List<string> types = new List<string>();
			if (superType.HasFlag(SuperType.Basic)) types.Add("Basic");
			if (superType.HasFlag(SuperType.Legendary)) types.Add("Legendary");
			if (superType.HasFlag(SuperType.Snow)) types.Add("Snow");
			if (superType.HasFlag(SuperType.Elite)) types.Add("Elite");
			if (superType.HasFlag(SuperType.World)) types.Add("World");
			return string.Join(" ", types);
		}
	}
}

