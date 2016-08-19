﻿namespace Server.Logging
{
	#region Using
	using System;
	using System.ComponentModel.DataAnnotations.Schema;
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
		public DateTime Date { get; set; }
		[Column("Level")]
		public string LevelString
		{
			get
			{
				return _levelString;
			}
			set
			{
				_levelString = value;
				_level = (LogLevel)Enum.Parse(typeof(LogLevel), value);
			}
		}
		[NotMapped]
		public LogLevel Level
		{
			get
			{
				return _level;
			}
			set
			{
				_level = value;
				_levelString = value.ToString();
			}
		}

		private LogLevel _level;
		private string _levelString;

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
		public override string ToString()
		{
			return string.Format(
@"
Id: {0}
Date: {1}
Thread id: {2}
Exception type: {3}
Message: {4}
Level: {5}
Exception:
{6}
", 
			this.Id,
			this.Date,
			this.ThreadId,
			this.ExceptionType,
			this.Message,
			this.Level,
			this.Exception);
		}
	}
}
