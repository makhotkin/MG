using System;

namespace MG.Assets.Cards.Properties.Types
{
	[Flags]
	public enum CardType : short
	{
		Land,
		Creature,
		Artifact,
		Enchantment,
		Planeswalker,
		Instant,
		Sorcery,

		Conspiracy,
		Phenomenon,
		Plane,
		Scheme,
		Tribal,
		Vanguard
	}
}

