using MG.Assets.Cards;
using MG.Assets.Editions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace MG.Assets.Storages.Adapters
{

	public abstract class CardDataAdapter : ICardDataAdapter
	{
		protected IDictionary<string, ICardRules> ExistingRules = new Dictionary<string, ICardRules>(StringComparer.OrdinalIgnoreCase);

		public abstract IEnumerable<IPrintedCard> CurrentCards { get; }
		public abstract ICardEdition Current { get; }

		object IEnumerator.Current => Current;

		public abstract void Dispose();
		public abstract bool MoveNext();
		public abstract void Reset();
	}
}
