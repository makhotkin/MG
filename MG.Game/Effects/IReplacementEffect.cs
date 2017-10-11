using MG.Game.Events;

namespace MG.Game.Effects
{
	public interface IReplacementEffect : IContinuousEffect
	{
		IEventPredicate EventsToReplace { get; }
		IEvent ReplaceEvent(IEvent originalEvent);
	}
}
