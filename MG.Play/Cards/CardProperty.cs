using System;

namespace MG.Play.Cards
{
	public class CardProperty<T>
	{
		public String Name { get; private set; }
		public Type Type { get { return typeof(T); } }
		public readonly T ValueDefault;
		public CardProperty(string name, T defaultValue = default(T))
		{
			Name = name;
			ValueDefault = defaultValue;
		}
	}

	public static class CardProperty 
	{
		public static readonly CardProperty<string> Name = new CardProperty<string>("Name", "???");
		public static readonly CardProperty<bool> Tapped = new CardProperty<bool>("Tapped", false);
		//public static readonly CardProperty<CardFullType> Type = new CardProperty<CardFullType>("Type", CardFullType.Empty);
		//public static readonly CardProperty<Color> Color = new CardProperty<Color>("Color", Model.Color.Colorless);

		public static readonly CardProperty<int> Power = new CardProperty<int>("Power");
		public static readonly CardProperty<int> Toughness = new CardProperty<int>("Toughness");
		// public static readonly CardProperty<CountersMap> Counters = new CardProperty<CountersMap>("Counters", new CountersMap());
	}
}
