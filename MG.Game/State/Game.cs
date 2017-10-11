using MG.Assets.Cards;
using MG.Assets.Decks;
using MG.Game.Cards;
using MG.Game.Events;
using MG.Game.Players;
using MG.Game.Turns;
using System.Collections.Generic;

namespace MG.Game.State
{
	public class GameToBeStarted
	{
		public readonly List<PlayerToBeginGameWith> Players = new List<PlayerToBeginGameWith>();
		public GameFormat Format;
		public GameRulesAmmendments RuleChanges;
	}

	public class Game : IGame
	{
		public TurnTime CurrentTime => currentTime;
		private TurnTime currentTime;

		public IEnumerable<Player> Players => players;
		private List<Player> players = new List<Player>();

		private GameRulesAmmendments rules;

		public IEnumerable<IEventNotification> ApplyEvent(IEventToApply @event)
		{
			return @event.ExecuteOn(this);
		}


		public Game(GameToBeStarted builder)
		{
			this.rules = builder.RuleChanges;
			foreach (var p in builder.Players)
				addPlayer(p);
			currentTime = new TurnTime();
		}

		private void addPlayer(PlayerToBeginGameWith player)
		{
			//ValidateDeck(player.Deck, rules);

			var newPlayer = new Player(player.Id, player.Name);
			this.players.Add(newPlayer);
			newPlayer.DeckBecomesLibrary(player.Deck, materializeCard);
			newPlayer.ShuffleLibrary();
		}

		private ICard materializeCard(IPrintedCard printed, IPlayer owner)
		{
			var card = new Card(printed, owner);
			return card;
		}
	}
}