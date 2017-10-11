namespace MG.Assets.Editions
{
	public interface ICardEdition
	{
		string Code { get; set; }
		string Name { get; set; }
		EditionType Type { get; set; }
		BorderColor Border { get; set; }
	}
}

