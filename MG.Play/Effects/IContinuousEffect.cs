namespace MG.Play.Effects
{
	// https://mtg.gamepedia.com/Continuous_effects
	public interface IContinuousEffect : IEffect
	{
		bool IsTextChanging { get; set; } // color, type(subtype) is subject to be changed
	}
}
