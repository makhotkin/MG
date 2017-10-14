using MG.Assets.Storages;
using System.Collections.Generic;

namespace MG.Assets.Decks.Serialization
{

	public abstract class DeckReaderBase : IDeckReader
	{
		protected readonly ICardDatabase CardDb;
		protected DeckReaderBase(ICardDatabase database) {
			CardDb = database;
		}
		public abstract IDeck ReadDeck(IEnumerable<string> lines);
	}
}
