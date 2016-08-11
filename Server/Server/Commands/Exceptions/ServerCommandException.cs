namespace Server.Commands.Exceptions
{
	#region Using
	using System;
	#endregion
	class ServerCommandException : ServerException
	{
		public ServerCommand Command { get; private set; }


		public ServerCommandException(string message, ServerCommand command)
			: base(message)
		{
			this.Command = command;
		}

		public override string ToString()
		{
			return string.Format("{0}\n Command: {1}\nUse the command help.", base.ToString(), this.Command.Name);
		}
	}
}
