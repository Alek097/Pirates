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
		private ParameterInformation[] parameters = new ParameterInformation[] { new ParameterInformation("CommandName", "Name of commnd", Informations.ValueType.String, false) };
		private const string line = "----------------------------------------------------";

		public HelpCommand(List<ServerCommand> commands)
		{
			this.commands = commands;
			base.Name = "Help";
		}

		protected override ParameterInformation[] Parameters
		{
			get
			{
				return this.parameters;
			}
		}

		public override InformationBuilder Information()
		{
			return new InformationBuilder(
				this.Name,
				"View information of commnd(s)",
				this.Parameters
				);
		}

		public override void Start(params Parameter[] parameters)
		{
			if (parameters.Length > 0)
			{
				Parameter parameter = parameters.FirstOrDefault(p => p.Name.ToLower() == "commandname");

				if (parameter == null)
				{
					throw new ParameterException(string.Format("The {0} is not a command parameter", parameters[0].Name), parameters[0]);
				}
				else
				{
					ServerCommand command = this.commands.FirstOrDefault(c => c.Name == (string)parameter.Value);

					if (command == null)
					{
						Console.ForegroundColor = ConsoleColor.Red;
						Console.WriteLine("Command not found");
						Console.ResetColor();
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
