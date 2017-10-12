using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;
using MG.Assets.Database;
using MG.Assets.Cards.Properties;
using System.Linq;

namespace MG.Assets.Tests.Storages
{
	[TestClass]
	public class CardDatabaseTests
	{

		static readonly ICardDatabase db = StaticData.CardDbBlockM10;

		[TestMethod]
		public void Fetch_Forest_M10()
		{
			var c = db.CardByName("Forest", "M10");

			Assert.AreEqual("M10", c.Edition.Code);
			Assert.AreEqual(CardRarity.Common, c.Rarity);
		}

		[TestMethod]
		public void Fetch_ForestsFromLatestSet_Roe()
		{
			var c = db.CardsByName("Forest", 10).ToArray();

			Assert.IsTrue(c.All(x => x.Edition.Code == "ROE"));
			Assert.IsTrue(c.All(x => x.CollectorsNumber.CompareTo("245") >= 0 && x.CollectorsNumber.CompareTo("248") <= 0 ));
		}

		[TestMethod]
		public void Fetch_ZendikarFarguide()
		{
			var c = db.CardByName("Zendikar Farguide");

			Assert.AreEqual("ZEN", c.Edition.Code);
			Assert.AreEqual(CardRarity.Common, c.Rarity);
			Assert.AreEqual("4G", c.Rules.MainFace.ManaCost.ToString());
			Assert.AreEqual("Creature — Elemental", c.Rules.MainFace.Type.ToString());
		}

		[TestMethod]
		public void Fetch_RoilingTerraine()
		{
			var c = db.CardByName("Roiling Terrain");

			Assert.AreEqual("WWK", c.Edition.Code);
			Assert.AreEqual(CardRarity.Common, c.Rarity);
			Assert.AreEqual("2RR", c.Rules.MainFace.ManaCost.ToString());
			Assert.AreEqual("Sorcery", c.Rules.MainFace.Type.ToString());
		}
	}
}
