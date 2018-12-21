using System.Collections.Generic;
using System.Linq;

namespace VamosAJogo.Core.Model
{
    public class Player : BaseEntity
    {
        protected Player(string name)
        {
            Name = name;
            Teams = new HashSet<Team>();
            FriendShips = new HashSet<PlayerFriendship>();
        }

        public string Name { get; protected set; }

        public ICollection<Team> Teams { get; protected set; }

        public ICollection<PlayerFriendship> FriendShips { get; protected set; }
        
        public static Player CreatePlayer(string name)
        {
            return new Player(name);
        }

        public IEnumerable<Player> Friends => FriendShips.Select<PlayerFriendship, Player>(fs => fs.FirstFriend.Id == this.Id ? fs.SecondFriend : fs.FirstFriend);

        public void AddFriend(Player newFriend)
        {
            if (Friends.Any(f => f.Id == newFriend.Id))
                throw new ModelException("Players are already Friends");

        }
    }
}
