using System;

namespace MG.Assets.Cards.Properties.ManaCosts
{
	[Flags]
	public enum ManaCostAtom : short
	{
		White = Color.White,
		Blue = Color.Blue,
		Black = Color.Black,
		Red = Color.Red,
		Green = Color.Green,

		Colorless = 32,
		Generic = 64,

		Or2Mana = 0x100,
		Phyrexian = 0x200,

		IsX = 0x1000,
	}
}

