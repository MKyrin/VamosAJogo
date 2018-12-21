using System.Linq;

namespace VamosAJogo.Core.Model
{
    public class PlayerFriendship
    {
        public long FirstFriendId { get; protected set; }

        public Player FirstFriend { get; protected set; }

        public Player SecondFriend { get; protected set; }

        public long SecondFriendId { get; protected set; }


        public static PlayerFriendship CreateFriendship(Player firstPlayer, Player secondPlayer)
        {
            if (firstPlayer.FriendShips.Any(fs => fs.FirstFriend.Id == secondPlayer.Id || fs.SecondFriend.Id == secondPlayer.Id))
                throw new ModelException("Players are already friends");

            return new PlayerFriendship()
            {
                FirstFriend = firstPlayer,
                SecondFriend = secondPlayer
            };
        }
    }
}
