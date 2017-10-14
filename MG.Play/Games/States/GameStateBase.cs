using MG.Assets.Cards.Properties.Types;
using MG.Assets.Decks;
using MG.Play.Cards;
using MG.Play.Players;
using MG.Play.Zones;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MG.Play.Games.States
{
	public abstract class GameStateBase : IGameState
	{
		protected readonly IGame Game;
		public GameStateBase(IGame game)
		{
			this.Game = game;
		}


		public virtual async Task<(bool popCurrent, IGameState nextState)> Execute()
		{
			return await Task.FromResult((false, (IGameState)null));
		}
	}

	public class StartingTheGameState : GameStateBase
	{
		public StartingTheGameState(IGame game) : base(game)
		{
		}

		public override async Task<(bool popCurrent, IGameState nextState)> Execute()
		{
			if(Game.Format.HasFlag(GameFormat.Conspiracy))
			{
				List<IPlayer> playersWithConspiracies = new List<IPlayer>();
				List<Task<IEnumerable<ICard>>> decisions = new List<Task<IEnumerable<ICard>>>();
				foreach (var p in Game.Players)
				{
					var candidates = p.GetZone(ZoneType.Sideboard).Select(c => c.CardType.HasFlag(CardType.Conspiracy)).Cast<ICard>().ToArray();
					if (candidates.Any())
						decisions.Add((p, p.Controller.ChooseSome(candidates, 0)));
				}
				var arrDecisions = await Task.WhenAll(decisions.ToArray());

			}

			return await Task.FromResult((false, (IGameState)null));
		}
	}
}
