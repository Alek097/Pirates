namespace Server
{
	#region Using
	using System.Collections.Generic;
	using Commands;
	using System;
	using System.Linq;
	using Exceptions;
	using Data;
	using Logging;
	#endregion
	class Program
	{
		static List<ServerCommand> serverCommands = new List<ServerCommand>();
		static void Main(string[] args)
		{
			AddCommands();

			while (true)
			{
				string command = Console.ReadLine();

				if (command.ToLower() == "exit")
				{
					break;
				}
				else if (string.IsNullOrWhiteSpace(command))
				{
					continue;
				}
				else
				{
					List<string> commandParts = command.Split(' ').ToList();

					string commandName = commandParts[0];

					commandParts.RemoveAt(0);

					ServerCommand serverCommand = serverCommands.FirstOrDefault(c => c.Name.ToLower() == commandName.ToLower());

					try
					{

						if (serverCommand == null)
						{
							throw new ServerCommandException(
								string.Format("The command: {0} not found.", commandName),
								commandName
								);
						}
						else
						{
							List<Parameter> parameters = new List<Parameter>();

							foreach (string item in commandParts)
							{
								string[] parametrParts = item.Split(':');

								if (parametrParts.Length == 2 && !string.IsNullOrWhiteSpace(parametrParts[0]) && !string.IsNullOrWhiteSpace(parametrParts[1]))
								{
									parameters.Add(new Parameter(parametrParts[0], parametrParts[1]));
								}
								else
								{
									throw new ServerException(string.Format("Command syntax errorr in {0}.", item));
								}
							}

							serverCommand.Start(parameters.ToArray());
						}
					}
					catch (FatalServerException ex)
					{
						Console.ForegroundColor = ConsoleColor.Red;
						Console.WriteLine("Ftal error.");
						Error(ex);
						break;
					}
					catch (ServerException ex)
					{
						Error(ex);

						using (ServerDB db = new ServerDB())
						{
							db.Add<Log>(new Log(ex, ex.Message, LogLevel.Error));
						}
					}
					catch (System.Exception ex)
					{
						Console.ForegroundColor = ConsoleColor.Red;
						Console.WriteLine("Unknown error, see the log");

						Error(ex);

						using (ServerDB db = new ServerDB())
						{
							db.Add<Log>(new Log(ex, ex.Message, LogLevel.Error));
						}
					}
				}
			}
		}

		static void AddCommands()
		{
			serverCommands.Add(new HelpCommand(serverCommands));
			serverCommands.Add(new StartCommand());
			serverCommands.Add(new SetRoleCommand());
			serverCommands.Add(new UserInfoCommand());
			serverCommands.Add(new SetStatusCommand());
		}

		static void Error(System.Exception ex)
		{
			Console.WriteLine();
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine(ex);
			Console.WriteLine("Use the help command.");
			Console.ResetColor();
			Console.WriteLine();
		}
	}
}
