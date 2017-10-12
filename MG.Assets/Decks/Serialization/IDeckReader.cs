using System.Collections.Generic;

namespace MG.Assets.Decks.Serialization
{
	public interface IDeckReader
	{
		IDeck ReadDeck(IEnumerable<string> lines);
	}
}
