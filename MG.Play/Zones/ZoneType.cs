using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MG.Play.Zones
{
	public enum ZoneType
	{
		Stack,
		Hand,
		Graveyard,
		Battlefield,
		Exile,
		Library,
		Sideboard,
		Command,

		NonExistance, // this where tokens come to and from
	}
}
