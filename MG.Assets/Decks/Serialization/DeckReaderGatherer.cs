using MG.Assets.Storages;
using System.Collections.Generic;

namespace MG.Assets.Decks.Serialization
{
	public class DeckReaderGatherer : DeckReaderBase
	{
		public DeckReaderGatherer(ICardDatabase database) : base(database)
		{
		}

		private static readonly char[] Spaces = new char[] { ' ' };

		public override IDeck ReadDeck(IEnumerable<string> lines)
		{
			/*
			Lines come in format like this:
			 N CardForMainBoard
			 M CardForMainBoard
			<two_empty_lines>
			 K CardForSideBoard
			*/

			Deck result = new Deck();
			var activeSection = result.EnsureSection(DeckSection.Main);
			bool readingMain = true;
			int emptyLines = 0;
			foreach (var l in lines) {
				if (string.IsNullOrWhiteSpace(l)) {
					emptyLines++;
					continue;
				}

				if (emptyLines > 1 && readingMain) {
					readingMain = false;
					activeSection = result.EnsureSection(DeckSection.SideBoard);
				}

				string[] parts = l.Trim().Split(Spaces, 2);
				for (int i = int.Parse(parts[0]); i > 0; i--)
				{
					activeSection.Add(CardDb.CardByName(parts[1]));
				}
			}
			return result;
		}
	}
}
