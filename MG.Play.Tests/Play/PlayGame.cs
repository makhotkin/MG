using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MG.Play.Games;
using MG.Assets.Decks;
using MG.Assets.Decks.Serialization;
using MG.Assets.Tests.Storages;
using MG.Play.Players.Controllers;

namespace MG.Play.Tests.Play
{
	[TestClass]
	public class PlayGame
	{
		private static IDeckReader dr = new DeckReaderGatherer(StaticData.CardDbBlockM10);

		[TestMethod]
		public async void PlayersWantToPlay()
		{
			GameToBeStarted gameToStart = new GameToBeStarted();
			gameToStart.Format = GameFormat.Standard | GameFormat.Constructed;
			gameToStart.RuleChanges = null;

			var ca = new PlayerControllerScripted();
			var alice = new PlayerToBeginGameWith() { Controller = ca, Name = "Alice" };
			alice.Deck = parseDeck("12 Plains", "5 Silvercoat Lion", "3 Siege Mastodon");
			gameToStart.Players.Add(alice);

			var cb = new PlayerControllerScripted();
			var bob = new PlayerToBeginGameWith() { Controller = cb, Name = "Bob" };
			bob.Deck = parseDeck("12 Forest", "6 Runeclaw Bear", "2 Enormous Baloth");
			gameToStart.Players.Add(bob);

			var game = new Game(gameToStart);

			var result = await game.Start();
		}

		private static IDeck parseDeck(params string[] cards)
		{
			return dr.ReadDeck(cards);
		}
	}
}
