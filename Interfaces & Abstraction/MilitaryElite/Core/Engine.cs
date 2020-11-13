using MilitaryElite.Core.Contracts;
using MilitaryElite.Exceptions;
using MilitaryElite.Interface;
using MilitaryElite.IO.Contarcts;
using MilitaryElite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MilitaryElite.Core
{
    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;

        private ICollection<ISoldier> soldiers;

        private Engine()
        {
            this.soldiers = new List<ISoldier>();
        }
        
        public Engine(IReader reader, IWriter writer)
            :this()
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            string input;
            while((input = this.reader.ReadLine()) != "End")
            {
                string[] cmdArgs = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string soldierType = cmdArgs[0];
                string id = cmdArgs[1];
                string firstName = cmdArgs[2];
                string lastName = cmdArgs[3];

                ISoldier soldier = null;

                switch (soldierType)
                {
                    case "Private":
                        IPrivate @private = new Private(id, firstName, lastName, decimal.Parse(cmdArgs[4]));
                        soldier = @private;

                        break;
                    case "LieutenantGeneral":
                        ILieutenantGeneral currentGeneral = new LieutenantGeneral(id, firstName, lastName, decimal.Parse(cmdArgs[4]));

                        foreach (var pid in cmdArgs.Skip(5))
                        {
                            ISoldier currentPrivate = (Private)soldiers.FirstOrDefault(s => s.Id == pid);
                            if (currentPrivate != null)
                            {
                                currentGeneral.AddPrivate(currentPrivate);
                            }
                        }
                        soldier = currentGeneral;

                        break;
                    case "Engineer":
                        try
                        {
                            IEngineer currentEngineer = new Engineer(id, firstName, lastName, decimal.Parse(cmdArgs[4]), cmdArgs[5]);
                            string[] repairArgs = cmdArgs.Skip(6).ToArray();

                            for (int i = 0; i < repairArgs.Length; i += 2)
                            {
                                IRepair currentRepair = new Repair(repairArgs[i], int.Parse(repairArgs[i + 1]));
                                currentEngineer.AddRepair(currentRepair);
                            }

                            soldier = currentEngineer;

                        }
                        catch (InvalidCoprsException ice)
                        {
                            continue;
                        }
                        
                        break;
                    case "Commando":
                        try
                        {
                            ICommando commando = new Commando(id, firstName, lastName, decimal.Parse(cmdArgs[4]), cmdArgs[5]);
                            string[] missionArgs = cmdArgs.Skip(6).ToArray();

                            for (int i = 0; i < missionArgs.Length; i += 2)
                            {
                                try
                                {
                                    Imission currentMission = new Mission(missionArgs[i], missionArgs[i + 1]);
                                    commando.AddMission(currentMission);
                                }
                                catch (InvalidStateException ise)
                                {
                                    continue;
                                }
                                
                            }

                            soldier = commando;

                        }
                        catch (InvalidCoprsException ice)
                        {
                            continue;
                        }
                        break;
                    case "Spy":
                        soldier = new Spy(id, firstName, lastName, int.Parse(cmdArgs[4]));
                        break;
                }
                if(soldier != null)
                {
                    soldiers.Add(soldier);
                }
            }
            foreach (var soldier in this.soldiers)
            {
                this.writer.WriteLine(soldier.ToString());
            }
        }
    }
}
