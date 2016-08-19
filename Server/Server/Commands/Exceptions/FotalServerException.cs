namespace Server.Commands.Exceptions
{
	#region Using
	using Logging;
	#endregion
	class FotalServerException : ServerException
	{
		public new System.Exception InnerException { get; private set; }
		public Log Log { get; private set; }
		public FotalServerException(string message, Log log)
			: base(message)
		{

		}

		public FotalServerException(string message, Log log , System.Exception innerEx)
			: base(message)
		{
			this.Log = log;
		}
	}
}
