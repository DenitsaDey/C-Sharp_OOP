using FootballTeamGenerator.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace FootballTeamGenerator.Models
{
    public class Statistics
    {
        private const int MinStat = 0;
        private const int MaxStat = 100;
        private const double StatCount = 5;


        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Statistics(int endurance, int sprint, int dribble, int passing, int shooting)
        {
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shooting;
        }

        public int Endurance
        {
            get => this.endurance;
            private set
            {
                ValidateStat(nameof(Endurance), value);
                this.endurance = value;
            }
        }

        public int Sprint
        {
            get => this.sprint;
            private set
            {
                ValidateStat(nameof(Sprint), value);
                this.sprint = value;
            }
        }

        public int Dribble
        {
            get => this.dribble;
            private set
            {
                ValidateStat(nameof(Dribble), value);
                this.dribble = value;
            }
        }

        public int Passing
        {
            get => this.passing;
            private set
            {
                ValidateStat(nameof(Passing), value);
                this.passing = value;
            }
        }

        public int Shooting
        {
            get => this.shooting;
            private set
            {
                ValidateStat(nameof(Shooting), value);
                this.shooting = value;
            }
        }

        public double AverageStat => (this.Endurance + this.Sprint + this.Dribble + this.Passing + this.Shooting)/StatCount;

        private void ValidateStat(string name, int value)
        {
            if (value < MinStat || value > MaxStat)
            {
                throw new ArgumentException(String.Format(GlobalConstants.InvalidStatExcMsg, name, MinStat, MaxStat));
            }
        }


    }
}
