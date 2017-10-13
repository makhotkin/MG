using MG.Play.Games;
using System.Collections.Generic;

namespace MG.Play.Events
{
	public interface IEventToApply : IEvent
	{
		IEnumerable<IEventNotification> ExecuteOn(IGame gameState);
	}
}
