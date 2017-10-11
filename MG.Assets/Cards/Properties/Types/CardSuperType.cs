using System;

namespace MG.Assets.Cards.Properties.Types
{
	[Flags]
	public enum CardSuperType : byte
	{
		Basic,
		Legendary,
		Snow,
		World,

		Ongoing, // for Schemas
		Elite,  // from Theros
	}
}


