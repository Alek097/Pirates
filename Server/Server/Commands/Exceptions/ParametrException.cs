namespace Server.Commands.Exceptions
{
	#region Using
	using System;
	#endregion
	class ParametrException : Exception
	{
		public override string StackTrace
		{
			get
			{
				return Environment.StackTrace;
			}
		}

		public ParametrException(string message) :
			base(message)
		{
			
		}
	}
}
