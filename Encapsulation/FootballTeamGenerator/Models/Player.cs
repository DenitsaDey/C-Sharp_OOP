using FootballTeamGenerator.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace FootballTeamGenerator.Models
{
    public class Player
    {
        private string name;

        public Player(string name, Statistics stats)
        {
            this.Name = name;
            this.Stats = stats;
        }

        public string Name {
            get => this.name;
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(GlobalConstants.InvalidNameExcMsg);
                }
                this.name = value;
            } 
        }

        public Statistics Stats { get; set; }

        public double OverallSkill => this.Stats.AverageStat;
    }
}
