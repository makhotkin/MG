using MG.Game.State;
using System.Collections.Generic;

namespace MG.Game.Events
{
	public interface IEventToApply : IEvent
	{
		IEnumerable<IEventNotification> ExecuteOn(IGame gameState);
	}
}
