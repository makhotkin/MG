using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MG.Assets.Cards.Properties
{
	[Flags]
	public enum Color : short
	{
		Colorless = 0, // colorless eldrazi permanent
		White = 1,
		Blue = 2,
		Black = 4,
		Red = 8,
		Green = 16,
	}
}


