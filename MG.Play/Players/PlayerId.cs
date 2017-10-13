namespace MG.Play.Players
{
	public struct PlayerId
	{
		int Id;
		public static implicit operator int(PlayerId d) => d.Id;
		public static implicit operator PlayerId(int d) => new PlayerId { Id = d };
	}
}
