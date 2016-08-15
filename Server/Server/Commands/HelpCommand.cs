namespace Server.Commands
{
	#region Using
	using System;
	using Informations;
	using Exceptions;
	using System.Collections.Generic;
	using System.Linq;
	#endregion
	class HelpCommand : ServerCommand
	{
		private List<ServerCommand> commands;
		private const string line = "----------------------------------------------------";

		public HelpCommand(List<ServerCommand> commands)
			: base(
				"Help",
				"View information of commnd(s)",
				new ParameterInformation[] { new ParameterInformation("CommandName", "Name of commnd", Informations.ValueType.String, false) }
				)
		{
			this.commands = commands;
		}

		public override void Start(params Parameter[] parameters)
		{
			if (parameters.Length > 0)
			{
				Parameter parameter = parameters.FirstOrDefault(p => p.Name.ToLower() == "commandname");

				if (parameter == null)
				{
					throw new ParameterException(string.Format("The {0} is not a command parameter.", parameters[0].Name), parameters[0]);
				}
				else
				{
					ServerCommand command = this.commands.FirstOrDefault(c => c.Name.ToLower() == ((string)parameter.Value).ToLower());

					if (command == null)
					{
						throw new ParameterException(string.Format("The command {0} is not found.", parameter.Value), parameter);
					}
					else
					{
						Console.WriteLine(line);
						Console.WriteLine(command.Information());
					}
				}
			}
			else
			{
				foreach (ServerCommand command in this.commands)
				{
					Console.WriteLine(line);
					Console.WriteLine(command.Information());
				}
			}
		}
	}
}
