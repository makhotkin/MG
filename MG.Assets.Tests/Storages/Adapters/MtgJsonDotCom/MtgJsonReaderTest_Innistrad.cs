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
	public class MtgJsonReaderTest_Innistrad : MtgJsonReaderTestBase
	{
		private static readonly IPrintedCard[] cards;
		private static readonly ICardEdition edition;

		static MtgJsonReaderTest_Innistrad()
		{
			Dictionary<string, ICardRules> rules = new Dictionary<string, ICardRules>();
			MtgJsonSetReader reader = new MtgJsonSetReader(GetPathForEdition("ISD"), rules);
			cards = reader.Cards.ToArray();
			edition = reader.Edition;
		}

		[TestMethod]
		public void CheckEditionMeta()
		{
			Assert.AreEqual("Innistrad", edition.Name);
			Assert.AreEqual("ISD", edition.Code);
			Assert.AreEqual(EditionType.Expansion, edition.Type);

			Assert.AreEqual(264, cards.Length);
		}

		[TestMethod]
		public void TestCloisteredYouth()
		{
			var printing = cards[7];
			var rules = printing.Rules;
			var face = rules.MainFace;

			Assert.AreEqual(CardRarity.Uncommon, printing.Rarity);
			Assert.AreEqual("ISD", printing.Edition.Code);
			Assert.IsNull(printing.WaterMark);
			Assert.AreEqual("8", printing.CollectorsNumber);

			Assert.AreEqual(SplitType.DoubleFaced, rules.SplitType);
			var nightFace = rules.AltFace;
			Assert.AreEqual(Color.White | Color.Black, rules.ColorIdentity);

			Assert.AreEqual("Cloistered Youth", face.Name);
			Assert.AreEqual("1W", face.ManaCost.ToString());
			Assert.AreEqual("Creature — Human", face.Type.ToString());
			Assert.AreEqual("1", face.Power);
			Assert.AreEqual("1", face.Toughness);
			Assert.IsNull(face.Loyalty);
			Assert.AreEqual(Color.White, face.Color);
			Assert.AreEqual(1, face.OracleText.Count());
			Assert.AreEqual("At the beginning of your upkeep, you may transform Cloistered Youth.", face.OracleText.First());

			Assert.AreEqual("Unholy Fiend", nightFace.Name);
			Assert.IsTrue(nightFace.ManaCost.HasNoCost);
			Assert.AreEqual("Creature — Horror", nightFace.Type.ToString());
			Assert.AreEqual("3", nightFace.Power);
			Assert.AreEqual("3", nightFace.Toughness);
			Assert.IsNull(nightFace.Loyalty);
			Assert.AreEqual(Color.Black, nightFace.Color);
			Assert.AreEqual(1, nightFace.OracleText.Count());
			Assert.AreEqual("At the beginning of your end step, you lose 1 life.", nightFace.OracleText.First());
		}

		[TestMethod]
		public void TestGarrukRelentless()
		{
			var printing = cards[180];
			var rules = printing.Rules;
			var face = rules.MainFace;

			Assert.AreEqual(CardRarity.MythicRare, printing.Rarity);
			Assert.AreEqual("ISD", printing.Edition.Code);
			Assert.IsNull(printing.WaterMark);
			Assert.AreEqual("181", printing.CollectorsNumber);

			Assert.AreEqual(SplitType.DoubleFaced, rules.SplitType);
			var nightFace = rules.AltFace;
			Assert.AreEqual(Color.Green | Color.Black, rules.ColorIdentity);

			Assert.AreEqual("Garruk Relentless", face.Name);
			Assert.AreEqual("3G", face.ManaCost.ToString());
			Assert.AreEqual("Legendary Planeswalker — Garruk", face.Type.ToString());
			Assert.IsNull(face.Power);
			Assert.IsNull(face.Toughness);
			Assert.AreEqual("3", face.Loyalty);

			Assert.AreEqual(Color.Green, face.Color);
			Assert.AreEqual(3, face.OracleText.Count());

			Assert.AreEqual("Garruk, the Veil-Cursed", nightFace.Name);
			Assert.IsTrue(nightFace.ManaCost.HasNoCost);
			Assert.AreEqual("Legendary Planeswalker — Garruk", nightFace.Type.ToString());
			Assert.IsNull(nightFace.Power);
			Assert.IsNull(nightFace.Toughness);
			Assert.IsNull(nightFace.Loyalty);
			Assert.AreEqual(Color.Black | Color.Green, nightFace.Color);
			Assert.AreEqual(3, nightFace.OracleText.Count());
		}

	}
}
