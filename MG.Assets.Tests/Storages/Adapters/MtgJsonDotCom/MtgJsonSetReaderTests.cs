using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MG.Assets.Storages.Adapters.MtgJsonDotCom;
using System.Configuration;
using System.IO;
using System.Collections.Generic;
using MG.Assets.Cards;
using System.Linq;

namespace MG.Assets.Tests
{
	[TestClass]
	public class MtgJsonSetReaderTests {

		static readonly string editionsPath = ConfigurationManager.AppSettings["EditionsFolder"];
		static readonly string projectPath = ConfigurationManager.AppSettings["HardcodedProjectFolder"];

		private static string GetPathForEdition(string code) => Path.Combine(projectPath, editionsPath, code + "-x.json");


		[TestMethod]
		public void CanReadM10()
		{
			Dictionary<string, ICardRules> rules = new Dictionary<string, ICardRules>();
			var instance = new MtgJsonSetReader(GetPathForEdition("M10"), rules);

			var cards = instance.Cards.ToArray();

			Assert.AreEqual("Magic 2010", instance.Edition.Name);
			Assert.AreEqual("M10", instance.Edition.Code);
			Assert.AreEqual(Editions.EditionType.Core, instance.Edition.Type);

			Assert.AreEqual(249, cards.Length);
		}

		[TestMethod]
		public void CanReadZendikar()
		{
			Dictionary<string, ICardRules> rules = new Dictionary<string, ICardRules>();
			var instance = new MtgJsonSetReader(GetPathForEdition("ZEN"), rules);

			Assert.AreEqual("Zendikar", instance.Edition.Name);
			Assert.AreEqual("ZEN", instance.Edition.Code);
			Assert.AreEqual(Editions.EditionType.Expansion, instance.Edition.Type);
		}
	}
}
