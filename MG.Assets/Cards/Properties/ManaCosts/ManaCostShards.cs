using System;

namespace MG.Assets.Cards.Properties.ManaCosts
{
	public static class ManaCostShards
	{
		public const ManaCostAtom ColorLess = ManaCostAtom.Colorless;
		public const ManaCostAtom X = ManaCostAtom.IsX;

		public const ManaCostAtom White = ManaCostAtom.White;
		public const ManaCostAtom Blue = ManaCostAtom.Blue;
		public const ManaCostAtom Black = ManaCostAtom.Black;
		public const ManaCostAtom Red = ManaCostAtom.Red;
		public const ManaCostAtom Green = ManaCostAtom.Green;

		public const ManaCostAtom PW = ManaCostAtom.White | ManaCostAtom.Phyrexian;
		public const ManaCostAtom PU = ManaCostAtom.Blue | ManaCostAtom.Phyrexian;
		public const ManaCostAtom PB = ManaCostAtom.Black | ManaCostAtom.Phyrexian;
		public const ManaCostAtom PR = ManaCostAtom.Red | ManaCostAtom.Phyrexian;
		public const ManaCostAtom PG = ManaCostAtom.Green | ManaCostAtom.Phyrexian;

		public const ManaCostAtom WU = ManaCostAtom.White | ManaCostAtom.Blue;
		public const ManaCostAtom WB = ManaCostAtom.White | ManaCostAtom.Black;
		public const ManaCostAtom RW = ManaCostAtom.White | ManaCostAtom.Red;
		public const ManaCostAtom GW = ManaCostAtom.White | ManaCostAtom.Green;
		public const ManaCostAtom UB = ManaCostAtom.Blue | ManaCostAtom.Black;
		public const ManaCostAtom UR = ManaCostAtom.Blue | ManaCostAtom.Red;
		public const ManaCostAtom GU = ManaCostAtom.Blue | ManaCostAtom.Green;
		public const ManaCostAtom BR = ManaCostAtom.Black | ManaCostAtom.Red;
		public const ManaCostAtom BG = ManaCostAtom.Black | ManaCostAtom.Green;
		public const ManaCostAtom RG = ManaCostAtom.Red | ManaCostAtom.Green;

		public const ManaCostAtom W2 = ManaCostAtom.White | ManaCostAtom.Or2Mana;
		public const ManaCostAtom U2 = ManaCostAtom.Blue | ManaCostAtom.Or2Mana;
		public const ManaCostAtom B2 = ManaCostAtom.Black | ManaCostAtom.Or2Mana;
		public const ManaCostAtom R2 = ManaCostAtom.Red | ManaCostAtom.Or2Mana;
		public const ManaCostAtom G2 = ManaCostAtom.Green | ManaCostAtom.Or2Mana;

		public static int Cmc(this ManaCostAtom shard)
		{
			if (shard.HasFlag(ManaCostAtom.IsX))
				return 0;
			return shard.HasFlag(ManaCostAtom.Or2Mana) ? 2 : 1;
		}


		public static float GetComparableCost(this ManaCostAtom shard)
		{
			if (shard.HasFlag(ManaCostAtom.IsX)) return 0.0001f;

			float cost = shard.HasFlag(ManaCostAtom.Or2Mana) ? 2 : 1;

			if (shard.HasFlag(ManaCostAtom.White)) cost += 0.0005f;
			if (shard.HasFlag(ManaCostAtom.Blue)) cost += 0.0020f;
			if (shard.HasFlag(ManaCostAtom.Black)) cost += 0.0080f;
			if (shard.HasFlag(ManaCostAtom.Red)) cost += 0.0320f;
			if (shard.HasFlag(ManaCostAtom.Green)) cost += 0.1280f;
			if (shard.HasFlag(ManaCostAtom.Phyrexian)) cost += 0.00003f;

			return cost;
		}

		public static string AtomToString(this ManaCostAtom shard)
		{
			switch (shard)
			{
				case ColorLess: return "C";
				case X: return "X";

				case White: return "W";
				case Blue: return "U";
				case Black: return "B";
				case Red: return "R";
				case Green: return "G";

				case PW: return "P/W";
				case PU: return "P/U";
				case PB: return "P/B";
				case PR: return "P/R";
				case PG: return "P/G";

				case W2: return "2/W";
				case U2: return "2/U";
				case B2: return "2/B";
				case R2: return "2/R";
				case G2: return "2/G";

				case WU: return "W/U";
				case UB: return "U/B";
				case BR: return "B/R";
				case RG: return "R/G";
				case GW: return "G/W";

				case WB: return "W/B";
				case UR: return "U/R";
				case BG: return "B/G";
				case RW: return "R/W";
				case GU: return "G/U";

				default: throw new ArgumentException("Unknown mana shard: " + (int)shard);
			}
		}

		public static ManaCostAtom ParseAtom(string cost, int from = 0, int till = -1) {
			if (till < 0) till = cost.Length;
			bool hasLetter = false;
			ManaCostAtom atom = 0;
			for (int i = from; i < till; i++)
			{
				switch (cost[i])
				{
					case 'W': case 'w': atom |= ManaCostAtom.White; hasLetter = true; break;
					case 'U': case 'u': atom |= ManaCostAtom.Blue; hasLetter = true; break;
					case 'B': case 'b': atom |= ManaCostAtom.Black; hasLetter = true; break;
					case 'R': case 'r': atom |= ManaCostAtom.Red; hasLetter = true; break;
					case 'G': case 'g': atom |= ManaCostAtom.Green; hasLetter = true; break;
					case 'C': case 'c': atom |= ManaCostAtom.Colorless; hasLetter = true; break;
					case 'P': case 'p': atom |= ManaCostAtom.Phyrexian; hasLetter = true; break;
					case 'X': case 'x': atom |= ManaCostAtom.IsX; hasLetter = true; break;
					case '2': atom |= ManaCostAtom.Or2Mana; break;
				}
			}
			if (hasLetter)
				return atom;
			else
				return ManaCostAtom.Generic; // some number - cannot return it from here in enum, caller should int.parse the value
		}
	}
}

