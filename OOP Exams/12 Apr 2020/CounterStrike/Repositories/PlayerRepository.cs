using CounterStrike.Models.Players.Contracts;
using CounterStrike.Repositories.Contracts;
using CounterStrike.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CounterStrike.Repositories
{
    public class PlayerRepository : IRepository<IPlayer>
    {
        private readonly ICollection<IPlayer> models;
        
        public PlayerRepository()
        {
            this.models = new List<IPlayer>();
        }
        
        public IReadOnlyCollection<IPlayer> Models => (IReadOnlyCollection<IPlayer>)this.models;

        public void Add(IPlayer player)
        {
            if (player == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidPlayerRepository);
            }
            this.models.Add(player);
        }

        public IPlayer FindByName(string name)
        {
            return this.models.FirstOrDefault(x => x.Username == name);
        }

        public bool Remove(IPlayer player)
        {
            return this.models.Remove(player);
        }
    }
}
