using CounterStrike.Models.Maps.Contracts;
using CounterStrike.Models.Players.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CounterStrike.Models.Maps
{
    public class Map : IMap
    {
        private ICollection<IPlayer> terrorists;
        private ICollection<IPlayer> counterTerrorists;

        public string Start(ICollection<IPlayer> players)
        {
            this.terrorists = players.Where(p => p.GetType().Name == "Terrorist").ToList();
            this.counterTerrorists = players.Where(p => p.GetType().Name == "CounterTerrorist").ToList();

            while (this.terrorists.Any(x => x.IsAlive) && this.counterTerrorists.Any(x => x.IsAlive))
            {
                foreach (var terrorist in this.terrorists)
                {
                    if (!terrorist.IsAlive)
                    {
                        continue;
                    }
                    int currDamage = terrorist.Gun.Fire();

                    foreach (var counterT in this.counterTerrorists)
                    {
                        counterT.TakeDamage(currDamage);
                    }

                }

                foreach (var counterT in this.counterTerrorists)
                {
                    if (!counterT.IsAlive)
                    {
                        continue;
                    }
                    int currDamage = counterT.Gun.Fire();

                    foreach (var terrorist in this.terrorists)
                    {
                        terrorist.TakeDamage(currDamage);
                    }

                }
            }

            string result = "";
            if (terrorists.Any(x => x.IsAlive))
            {
                result = "Terrorist wins!";
            }
            else if (counterTerrorists.Any(x => x.IsAlive))
            {
                result = "Counter Terrorist wins!";
            }
            return result;
        }
    }
}
