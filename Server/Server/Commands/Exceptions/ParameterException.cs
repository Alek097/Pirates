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

		public Parameter Parameter { get; private set; }

		public ParameterException(string message, Parameter parameter)
			: base(message)
		{
			this.Parameter = parameter;
		}
	}
}
