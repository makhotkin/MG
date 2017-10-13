using MG.Play.Events;
using MG.Play.Players;
using MG.Play.Turns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MG.Play.Games
{
	public interface IGame
	{
		TurnTime CurrentTime { get; }
		IEnumerable<Player> Players { get; }


		IEnumerable<IEventNotification> ApplyEvent(IEventToApply @event);
	}
}
