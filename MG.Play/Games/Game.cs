using MG.Assets.Cards;
using MG.Play.Cards;
using MG.Play.Events;
using MG.Play.Games.States;
using MG.Play.Players;
using MG.Play.Turns;
using System.Collections.Generic;
using System.Threading.Tasks;
using MG.Assets.Decks;

namespace MG.Play.Games
{

	public class Game : IGame
	{
		public TurnTime CurrentTime => currentTime;
		private TurnTime currentTime;
		private readonly GameFormat format;
		public GameFormat Format => format;

		public IEnumerable<IPlayer> Players => players;
		private List<Player> players = new List<Player>();

		private GameRulesAmmendments rules;

		private Stack<IGameState> States = new Stack<IGameState>();

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
			this.format = builder.Format;
		}

		private void addPlayer(PlayerToBeginGameWith player)
		{
			//ValidateDeck(player.Deck, rules);

			var newPlayer = new Player(player.Controller, player.Name);
			this.players.Add(newPlayer);
			newPlayer.DeckBecomesLibrary(player.Deck, materializeCard);
		}

		private ICard materializeCard(IPrintedCard printed, IPlayer owner)
		{
			var card = new Card(printed, owner);
			return card;
		}


		public enum GameStage
		{
			GameBegins,
			ChooseWhoTakesFirstTurn,
			TakeMulligan,
			ActionsWithOpeningHand, // Leylines
									// Planechase 103.6 skipped for now
			PlayersTakeTurns,
			GameEnds
		}

		async public Task<GameOutcome> Start()
		{

			while (States.Count > 0)
			{
				var topState = States.Peek();

				//currentTime.Advance();
				(bool popCurrent, IGameState nextState) = await topState.Execute();

				if (popCurrent)
					States.Pop();
				if (nextState != null)
					States.Push(nextState);
			}
			GameOutcome result = new GameOutcome();
			return result;
		}
	}
}