using MG.Assets.Cards;
using System.Collections.Generic;

namespace MG.Assets.Decks
{
	public interface IDeck
	{
		string Name { get; }
		IList<IPrintedCard> this[DeckSection section] { get; }
		bool HasSection(DeckSection section);
		IEnumerable<DeckSection> Sections { get; }
	}
}

