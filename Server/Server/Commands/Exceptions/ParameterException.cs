namespace Server.Commands.Exceptions
{
	class ParameterException : ServerException
	{
		public Parameter Parameter { get; private set; }

		public ParameterException(string message, Parameter parameter)
			: base(message)
		{
			this.Parameter = parameter;
		}

		public override string ToString()
		{
			return string.Format("{0}\nParametr: {1}", base.ToString(), this.Parameter);
		}
	}
}
