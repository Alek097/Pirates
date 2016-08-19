namespace Server.Commands.Exceptions
{
	#region Using
	using System;
	#endregion
	class FotalServerException : ServerException
	{
		public new Exception InnerException { get; private set; }
		public FotalServerException(string message, Exception innerEx)
			: base(message)
		{
			this.InnerException = innerEx;
		}
		public FotalServerException(string message)
			: base(message)
		{

		}
	}
}
