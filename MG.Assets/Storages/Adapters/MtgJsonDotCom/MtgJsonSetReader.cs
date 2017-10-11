using MG.Assets.Cards;
using MG.Assets.Editions;
using System.Collections.Generic;
using System;

namespace MG.Assets.Storages.Adapters.MtgJsonDotCom
{
	public class MtgJsonSetReader
	{
		private List<IPrintedCard> _cards;

		public IEnumerable<IPrintedCard> Cards { get => _cards; }
		public ICardEdition Edition { get; }

		public MtgJsonSetReader(string fileName)
		{
			throw new NotImplementedException("Read json file with set data");
		}
	}
}
