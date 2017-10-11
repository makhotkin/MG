using MG.Game.Effects;
using System.Collections.Generic;

namespace MG.Game.Abilities
{
	public interface IStaticAbility : IAbility
	{

		IEnumerable<IContinuousEffect> Effects { get; set; }
	}
}