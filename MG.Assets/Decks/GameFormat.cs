using System;

namespace MG.Assets.Decks
{
	[Flags]
	public enum GameFormat : ushort
	{
		Constructed = 0x1000,
		Limited = 0x2000,
		Draft = 0x3000,
		Commander = 0x4000,
		Archenemy = 0x5000,
		Vanguard = 0x6000,
		Planechase = 0x7000,
		Conspiracy = 0x8000,


		Standard = 0x1,
		Extended = 0x2,
		Block = 0x3,
		Modern = 0x4,
		Legacy = 0x5,
		Vintage = 0x6,
		
		Pauper = 0x10,
	}
}