using ApplicationService.DTOs;
using ApplicationService.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SOAP
{
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "PlayerService" in both code and config file together.
	public class PlayerService : IPlayerService
	{
		// call the service
		private PlayerManagementService playerService = new PlayerManagementService();
		public List<PlayerDTO> GetPlayers()
		{
			return playerService.Get();
		}

		public PlayerDTO GetPlayerByID(int id)
		{
			return playerService.GetById(id);
		}
		public string PostPlayer(PlayerDTO playerDTO)
		{
			if (playerService.Save(playerDTO))
			{
				return "Player has been saved!";
			} else
			{
				return "Player has not been saved!";
			}
		}
		public string DeletePlayer(int id)
		{
			if (playerService.Delete(id))
			{
				return "Player has been deleted!";
			} else
			{
				return "Player has not been deleted!";
			}
		}
	}
}
