using System;
using System.Collections.Generic;

namespace MG.Assets.Editions
{
	public class CardEdition : ICardEdition
	{
		public string Code { get; set; }
		public string Name { get; set; }
		public EditionType Type { get; set; }
		public BorderColor Border { get; set; }
		public DateTime ReleaseDate { get; set; }
		public int NominalCardCount { get; set; }

		public override bool Equals(object obj) => (obj is ICardEdition ed) && Code.Equals(ed.Code);
		public int CompareTo(ICardEdition other) => ReleaseDate.CompareTo(other.ReleaseDate);

		public override int GetHashCode()
		{
			return -434485196 + EqualityComparer<string>.Default.GetHashCode(Code);
		}
	}
}

