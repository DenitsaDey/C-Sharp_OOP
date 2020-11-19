using CommandPattern.Core.Commands;
using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CommandPattern.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] inputArgs = args.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            
            string commandName = (inputArgs[0] + "Command").ToLower();
            string[] commandArgs = inputArgs.Skip(1).ToArray();

            var commandType = Assembly.GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(n=>n.Name.ToLower() == commandName.ToLower());
            if (commandType == null)
            {
                throw new ArgumentException("Invalid command type!");
            }

            var instanceType = Activator.CreateInstance(commandType) as ICommand; 
            
            if(instanceType == null)
            {
                throw new ArgumentException("Invalid command type!");
            }
            string result = instanceType.Execute(commandArgs);
            return result;
        }
    }
}
