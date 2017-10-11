using MG.Game.Events;

namespace MG.Game.Effects
{
	public interface IPreventionEffect : IContinuousEffect
	{
		IEventPredicate EventsToPrevent { get; }

		void PreventEvent();
	}
}
