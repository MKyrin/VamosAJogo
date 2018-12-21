using System;
using System.Collections.Generic;
using System.Linq;

namespace VamosAJogo.Core.Model
{
    /// <summary>
    /// Represents A match being organized among team mates
    /// </summary>
    public class SportEvent : BaseEntity
    {
        protected SportEvent(Player organizer, Team team, string sport, string location, int minConfirmedPlayers)
        {
            Sport = sport;
            Location = location;
            MinConfirmedPlayers = minConfirmedPlayers;
            Organizer = organizer;
            Team = team;
            Calls = new HashSet<SportEventCall>();
        }

        public string Sport { get; protected set; }

        public string Location { get; protected set; }

        public int MinConfirmedPlayers { get; protected set; }

        public Player Organizer { get; protected set; }

        public Team Team { get; set; }

        public ICollection<SportEventCall> Calls { get; set; }

        /// <summary>
        /// Creates a new Match with all invites for the team.
        /// </summary>
        /// <param name="organizer">The person organizing the match</param>
        /// <param name="team">The Team participating in the match</param>
        /// <param name="sport">The sport being played</param>
        /// <param name="location">Where the event is happening</param>
        /// <param name="minConfirmedPlayers">The minimum amount of player for the event to happen</param>
        /// <returns></returns>
        public static SportEvent CreateSportEvent(Player organizer, Team team, string sport, string location, int minConfirmedPlayers)
        {
            if (minConfirmedPlayers <= 0)
            {
                throw new ModelException("Minimum Confirmed Players must be greater than zero.");
            }

            SportEvent match = new SportEvent(
                organizer ?? throw new ArgumentNullException(nameof(organizer)),
                team ?? throw new ArgumentNullException(nameof(team)),
                sport ?? throw new ArgumentNullException(nameof(sport)),
                location ?? throw new ArgumentNullException(nameof(location)),
                minConfirmedPlayers);

            // Create Organizer Call as confirmed

            match.Calls.Add(SportEventCall.CreateCall(organizer, CallStatus.Going));

            // Invite rest of the Team
            foreach (var player in match.Team.TeamPlayers)
            {
                match.Calls.Add(SportEventCall.CreateCall(player, CallStatus.Unanswered));
            }

            return match;
        }

        public void AddCallToNonTeamMember(Player player)
        {
            if (Calls.Any(c => c.Player.Id == player.Id))
            {
                throw new ModelException("Player has already been called.");
            }

            Calls.Add(SportEventCall.CreateCall(player, CallStatus.Unanswered));
        }
    }
}
