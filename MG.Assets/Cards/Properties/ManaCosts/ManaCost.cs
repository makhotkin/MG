using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MG.Assets.Cards.Properties.ManaCosts
{
	public class ManaCost
	{
		public static readonly ManaCost NoCost = new ManaCost() { generic = -1 };

		private readonly List<ManaCostAtom> shards = new List<ManaCostAtom>();
		private int generic = 0;

		public int Generic => generic >= 0 ? generic : 0;
		public bool HasNoCost => generic < 0;
		public IEnumerable<ManaCostAtom> Shards => shards;

		private void Add(int amount)
		{
			generic += amount;
		}
		private void Add(ManaCostAtom type, int amount = 1)
		{
			for (int t = 0; t < amount; t++)
				shards.Add(type);
		}

		public int ConvertedManaCost => generic + shards.Sum(s => s.Cmc());

		public static ManaCost Parse(string cost)
		{
			ManaCost result = new ManaCost();

			if (string.IsNullOrWhiteSpace(cost))
			{
				result.generic = -1;
				return result;
			}
			int len = cost.Length;
			int tokenStart = 0;
			bool inBracket = false;
			int digitStart = -1;
			int digitLen = 0;
			for (int i = 0; i < len; i++)
			{
				char c = cost[i];
				if (c == '}') {
					ManaCostAtom atom = ManaCostShards.ParseAtom(cost, tokenStart, i);
					if (atom != ManaCostAtom.Generic)
						result.Add(atom);
					else
						result.Add(int.Parse(cost.Substring(tokenStart, i - tokenStart)));
					inBracket = false;
					continue;
				}
				else if (inBracket) continue;

				if (c >= '0' && c <= '9') {
					if (digitStart < 0)
						digitStart = i;
					continue;
				}
				else
					if (digitStart >= 0 && digitLen == 0)
					digitLen = i - digitStart;

				if (c == '{') {
					inBracket = true; tokenStart = i + 1;
				}
				else {
					if(!char.IsWhiteSpace(c))
						result.Add(ManaCostShards.ParseAtom(cost, i, i + 1));
				}
			}
			if (digitStart >= 0)
				result.Add(int.Parse(cost.Substring(digitStart, digitLen > 0 ? digitLen : len - digitStart)));

			return result;
		}

		public override string ToString()
		{
			return this.ToString(false);
		}

		public string ToString(bool withBrackets)
		{
			if (generic < 0)
				return "(no cost)";
			if (shards.Count == 0)
				return withBrackets ? string.Concat("{", generic, "}") : generic.ToString();
			StringBuilder sb = new StringBuilder();
			if (generic > 0)
			{
				if (withBrackets)
					sb.Append('{').Append(generic).Append('}');
				else
					sb.Append(generic);
			}
			foreach (var s in shards)
			{
				string atom = s.AtomToString();
				if (withBrackets || atom.Length > 1)
					sb.Append('{').Append(atom).Append('}');
				else
					sb.Append(atom);
			}
			return sb.ToString();
		}
	}
}

