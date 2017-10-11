using MG.Game.Events;
using MG.Game.Players;
using MG.Game.Turns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MG.Game.State
{
	public interface IGame
	{
		TurnTime CurrentTime { get; }
		IEnumerable<Player> Players { get; }


		IEnumerable<IEventNotification> ApplyEvent(IEventToApply @event);
	}
}
