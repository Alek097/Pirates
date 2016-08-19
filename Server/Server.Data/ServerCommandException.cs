namespace Server.Commands.Exceptions
{
	class ServerCommandException : ServerException
	{
		public string Command { get; private set; }


		public ServerCommandException(string message, string commandName)
			: base(message)
		{
			this.Command = commandName;
		}

		public override string ToString()
		{
			return string.Format("{0}\n Command: {1}", base.ToString(), this.Command);
		}
	}
}
