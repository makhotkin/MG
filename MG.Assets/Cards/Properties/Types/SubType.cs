using System;
using System.Collections.Generic;

namespace MG.Assets.Cards.Properties.Types
{
	public class SubType : List<string>
	{
		private bool isEveryCreatureType;
		private bool isEveryBasicLandType;

		public SubType() : base() { }
		public SubType(IEnumerable<string> strings) : base(strings) { }

		public bool Is(string type)
		{
			return this.Contains(type) || isEveryBasicLandType && IsBasicLandType(type) || isEveryCreatureType && IsCreatureType(type);
		}

		public static bool IsBasicLandType(string type)
		{
			return Array.IndexOf(BasicLandTypes, type) >= 0;
		}

		public static bool IsCreatureType(string type)
		{
			return true;
		}

		public static readonly string[] BasicLandTypes = new[] { "Plains", "Island", "Swamp", "Mountain", "Forest" };
		
	}
}

