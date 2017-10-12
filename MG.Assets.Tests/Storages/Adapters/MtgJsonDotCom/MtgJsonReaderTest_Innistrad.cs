using Microsoft.VisualStudio.TestTools.UnitTesting;
using MG.Assets.Storages.Adapters.MtgJsonDotCom;
using System.Collections.Generic;
using MG.Assets.Cards;
using System.Linq;
using MG.Assets.Editions;

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
			Assert.AreEqual(Editions.EditionType.Expansion, edition.Type);
		}
	}
}
