using MG.Play.Events;

namespace MG.Play.Effects
{
	public interface IPreventionEffect : IContinuousEffect
	{
		IEventPredicate EventsToPrevent { get; }

		void PreventEvent();
	}
}
