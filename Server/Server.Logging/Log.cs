namespace Server.Logging
{
	#region Using
	using System;
	using System.IO;
	using System.Threading;
	using System.Xml.Serialization;
	#endregion
	public class Log
	{
		public Guid Id { get; set; }
		public string Message { get; set; }
		public string ExceptionType { get; set; }
		public string Exception { get; set; }
		public int ThreadId { get; set; }
		public LogLevel Level { get; set; }
		public DateTime Date { get; set; }

		public Log(System.Exception ex, string message, LogLevel logLevel)
		{
			this.Id = Guid.NewGuid();
			this.Message = message;
			this.ExceptionType = ex.GetType().ToString();
			this.Level = logLevel;
			this.Date = DateTime.Now;
			this.ThreadId = Thread.CurrentThread.ManagedThreadId;

			Server.Logging.Exception seriException = new Exception(ex);

			XmlSerializer serilizer = new XmlSerializer(typeof(Server.Logging.Exception));

			using (TextWriter writer = new StringWriter())
			{
				serilizer.Serialize(writer, seriException);

				this.Exception = writer.ToString();
			}
		}
		public Log()
		{

		}
	}
}
