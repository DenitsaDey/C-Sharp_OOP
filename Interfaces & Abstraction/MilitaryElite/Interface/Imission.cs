using MilitaryElite.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Interface
{
    public interface Imission
    {
        public string CodeName { get; }

        public State State { get; }

        void CompleteMission();
    }
}
