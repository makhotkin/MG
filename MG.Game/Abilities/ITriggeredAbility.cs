using MG.Game.Effects;
using MG.Game.Events;
using System.Collections.Generic;

namespace MG.Game.Abilities
{
	public interface ITriggeredAbility : IAbility
	{
		IEnumerable<IEffect> Effects { get; set; }
		IEventPredicate Trigger { get; set; }
	}
}