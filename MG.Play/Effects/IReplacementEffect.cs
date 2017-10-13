using MG.Play.Events;

namespace MG.Play.Effects
{
	public interface IReplacementEffect : IContinuousEffect
	{
		IEventPredicate EventsToReplace { get; }
		IEvent ReplaceEvent(IEvent originalEvent);
	}
}
