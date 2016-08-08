namespace Server.Commands
{
	interface IServerCommand
	{
		void StartCommand();
		string Information();
	}
}
