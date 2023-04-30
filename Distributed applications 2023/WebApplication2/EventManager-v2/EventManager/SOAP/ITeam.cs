using ApplicationService.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SOAP
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ITeam" in both code and config file together.
    [ServiceContract]
    public interface ITeam
    {
        [OperationContract]
        List<TeamDTO> GetTeams();
        [OperationContract]
        TeamDTO GetTeamByID(int id);
        [OperationContract]
        string PostTeam(TeamDTO teamDTO);
        [OperationContract]
        string DeleteTeam(int id);
    }
}
