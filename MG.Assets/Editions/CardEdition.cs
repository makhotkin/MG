using System;

namespace MG.Assets.Editions
{
	public class CardEdition : ICardEdition
	{
		public string Code { get; set; }
		public string Name { get; set; }
		public EditionType Type { get; set; }
		public BorderColor Border { get; set; }
		public DateTime ReleaseDate { get; set; }
	}
}

