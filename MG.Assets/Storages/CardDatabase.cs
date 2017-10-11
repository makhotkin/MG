using MG.Assets.Cards;
using MG.Assets.Editions;
using MG.Assets.Storages.Adapters;
using MG.Assets.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MG.Assets.Database
{
	public class CardDatabase : ICardDatabase
	{
		Random selectVariant = new Random();
		IDictionary<string, ICardEdition> EditionByCode = new Dictionary<string, ICardEdition>(StringComparer.OrdinalIgnoreCase);
		IDictionary<string, IPrintedCard> NewestCardsByName = new Dictionary<string, IPrintedCard>(StringComparer.OrdinalIgnoreCase);
		IDictionary<ICardEdition, MultiMap<string, IPrintedCard>> CardsInEdition = new Dictionary<ICardEdition, MultiMap<string, IPrintedCard>>();
		public IEnumerable<ICardEdition> Editions => EditionByCode.Values;

		public IPrintedCard CardByName(string name, string code = null)
		{
			if(code != null)
				return CardByName(name, GetEditionByCode(code));
			return NewestCardsByName.TryGetValue(name, out IPrintedCard card) ? card : null;
		}

		public IPrintedCard CardByName(string name, ICardEdition edition, int index = -1)
		{
			if (null == edition)
				return null;

			List<IPrintedCard> list;
			if (!CardsInEdition[edition].TryGetValue(name, out list))
				return null;
			if (index < 0)
				index = selectVariant.Next(list.Count);
			else
				index = index % list.Count;
			return list[index];
		}

		public IEnumerable<IPrintedCard> CardsByEdition(string code)
		{
			return CardsByEdition(GetEditionByCode(code));
		}

		public IEnumerable<IPrintedCard> CardsByEdition(ICardEdition edition)
		{
			return edition == null || CardsInEdition.TryGetValue(edition, out MultiMap<string, IPrintedCard> cards) ? Enumerable.Empty<IPrintedCard>() : cards.ManyValues;
		}

		public ICardEdition GetEditionByCode(string code)
		{
			return EditionByCode.TryGetValue(code, out ICardEdition res) ? res : null;
		}

		public void Populate(ICardDataAdapter source)
		{
			while (source.MoveNext())
			{
				var ed = source.Current;
				EditionByCode.Add(ed.Code, ed);
				MultiMap<string, IPrintedCard> multiMap = new MultiMap<string, IPrintedCard>(StringComparer.OrdinalIgnoreCase);
				CardsInEdition.Add(ed, multiMap);
				foreach (var c in source.CurrentCards)
				{
					NewestCardsByName[c.Name] = c;
					multiMap.Add(c.Name, c);
				}
			}
		}
	}
}
