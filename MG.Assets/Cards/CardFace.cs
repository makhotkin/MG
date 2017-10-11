using MG.Assets.Cards.Properties;
using MG.Assets.Cards.Properties.ManaCost;
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
		}

		public string Name => name;
		public CardFullType Type { get; set; }
		public Color Color { get; set; }
		public ManaCost ManaCost { get; set; }
		private readonly String[] oracleText;
		public IEnumerable<string> OracleText => oracleText;
		public string PowerToughnessLoyalty { get; set; }
	}
}
