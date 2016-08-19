﻿
namespace Server.Exceptions
{
	#region Using
	using System;
	#endregion
	public class ServerException : Exception
	{
		public override string StackTrace
		{
			get
			{
				return Environment.StackTrace;
			}
		}

		public ServerException(string message)
			: base(message)
		{

		}

		public override string ToString()
		{
			return string.Format("Type: {0}\nMessage: {1}\nStack trace:{2}", this.GetType(), base.Message, this.StackTrace);
		}
	}
}
