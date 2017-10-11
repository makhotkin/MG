using MG.Assets.Cards.Properties;

namespace MG.Assets.Cards
{
	public class CardRules : ICardRules
	{
		public SplitType SplitType { get; set; }
		public ICardFace MainFace { get; set; }
		public ICardFace AltFace { get; set; }

		public Color ColorIdentity { get; set; }

		public int ConvertedManaCost { get {
				// to be improved for split cards
			return MainFace.ManaCost.ConvertedManaCost;
		}}
	}
}
