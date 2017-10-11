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
		private static readonly IEnumerable<TValue> EmptyList = new List<TValue>(0).AsReadOnly();

		public void Add(TKey key, TValue value)
		{
			List<TValue> container = null;
			if (!this.TryGetValue(key, out container))
			{
				container = new List<TValue>();
				base.Add(key, container);
			}
			container.Add(value);
		}

		internal IEnumerable<TValue> TryGetValueOrEmptyEnumerable(TKey key)
		{
			return TryGetValue(key, out List<TValue> list) ? list : EmptyList;
		}

		public IEnumerable<TValue> ManyValues { get {
				return Values.SelectMany(a => a);
		} }
	}

}
