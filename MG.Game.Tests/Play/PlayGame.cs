using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MG.Game.State;
using MG.Assets.Decks;
using MG.Assets.Decks.Serialization;
using MG.Assets.Tests.Storages;

namespace MG.Game.Tests.Play
{
	[TestClass]
	public class PlayGame
	{
		private static IDeckReader dr = new DeckReaderGatherer(StaticData.CardDbBlockM10);

		[TestMethod]
		public void PlayersWantToPlay()
		{
			GameToBeStarted gameToStart = new GameToBeStarted();
			gameToStart.Format = GameFormat.Standard | GameFormat.Constructed;
			gameToStart.RuleChanges = null;

			var alice = new PlayerToBeginGameWith() { Id = 1, Name = "Alice" };
			alice.Deck = parseDeck("12 Plains", "5 Silvercoat Lion", "3 Siege Mastodon");
			gameToStart.Players.Add(alice);

			var bob = new PlayerToBeginGameWith() { Id = 2, Name = "Bob" };
			bob.Deck = parseDeck("12 Forest", "6 Runeclaw Bear", "2 Enormous Baloth");
			gameToStart.Players.Add(bob);

			GameState game = new GameState(gameToStart);
		}

		private static IDeck parseDeck(params string[] cards)
		{
			return dr.ReadDeck(cards);
		}
	}
}
