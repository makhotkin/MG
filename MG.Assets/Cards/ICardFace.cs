

using MG.Assets.Cards.Properties;
using MG.Assets.Cards.Properties.ManaCosts;
using MG.Assets.Cards.Properties.Types;
using System.Collections.Generic;

namespace MG.Assets.Cards
{
	public interface ICardFace
	{
		CardFullType Type { get; }
		Color Color { get; }
		string Name { get; }
		ManaCost ManaCost { get; }
		IEnumerable<string> OracleText { get; }
		string PowerToughnessLoyalty { get; }
	}
}
