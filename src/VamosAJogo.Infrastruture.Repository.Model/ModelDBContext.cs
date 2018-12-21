using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using VamosAJogo.Core.Model;
using System;

namespace VamosAJogo.Infrastruture.Repository.Model
{
    public class ModelDBContext : DbContext
    {
        public ModelDBContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Player> Players;

        public DbSet<PlayerFriendship> PlayerFriendShips;

        public DbSet<SportEvent> SportEvents;

        public DbSet<SportEventCall> SportEventCalls;

        public DbSet<Team> Teams;
    }
}
