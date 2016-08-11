namespace Server.Commands.Exceptions
{
	#region Using
	using System;
	#endregion
	class ParameterException : Exception
	{
		public override string StackTrace
		{
			get
			{
				return Environment.StackTrace;
			}
		}

		public ParameterException(string message) :
			base(message)
		{
			
		}
	}
}
