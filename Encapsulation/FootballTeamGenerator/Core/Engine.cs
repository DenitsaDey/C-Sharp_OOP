using FootballTeamGenerator.Common;
using FootballTeamGenerator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FootballTeamGenerator.Core
{
    public class Engine
    {
        private readonly ICollection<Team> teams;

        public Engine()
        {
            this.teams = new List<Team>();
        }

        public void Run()
        {
            string command = string.Empty;

            while ((command = Console.ReadLine()) != "END")
            {
                string[] arguments = command.Split(";");
                string cmndType = arguments[0];
                try
                {
                    List<string> cmndParams = arguments.Skip(1).ToList();


                    if (cmndType == "Team")
                    {
                        this.CreateTeam(cmndParams);
                    }
                    else if (cmndType == "Add")
                    {
                        this.AddPlayerToTeam(cmndParams);
                    }
                    else if (cmndType == "Remove")
                    {
                        this.RemovePlayerFromTeam(cmndParams);
                    }
                    else if (cmndType == "Rating")
                    {
                        this.RateTeam(cmndParams);
                    }

                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }
            }
        }

        private void CreateTeam(IList<string> arguments)
        {
            string teamName = arguments[0];
            Team team = new Team(teamName);
            this.teams.Add(team);
        }

        private void RateTeam(IList<string> arguments)
        {
            string teamName = arguments[0];

            this.ValidateTeamexists(teamName);

            Team team = this.teams.First(t => t.Name == teamName);

            Console.WriteLine(team);
        }

        private void RemovePlayerFromTeam(IList<string> arguments)
        {
            string teamName = arguments[0];
            string playerName = arguments[1];

            this.ValidateTeamexists(teamName);

            Team team = this.teams.First(t => t.Name == teamName);

            team.RemovePlayer(playerName);

        }

        private void AddPlayerToTeam(IList<string> arguments)
        {
            string teamName = arguments[0];
            string playerName = arguments[1];

            this.ValidateTeamexists(teamName);
 
            Statistics stats = this.BuildStats(arguments.Skip(2).ToArray());

            Player player = new Player(playerName, stats);

            Team team = this.teams.First(t => t.Name == teamName);

            team.AddPlayer(player);

        }

        private Statistics BuildStats(string[] statsString)
        {
            int endurance = int.Parse(statsString[0]);
            int sprint = int.Parse(statsString[1]);
            int dribble = int.Parse(statsString[2]);
            int passing = int.Parse(statsString[3]);
            int shooting = int.Parse(statsString[4]);

            Statistics stats = new Statistics(endurance, sprint, dribble, passing, shooting);
            return stats;
        }

        private void ValidateTeamexists(string teamName)
        {
            if (!this.teams.Any(t => t.Name == teamName))
            {
                throw new InvalidOperationException(String.Format(GlobalConstants.MissingTeamExcMsg, teamName));
            }
        }
    }
}
