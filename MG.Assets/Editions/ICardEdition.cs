using System;

namespace MG.Assets.Editions
{
	public interface ICardEdition
	{
		string Code { get; }
		string Name { get; }
		EditionType Type { get; }
		BorderColor Border { get; }
		DateTime ReleaseDate { get; }
		int NominalCardCount { get; }
	}
}

