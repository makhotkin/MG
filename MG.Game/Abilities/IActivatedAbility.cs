using MG.Game.Effects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MG.Game.Abilities
{
	public interface IActivatedAbility : IAbility
	{
		bool IsManaAbility { get; }
		bool IsLoyaltyAbility { get; }

		IEnumerable<IEffect> Effects { get; set; }
	}
}