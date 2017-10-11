using MG.Assets.Cards.Properties;

namespace MG.Assets.Cards
{
	public interface ICardRules
	{
		SplitType SplitType { get; set; }
		ICardFace MainFace { get; set; }
		ICardFace AltFace { get; set; }

		Color ColorIdentity { get; }
		int ConvertedManaCost { get; }
		//int Power { get; }
		//int Toughness { get; }
		//int Loyalty { get; }
	}
}
