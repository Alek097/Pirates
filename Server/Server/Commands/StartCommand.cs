namespace Server.Commands
{
	#region Using
	using System.Collections.Concurrent;
	using Server.Commands.Informations;
	#endregion
	class StartCommand : ServerCommand
	{
		public StartCommand()
			: base("Start", "Starting server.", new ParameterInformation[0])
		{
		}

		public override void Start(params Parameter[] parameters)
		{

		}
	}
}
