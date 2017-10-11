namespace MG.Assets.Cards.Properties.ManaCost
{
	public static class ManaCostShards
	{
		public const ManaCostAtom ColorLess = ManaCostAtom.Colorless;
		public const ManaCostAtom X = ManaCostAtom.IsX | ManaCostAtom.Generic;

		public const ManaCostAtom White = ManaCostAtom.White;
		public const ManaCostAtom Blue = ManaCostAtom.Blue;
		public const ManaCostAtom Black = ManaCostAtom.Black;
		public const ManaCostAtom Red = ManaCostAtom.Red;
		public const ManaCostAtom Green = ManaCostAtom.Green;
		public const ManaCostAtom Generic = ManaCostAtom.Generic;

		public const ManaCostAtom PW = ManaCostAtom.White | ManaCostAtom.Phyrexian;
		public const ManaCostAtom PU = ManaCostAtom.Blue | ManaCostAtom.Phyrexian;
		public const ManaCostAtom PB = ManaCostAtom.Black | ManaCostAtom.Phyrexian;
		public const ManaCostAtom PR = ManaCostAtom.Red | ManaCostAtom.Phyrexian;
		public const ManaCostAtom PG = ManaCostAtom.Green | ManaCostAtom.Phyrexian;

		public const ManaCostAtom WU = ManaCostAtom.White | ManaCostAtom.Blue;
		public const ManaCostAtom WB = ManaCostAtom.White | ManaCostAtom.Black;
		public const ManaCostAtom WR = ManaCostAtom.White | ManaCostAtom.Red;
		public const ManaCostAtom WG = ManaCostAtom.White | ManaCostAtom.Green;
		public const ManaCostAtom UB = ManaCostAtom.Blue | ManaCostAtom.Black;
		public const ManaCostAtom UR = ManaCostAtom.Blue | ManaCostAtom.Red;
		public const ManaCostAtom UG = ManaCostAtom.Blue | ManaCostAtom.Green;
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
			if (shard == X)
				return 0;
			return shard.HasFlag(ManaCostAtom.Or2Mana) ? 2 : 1;
		}
	}
}

