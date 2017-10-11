using MG.Assets.Cards.Properties;
using MG.Assets.Editions;
using System.Collections.Generic;

namespace MG.Assets.Cards
{
	public class PrintedCard : IPrintedCard
	{
		public string Name { get; set; }

		public ICardRules Rules { get; set; }

		public ICardEdition Edition { get; set; }

		public CardRarity Rarity { get; set; }

		public string CollectorsNumber { get; set; }

		public string WaterMark { get; set; }

		// override object.Equals
		public override bool Equals(object obj)
		{
			PrintedCard pc = obj as PrintedCard;
			if (pc == null)
				return false;

			return pc.Name.Equals(this.Name) && pc.Edition.Equals(this.Edition) && pc.CollectorsNumber.Equals(this.CollectorsNumber);
		}

		public override int GetHashCode()
		{
			var hashCode = 1399779835;
			hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
			hashCode = hashCode * -1521134295 + EqualityComparer<ICardEdition>.Default.GetHashCode(Edition);
			hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(CollectorsNumber);
			return hashCode;
		}
	}
}

