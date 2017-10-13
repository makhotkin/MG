namespace MG.Play.Events
{
	public interface IEventPredicate
	{
		bool Matches(IEvent @event);
	}
}