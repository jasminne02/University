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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Team" in both code and config file together.
    public class Team : ITeam
    {
        // call the service
        private TeamManagementService teamService = new TeamManagementService();
        public List<TeamDTO> GetTeams()
        {
            return teamService.Get();
        }

        public TeamDTO GetTeamByID(int id)
        {
            return teamService.GetById(id);
        }
        public string PostTeam(TeamDTO teamDTO)
        {
            if (teamService.Save(teamDTO))
            {
                return "Team has been saved!";
            }
            else
            {
                return "Team has not been saved!";
            }
        }
        public string DeleteTeam(int id)
        {
            if (teamService.Delete(id))
            {
                return "Team has been deleted!";
            }
            else
            {
                return "Team has not been deleted!";
            }
        }
    }
}
