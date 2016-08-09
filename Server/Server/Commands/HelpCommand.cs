namespace Server.Commands
{
	#region Using
	using System;
	using System.Collections.Generic;
	#endregion
	class HelpCommand : ServerCommand
	{
		private List<ServerCommand> commands;

		public HelpCommand(List<ServerCommand> commands)
		{
			this.commands = commands;
			base.Name = "Help";
		}

		public override string Information()
		{
			return @"";
		}

		public string LiteInformation()
		{
			throw new NotImplementedException();
		}

		public override void StartCommand(params string[] parametrs)
		{
			throw new NotImplementedException();
		}
	}
}
