namespace Server.Logging
{
	#region Using
	using System;
	#endregion
	[Serializable]
	public class Exception
	{
		public string ExceptionType { get; set; }
		public string Message { get; set; }
		public string StackTrace { get; set; }
		public Exception InnerException { get; set; }

		public Exception(System.Exception ex)
		{
			this.ExceptionType = ex.GetType().ToString();
			this.Message = ex.Message;
			this.StackTrace = ex.StackTrace;

			this.InnerException = ex.InnerException == null ? null : new Exception(ex.InnerException);
		}
	}
}
