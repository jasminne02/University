using ApplicationService.DTOs;
using Data.Entities;
using Repository.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Implementations
{
	public class PlayerManagementService
	{
		public List<PlayerDTO> Get()
		{
			List<PlayerDTO> playersDTO = new List<PlayerDTO>();

			using(UnitOfWork unitOfWork = new UnitOfWork())
			{
				foreach(var item in unitOfWork.PlayerRepository.Get())
				{
                    PlayerDTO playerDTO = new PlayerDTO();

                    playerDTO.ID = item.ID;
                    playerDTO.Names = item.Names;
                    playerDTO.TeamID = item.TeamID;

                    // Check if Team exists before assigning to Player
                    if(item.TeamID != null)
                    {
                        Team team = item.Team;
                        TeamDTO teamDTO = new TeamDTO();
                        teamDTO.ID = team.ID;
                        teamDTO.Title = team.Title;

                        playerDTO.Team = teamDTO;
                    }
                    playersDTO.Add(playerDTO);
					
				}
			}

			return playersDTO;
		}

		public PlayerDTO GetById(int id)
		{
			PlayerDTO playerDTO = new PlayerDTO();

			using (UnitOfWork unitOfWork = new UnitOfWork())
			{
				Player player = unitOfWork.PlayerRepository.GetByID(id);

				if (player != null)
				{
					playerDTO.Names = player.Names;
					playerDTO.TeamID = player.TeamID;
					// playerDTO.Team = player.Team;
				}

				return playerDTO;
			}
		}

		public bool Save(PlayerDTO playerDTO)
		{
			Player player = new Player
			{
				Names = playerDTO.Names,
				TeamID = playerDTO.TeamID
			};

			try
			{
				using (UnitOfWork unitOfWork = new UnitOfWork())
				{
					unitOfWork.PlayerRepository.Insert(player);
					unitOfWork.Save();
				}

				return true;
			} 
			catch
			{
				return false;
			}
		}

		public bool Delete(int id)
		{
			try
			{
				using(UnitOfWork unitOfWork = new UnitOfWork())
				{
					unitOfWork.PlayerRepository.Delete(id);
					unitOfWork.Save();
				}
				return true;
			}
			catch
			{
				return false;
			}
		}
	}
}
