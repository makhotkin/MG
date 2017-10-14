using MG.Play.Cards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MG.Play
{
	public interface IPermanent
	{
		IEnumerable<ICard> Cards { get; set; }
	}
}