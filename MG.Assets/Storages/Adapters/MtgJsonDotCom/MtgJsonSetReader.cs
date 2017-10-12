using MG.Assets.Cards;
using MG.Assets.Editions;
using System.Collections.Generic;
using System;
using Newtonsoft.Json.Linq;
using System.IO;
using Newtonsoft.Json;
using MG.Assets.Cards.Properties;
using MG.Assets.Cards.Properties.ManaCosts;

namespace MG.Assets.Storages.Adapters.MtgJsonDotCom
{
	public class MtgJsonSetReader
	{
		private List<IPrintedCard> cards;

		public IEnumerable<IPrintedCard> Cards { get => cards; }
		private CardEdition edition = new CardEdition();
		public ICardEdition Edition { get => edition; }

		public MtgJsonSetReader(string fileName, IDictionary<string, ICardRules> existingRules)
		{
			using (StreamReader file = File.OpenText(fileName))
			using (JsonTextReader reader = new JsonTextReader(file))
			{
				JObject o2 = (JObject)JToken.ReadFrom(reader);
				edition = ReadEdition(o2);

				var jcards = o2["cards"] as JArray;
				cards = new List<IPrintedCard>();
				foreach(JObject c in jcards)
				{
					PrintedCard card = ReadPrinting(c, existingRules);
					card.Edition = edition;
					cards.Add(card);
				}

				edition.NominalCardCount = cards.Count;
			}
		}

		private static PrintedCard ReadPrinting(JObject c, IDictionary<string, ICardRules> existingRules)
		{
			PrintedCard card = new PrintedCard();
			card.Name = c["name"].Value<string>();
			card.Rarity =  ParseRarity(c["rarity"].Value<string>());
			card.CollectorsNumber = c["number"].Value<string>();
			card.Artist = c["artist"].Value<string>();

			if (!existingRules.TryGetValue(card.Name, out ICardRules rules))
				existingRules.Add(card.Name, rules = ReadRules(card.Name, c));
			card.Rules = rules;
			return card;
		}

		private static CardRules ReadRules(string name, JObject c)
		{
			CardRules rules = new CardRules();
			rules.SplitType = parseSplitType(c["layout"].Value<string>());
			if(c.TryGetValue("colorIdentity", out JToken jt))
				rules.ColorIdentity = parseColorIdentity(jt.Values<string>());
			if (rules.SplitType == SplitType.None)
				rules.MainFace = ReadCardFace(name, c);

			else
				throw new NotImplementedException("Reading split cards");
			return rules;
		}

		private static readonly string[] rulesSeparators = new string[] { "\\n" };
		private static readonly string[] emptyArray = new string[] { };
		private static ICardFace ReadCardFace(string name, JObject c)
		{
			string[] rules = emptyArray;
			if (c.TryGetValue("text", out JToken jText))
				rules = jText.Value<string>().Split(rulesSeparators, StringSplitOptions.None);
			CardFace face = new CardFace(name, rules);

			if (c.TryGetValue("manaCost", out JToken jManaCost))
				face.ManaCost = ManaCost.Parse(jManaCost.Value<string>());
			return face;
		}

		private static Color parseColorIdentity(IEnumerable<string> identity)
		{
			Color result = Color.Colorless;
			foreach (var c in identity)
			{
				switch (c)
				{
					case "W": case "w": result |= Color.White; break;
					case "U": case "u": result |= Color.Blue; break;
					case "B": case "b": result |= Color.Black; break;
					case "R": case "r": result |= Color.Red; break;
					case "G": case "g": result |= Color.Green; break;
					default: throw new ArgumentException("Cannot parse color: " + c);
				}
			}
			return result;
		}

		private static SplitType parseSplitType(string layout)
		{
			if (String.Equals(layout, "normal"))
				return SplitType.None;
			throw new NotImplementedException("Parse split cards layout");
		}

		private static CardRarity ParseRarity(string rarity)
		{
			if (String.Equals("Common", rarity, StringComparison.OrdinalIgnoreCase))
				return CardRarity.Common;
			if (String.Equals("Uncommon", rarity, StringComparison.OrdinalIgnoreCase))
				return CardRarity.Uncommon;
			if (String.Equals("Rare", rarity, StringComparison.OrdinalIgnoreCase))
				return CardRarity.Rare;
			if (String.Equals("Basic Land", rarity, StringComparison.OrdinalIgnoreCase))
				return CardRarity.Common;
			if (String.Equals("Mythic Rare", rarity, StringComparison.OrdinalIgnoreCase))
				return CardRarity.MythicRare;
			if (String.Equals("Masterpiece", rarity, StringComparison.OrdinalIgnoreCase))
				return CardRarity.Masterpiece;
			throw new ArgumentException("Could not parse the rarity value: " + rarity);
		}

		private static CardEdition ReadEdition(JObject o2)
		{
			CardEdition edition = new CardEdition();
			edition.Border = BorderColor.Black;
			edition.Code = o2["code"].Value<string>();
			edition.Name = o2["name"].Value<string>();
			edition.ReleaseDate = DateTime.Parse(o2["releaseDate"].Value<string>());
			if (Enum.TryParse(o2["type"].Value<string>(), true, out EditionType et))
				edition.Type = et;
			return edition;
		}
	}
}
