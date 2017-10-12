using MG.Assets.Cards.Properties;
using MG.Assets.Editions;
using System.Collections.Generic;
using System.Text;

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
		public string Artist { get; set; }

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

		public override string ToString()
		{
			return $"{Name} | {Edition.Code} | {Rarity} | {CollectorsNumber}/{Edition.NominalCardCount}";
		}
	}
}

