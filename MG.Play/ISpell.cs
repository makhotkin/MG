using MG.Play.Cards;
using MG.Play.Effects;
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