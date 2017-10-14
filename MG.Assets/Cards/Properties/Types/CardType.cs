using System;

namespace MG.Assets.Cards.Properties.Types
{
	[Flags]
	public enum CardType : short
	{
		Land = 1,
		Creature = 2,
		Artifact = 4,
		Enchantment = 8,
		Planeswalker = 16,
		Instant = 32,
		Sorcery = 64,

		Conspiracy = 0x100,
		Phenomenon = 0x200,
		Plane = 0x400,
		Scheme = 0x800,
		Tribal = 0x1000,
		Vanguard = 0x2000
	}
}

