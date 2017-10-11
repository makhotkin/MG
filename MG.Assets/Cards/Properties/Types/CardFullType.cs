using System.Linq;

namespace MG.Assets.Cards.Properties.Types
{
	public class CardFullType
	{
		private CardSuperType SuperType;
		private CardType Type;
		private string[] SubTypes; // https://mtg.gamepedia.com/Subtype

		public bool hasType(CardType type)
		{
			return Type.HasFlag(type);
		}

		public bool hasSuperType(CardSuperType type)
		{
			return SuperType.HasFlag(type);
		}

		public bool hasSubType(string type)
		{
			return SubTypes.Contains(type);
		}
	}
}

