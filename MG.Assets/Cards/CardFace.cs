using MG.Assets.Cards.Properties;
using MG.Assets.Cards.Properties.ManaCost;
using MG.Assets.Cards.Properties.Types;
using System.Collections.Generic;

namespace MG.Assets.Cards
{
	public class CardFace : ICardFace
	{
		public CardFullType Type => throw new System.NotImplementedException();

		public Color Color => throw new System.NotImplementedException();

		public string Name => throw new System.NotImplementedException();

		public ManaCost ManaCost => throw new System.NotImplementedException();

		public IEnumerable<string> OracleText => throw new System.NotImplementedException();

		public string PowerToughnessLoyalty => throw new System.NotImplementedException();
	}
}
