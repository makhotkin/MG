using MG.Assets.Cards.Properties;
using MG.Assets.Cards.Properties.ManaCosts;
using MG.Assets.Cards.Properties.Types;
using System;
using System.Collections.Generic;

namespace MG.Assets.Cards
{
	public class CardFace : ICardFace
	{
		string name;
		public CardFace(string name, string[] oracleText)
		{
			this.name = name;
			this.oracleText = oracleText;
			ManaCost = ManaCost.NoCost;
		}

		public string Name => name;
		public CardType Type { get; set; }
		public Color Color { get; set; }
		public ManaCost ManaCost { get; set; }

		private readonly String[] oracleText;
		public IEnumerable<string> OracleText => oracleText;

		public string Power { get; set; }
		public string Toughness { get; set; }
		public string Loyalty { get; set; }
	}
}
