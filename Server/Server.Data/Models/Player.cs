namespace Server.Models
{
	#region Using
	using System;
	#endregion
	public class Player
	{
		public Guid Id { get; set; }
		public string Email { get; set; }
		public string NickName { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string FullName { get; set; }
		public virtual Role Role { get; set; }
	}
}
