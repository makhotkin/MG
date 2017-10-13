using MG.Play.Effects;
using System.Collections.Generic;

namespace MG.Play.Abilities
{
	public interface IStaticAbility : IAbility
	{

		IEnumerable<IContinuousEffect> Effects { get; set; }
	}
}