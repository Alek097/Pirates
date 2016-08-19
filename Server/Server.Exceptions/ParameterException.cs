namespace Server.Exceptions
{
	public class ParameterException : ServerException
	{
		public Parameter Parameter { get; private set; }

		public ParameterException(string message, Parameter parameter)
			: base(message)
		{
			this.Parameter = parameter;
		}

		public ParameterException(string message)
			: base(message)
		{

		}

		public override string ToString()
		{
			if(this.Parameter == null)
			{
				return base.ToString();
			}
			else
			{
				return string.Format("{0}\nParametr: {1}", base.ToString(), this.Parameter);
			}
		}
	}
}
