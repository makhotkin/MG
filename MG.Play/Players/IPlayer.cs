using MG.Play.Objects;
using MG.Play.Players.Controllers;
using MG.Play.Zones;
using System.Collections.Generic;

namespace MG.Play.Players
{

	public interface IPlayer
	{
		IPlayerController Controller { get; }
		IList<IGameObject> GetZone(ZoneType zone);
	}
}
