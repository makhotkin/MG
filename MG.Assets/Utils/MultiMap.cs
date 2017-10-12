using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MG.Assets.Utils
{
	public class MultiMap<TKey, TValue> : Dictionary<TKey, List<TValue>>
	{
		public MultiMap() : base() { }
		public MultiMap(IEqualityComparer<TKey> valueComparer) : base(valueComparer) { }
		private static readonly IList<TValue> EmptyList = new List<TValue>(0).AsReadOnly();

		public void Add(TKey key, TValue value)
		{
			if (!this.TryGetValue(key, out List<TValue> container))
				base.Add(key, container = new List<TValue>());
			container.Add(value);
		}

		internal IList<TValue> TryGetValueOrEmptyList(TKey key)
		{
			return TryGetValue(key, out List<TValue> list) ? list : EmptyList;
		}

		public IEnumerable<TValue> ManyValues { get {
				return Values.SelectMany(a => a);
		} }
	}

}
