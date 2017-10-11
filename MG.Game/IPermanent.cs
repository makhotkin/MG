using MG.Game.Cards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MG.Game
{
	public interface IPermanent
	{
		IEnumerable<ICard> Cards { get; set; }
	}
}