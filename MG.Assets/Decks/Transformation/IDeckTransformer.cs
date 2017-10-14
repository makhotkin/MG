using MG.Assets.Editions;
using MG.Assets.Storages;
using System.Linq;

namespace MG.Assets.Decks.Transformation
{
	public interface IDeckTransformer 
	{
		IDeck Transform(IDeck input);
	}

	public class DeckTransformMaxMinEditions : IDeckTransformer
	{
		private readonly ICardDatabase cardDb;

		public DeckTransformMaxMinEditions(ICardDatabase cardDb)
		{
			this.cardDb = cardDb;
		}

		public IDeck Transform(IDeck input)
		{
			Deck result = new Deck();

			ICardEdition minimal = cardDb.Editions.First();
			foreach (var c in input.Sections.SelectMany(s => input[s]))
			{
				var minEd = cardDb.GetEarliestEditionOfCard(c.Name);
				if (minEd.CompareTo(minimal) > 0)
					minimal = minEd;
			}

			foreach (var s in input.Sections)
			{
				var sa = result.EnsureSection(s);
				foreach (var c in input[s])
					sa.Add(cardDb.CardByName(c.Name, cardDb.GetLatestEditionForCard(c.Name, minimal)));
			}


			return result;
		}
	}
}
