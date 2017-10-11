using MG.Game.Cards;
using MG.Game.Effects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MG.Game
{
	public interface ISpell
	{
		ICard Card { get; set; }
		IEnumerable<IEffect> Effects { get; set; }
	}
}