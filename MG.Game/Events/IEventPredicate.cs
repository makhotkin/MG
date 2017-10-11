namespace MG.Game.Events
{
	public interface IEventPredicate
	{
		bool Matches(IEvent @event);
	}
}