using MG.Assets.Cards;
using System.Collections.Generic;

namespace MG.Assets.Decks
{
	public interface IDeck
	{
		string Name { get; }
		IList<IPrintedCard> this[DeckSection s] { get; }
		IEnumerable<DeckSection> Sections { get; }
	}
}

