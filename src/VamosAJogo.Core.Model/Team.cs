using System.Collections.Generic;
using System.Linq;

namespace VamosAJogo.Core.Model
{
    public class Team : BaseEntity
    {
        protected Team(string name)
        {
            TeamPlayers = new HashSet<Player>();
            Name = name;
        }
        public string Name { get; protected set; }

        public ICollection<Player> TeamPlayers { get; protected set; }

        public static Team createTeam(Player teamCreator, string name)
        {
            var team = new Team(name);

            team.TeamPlayers.Add(teamCreator);

            return team;
        }

        public void AddTeamPlayer(Player newTeamPlayer)
        {
            if (TeamPlayers.Any(p => p.Id == newTeamPlayer.Id))
            {
                throw new ModelException("Player already in team.");
            }
            TeamPlayers.Add(newTeamPlayer);
        }

    }
}
