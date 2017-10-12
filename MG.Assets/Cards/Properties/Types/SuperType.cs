using System;

namespace MG.Assets.Cards.Properties.Types
{
	[Flags]
	public enum SuperType : byte
	{
		Basic = 1,
		Legendary = 2,
		Snow = 4,
		World = 8,

		Ongoing = 64, // for Schemas
		Elite = 128,  // from Theros
	}
}


