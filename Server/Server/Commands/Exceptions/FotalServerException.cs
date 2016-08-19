namespace Server.Commands.Exceptions
{
	#region Using
	using Logging;
	#endregion
	class FotalServerException : ServerException
	{
		public new System.Exception InnerException { get; private set; }
		public Log Log { get; private set; }
		public FotalServerException(string message, System.Exception innerEx)
			: base(message)
		{
			this.InnerException = innerEx;
		}
		public FotalServerException(string message)
			: base(message)
		{

		}

		public FotalServerException(string message, Log log)
			: base(message)
		{
			this.Log = log;
		}
	}
}
