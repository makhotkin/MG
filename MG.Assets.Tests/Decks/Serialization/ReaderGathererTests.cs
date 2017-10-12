using Microsoft.VisualStudio.TestTools.UnitTesting;
using MG.Assets.Decks.Serialization;
using MG.Assets.Tests.Storages;
using MG.Assets.Decks;
using System.Linq;
using System.IO;
using MG.Assets.Cards.Properties;
using MG.Assets.Cards.Properties.Types;

namespace MG.Assets.Tests.Decks.Serialization
{
	[TestClass]
	public class ReaderGathererTests
	{
		private static IDeckReader dr = new DeckReaderGatherer(StaticData.CardDbBlockM10);

		[TestMethod]
		public void Test_20ForestDeck()
		{
			string[] deckList = new string[] { "20 Forest", "2 Terramorphic Expanse", "18 Enormous Baloth" };

			var deck = dr.ReadDeck(deckList);
			var main = deck[DeckSection.Main].ToArray();
			Assert.AreEqual(40, main.Length);
			Assert.AreEqual(18, main.Count(c => c.Name.Equals("Enormous Baloth")));
			Assert.AreEqual(20, main.Count(c => c.Name.Equals("Forest")));
			Assert.AreEqual(2, main.Count(c => c.Name.Equals("Terramorphic Expanse")));
		}

		private string buildM10DeckFileName(string name) => Path.Combine(TestEnviroinment.PathToDecks, "M10 - " + name + ".txt");

		[TestMethod]
		public void Read_WeAreLegion_Deck()
		{
			string[] deckList = File.ReadAllLines(buildM10DeckFileName("We Are Legion"));

			var deck = dr.ReadDeck(deckList);
			var main = deck[DeckSection.Main].ToArray();
			Assert.AreEqual(41, main.Length);
			Assert.AreEqual(40, main.Count(c => c.Rules.ColorIdentity == Color.Red || c.Rules.ColorIdentity == Color.White));
			Assert.AreEqual(13, main.Count(c => c.Rules.MainFace.Type.Type == CoreType.Creature));
			Assert.AreEqual(5, main.Count(c => c.Rules.MainFace.Type.Type == CoreType.Instant));
			Assert.AreEqual(18, main.Count(c => c.Rules.MainFace.Type.Type == CoreType.Land));

			Assert.AreEqual(2, main.Count(c => c.Rarity == CardRarity.Rare));
		}

	}
}
