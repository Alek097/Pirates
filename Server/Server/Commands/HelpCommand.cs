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
		private ParametrInformation[] parametrs = new ParametrInformation[] { new ParametrInformation("CommandName", "Name of commnd", Informations.ValueType.String, false) };
		private const string line = "----------------------------------------------------";

		public HelpCommand(List<ServerCommand> commands)
		{
			this.commands = commands;
			base.Name = "Help";
		}

		protected override ParametrInformation[] Parametrs
		{
			get
			{
				return this.parametrs;
			}
		}

		public override InformationBuilder Information()
		{
			return new InformationBuilder(
				this.Name,
				"View information of commnd(s)",
				this.Parametrs
				);
		}

		public override void StartCommand(params Parametr[] parametrs)
		{
			if (parametrs.Length > 0)
			{
				Parametr parametr = parametrs.FirstOrDefault(p => p.Name.ToLower() == "commandname");

				if (parametr == null)
				{
					throw new ParametrException(string.Format("Parametr with name {0} not found", this.Parametrs[0].Name));
				}
				else
				{
					ServerCommand command = this.commands.FirstOrDefault(c => c.Name == (string)parametr.Value);

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
