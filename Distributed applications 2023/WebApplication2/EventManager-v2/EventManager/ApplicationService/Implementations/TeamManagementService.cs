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

    public class TeamManagementService { 

    public List<TeamDTO> Get()
    {
        List<TeamDTO> teamsDTO = new List<TeamDTO>();

        using (UnitOfWork unitOfWork = new UnitOfWork())
        {
            foreach (var item in unitOfWork.TeamRepository.Get())
            {
                    TeamDTO teamDTO = new TeamDTO();

                    teamDTO.ID = item.ID;
                    teamDTO.Title = item.Title;
                    teamDTO.Country = item.Country;
                    teamDTO.Players = new List<PlayerDTO>();



                if (item.Players != null)
                {
                        foreach (var player in item.Players)
                        {
                            PlayerDTO playerDTO = new PlayerDTO();
                            playerDTO.ID = player.ID;
                            playerDTO.Names = player.Names;
                            playerDTO.TeamID = player.TeamID;
                            // playerDTO.Team = teamDTO;

                            teamDTO.Players.Add(playerDTO);
                        }
                }
                teamsDTO.Add(teamDTO);
                

                
            }
        }

        return teamsDTO;
    }

    public TeamDTO GetById(int id)
    {
        TeamDTO teamDTO = new TeamDTO();

        using (UnitOfWork unitOfWork = new UnitOfWork())
        {
            Team team = unitOfWork.TeamRepository.GetByID(id);

            if (team != null)
            {
                teamDTO.Title = team.Title;
                teamDTO.Country = team.Country;
                // teamDTO.Players = team.Players;
            }

            return teamDTO;
        }
    }

    public bool Save(TeamDTO teamDTO)
    {
        Team team = new Team
        {
            Title = teamDTO.Title,
            Country = teamDTO.Country
        };

        try
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                unitOfWork.TeamRepository.Insert(team);
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
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                unitOfWork.TeamRepository.Delete(id);
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
