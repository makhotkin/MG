using Microsoft.VisualStudio.TestTools.UnitTesting;
using MG.Assets.Storages.Adapters.MtgJsonDotCom;
using System.Collections.Generic;
using MG.Assets.Cards;
using System.Linq;
using MG.Assets.Editions;
using MG.Assets.Cards.Properties;

namespace MG.Assets.Tests
{
	[TestClass]
	public class MtgJsonReaderTest_M10 : MtgJsonReaderTestBase
	{
		private static readonly IPrintedCard[] cards;
		private static readonly ICardEdition edition;

		static MtgJsonReaderTest_M10() {
			Dictionary<string, ICardRules> rules = new Dictionary<string, ICardRules>();
			MtgJsonSetReader reader = new MtgJsonSetReader(GetPathForEdition("M10"), rules);
			cards = reader.Cards.ToArray();
			edition = reader.Edition;
		}

		[TestMethod]
		public void CheckEditionMeta()
		{
			Assert.AreEqual("Magic 2010", edition.Name);
			Assert.AreEqual("M10", edition.Code);
			Assert.AreEqual(EditionType.Core, edition.Type);

			Assert.AreEqual(249, cards.Length);
		}

		[TestMethod]
		public void TestAjaniGoldmane()
		{
			var printing = cards[0];
			var rules = printing.Rules;
			var face = rules.MainFace;

			Assert.AreEqual(CardRarity.MythicRare, printing.Rarity);
			Assert.AreEqual("M10", printing.Edition.Code);
			Assert.IsNull(printing.WaterMark);
			Assert.AreEqual("1", printing.CollectorsNumber);

			Assert.IsNull(rules.AltFace);
			Assert.AreEqual(SplitType.None, rules.SplitType);
			Assert.AreEqual(Color.White, rules.ColorIdentity);

			Assert.AreEqual("Ajani Goldmane", face.Name);
			Assert.AreEqual("2WW", face.ManaCost.ToString());
			Assert.AreEqual("Legendary Planeswalker — Ajani", face.Type.ToString());
			Assert.IsNull(face.Power);
			Assert.IsNull(face.Toughness);
			Assert.AreEqual("4", face.Loyalty);
			Assert.AreEqual(Color.White, face.Color);
			Assert.AreEqual("+1: You gain 2 life.", face.OracleText.First());
			Assert.AreEqual("−1: Put a +1/+1 counter on each creature you control. Those creatures gain vigilance until end of turn.", face.OracleText.ElementAt(1));
			Assert.AreEqual("−6: Create a white Avatar creature token. It has \"This creature's power and toughness are each equal to your life total.\"", face.OracleText.ElementAt(2));
		}

		[TestMethod]
		public void TestRodOfRuin()
		{
			var printing = cards[218];
			var rules = printing.Rules;
			var face = rules.MainFace;

			Assert.AreEqual(CardRarity.Uncommon, printing.Rarity);
			Assert.AreEqual("M10", printing.Edition.Code);
			Assert.IsNull(printing.WaterMark);
			Assert.AreEqual("219", printing.CollectorsNumber);

			Assert.AreEqual("Rod of Ruin", face.Name);
			Assert.AreEqual("4", face.ManaCost.ToString());
			Assert.AreEqual("Artifact", face.Type.ToString());
			Assert.IsNull(face.Power);
			Assert.IsNull(face.Toughness);
			Assert.IsNull(face.Loyalty);
			Assert.AreEqual(Color.Colorless, face.Color);
			Assert.AreEqual(1, face.OracleText.Count());
			Assert.AreEqual("{3}, {T}: Rod of Ruin deals 1 damage to target creature or player.", face.OracleText.First());
		}

		[TestMethod]
		public void TestProteanHydra()
		{
			var printing = cards[199];
			var rules = printing.Rules;
			var face = rules.MainFace;

			Assert.AreEqual(CardRarity.MythicRare, printing.Rarity);
			Assert.AreEqual("M10", printing.Edition.Code);
			Assert.IsNull(printing.WaterMark);
			Assert.AreEqual("200", printing.CollectorsNumber);

			Assert.AreEqual(Color.Green, rules.ColorIdentity);

			Assert.AreEqual("Protean Hydra", face.Name);
			Assert.AreEqual("XG", face.ManaCost.ToString());
			Assert.AreEqual("Creature — Hydra", face.Type.ToString());
			Assert.AreEqual("0", face.Power);
			Assert.AreEqual("0", face.Toughness);
			Assert.IsNull(face.Loyalty);
			Assert.AreEqual(Color.Green, face.Color);
			Assert.AreEqual(3, face.OracleText.Count());
			Assert.AreEqual("Protean Hydra enters the battlefield with X +1/+1 counters on it.", face.OracleText.First());
			Assert.AreEqual("If damage would be dealt to Protean Hydra, prevent that damage and remove that many +1/+1 counters from it.", face.OracleText.ElementAt(1));
			Assert.AreEqual("Whenever a +1/+1 counter is removed from Protean Hydra, put two +1/+1 counters on it at the beginning of the next end step.", face.OracleText.ElementAt(2));
		}
	}
}

