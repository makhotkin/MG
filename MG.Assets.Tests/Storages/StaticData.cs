using MG.Assets.Storages;
using MG.Assets.Storages.Adapters;
using MG.Assets.Storages.Adapters.MtgJsonDotCom;
using System;

namespace MG.Assets.Tests.Storages
{
	public static class StaticData
	{
		private static ICardDatabase MakeCardDbM10() {
			ICardDataAdapter dataAdapter = new MtgJsonDotComAdapter(TestEnviroinment.PathToEditions, "M10", "ZEN", "WWK", "ROE");
			return new CardDatabase().Populate(dataAdapter);
		}

		private static Lazy<ICardDatabase> cardDbM10 = new Lazy<ICardDatabase>(MakeCardDbM10, false);
		public static ICardDatabase CardDbBlockM10 => cardDbM10.Value;
		
	}
}
