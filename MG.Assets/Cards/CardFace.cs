using MG.Assets.Cards.Properties;
using MG.Assets.Cards.Properties.ManaCosts;
using MG.Assets.Cards.Properties.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace MG.Assets.Cards
{
	public class CardFace : ICardFace
	{
		public CardFace(string name, string[] oracleText)
		{
			this.name = name;
			this.oracleText = oracleText;
			ManaCost = ManaCost.NoCost;
		}

		private readonly string name;
		public string Name => name;
		public CardType Type { get; set; }
		public Color Color { get; set; }
		public ManaCost ManaCost { get; set; }

		private readonly String[] oracleText;
		public IEnumerable<string> OracleText => oracleText;

		public string Power { get; set; }
		public string Toughness { get; set; }
		public string Loyalty { get; set; }

		public override string ToString()
		{
			StringBuilder res = new StringBuilder(name);
			if (!ManaCost.HasNoCost)
				res.Append(" | ").Append(ManaCost.ToString());
			res.Append(" | ").Append(Type.ToString());
			if (Power != null && Toughness != null)
				res.Append(" | ").Append(Power.ToString()).Append("/").Append(Toughness.ToString());
			if (Loyalty != null)
				res.Append(" | L=").Append(Loyalty.ToString());
			int len0 = oracleText.Length > 0 ? oracleText[0].Length : 0;
			switch (oracleText.Length)
			{
				case 0: break;
				case 1: res.Append(" | ").Append(len0 > 30 ? oracleText[0].Substring(0, 30) + "…" : oracleText[0]); break;
				default: res.Append(" | ").Append(len0 > 30 ? oracleText[0].Substring(0, 30) + "…" : oracleText[0]).Append(" +").Append(oracleText.Length - 1).Append(" more"); break;
			}
			return res.ToString();
		}
	}
}
