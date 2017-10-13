using MG.Play.Effects;
using MG.Play.Events;
using System.Collections.Generic;

namespace MG.Play.Abilities
{
	public interface ITriggeredAbility : IAbility
	{
		IEnumerable<IEffect> Effects { get; set; }
		IEventPredicate Trigger { get; set; }
	}
}