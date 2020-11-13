using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Interface
{
    public interface ICommando : ISpecialisedSoldier
    {
        public IReadOnlyCollection<Imission> Missions { get; }

        void AddMission(Imission mission);
    }
}
