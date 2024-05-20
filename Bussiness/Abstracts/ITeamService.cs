using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Abstracts
{
    public  interface ITeamService
    {
        void Create(Team team);
        void Delete(int id);
        void Update (int id,Team team);
        Team GetTeam(Func<Team, bool>? func=null);
        List<Team> GetAllTeams(Func<Team,bool> ? func=null);
    }
}
