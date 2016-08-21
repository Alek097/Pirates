namespace Server.Exceptions
{
	#region Using
	using Logging;
	#endregion
	public class FatalServerException : ServerException
	{
		public new System.Exception InnerException { get; private set; }
		public Log Log { get; private set; }
		public FatalServerException(string message, Log log)
			: base(message)
		{

		}
		public FatalServerException(string message, Log log, System.Exception innerEx)
			: base(message)
		{
			this.Log = log;
		}

		public override string ToString()
		{
			return string.Format("{0}\nLog:\n{1}", base.ToString(), this.Log);
		}
	}
}
