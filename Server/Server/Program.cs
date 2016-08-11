namespace Server
{
	#region Using
	using System.Collections.Generic;
	using Commands;
	using System;
	#endregion
	class Program
	{
		static List<ServerCommand> serverCommands = new List<ServerCommand>();
		static void Main(string[] args)
		{
			AddCommands();

			while(true)
			{
				string command = Console.ReadLine();

				if(command.ToLower() =="exit")
				{
					break;
				}
			}
		}

		static void AddCommands()
		{
			serverCommands.Add(new HelpCommand(serverCommands));
		}
	}
}
