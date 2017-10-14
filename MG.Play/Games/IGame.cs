using MG.Assets.Decks;
using MG.Play.Events;
using MG.Play.Players;
using MG.Play.Turns;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MG.Play.Games
{
	public interface IGame
	{
		GameFormat Format { get; }
		TurnTime CurrentTime { get; }
		IEnumerable<IPlayer> Players { get; }


		IEnumerable<IEventNotification> ApplyEvent(IEventToApply @event);
		Task<GameOutcome> Start();
	}
}
