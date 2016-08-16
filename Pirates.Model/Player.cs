namespace Pirates.Model
{
	#region Using
	using System;
	#endregion
	[Serializable]
	public class Player
	{
		public Guid Id { get; set; }
		public string Email { get; set; }
		public string NickName { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string FullName { get; set; }

		public Player(string nickName, string email, string firstName, string lastName)
		{
			this.Id = Guid.NewGuid();
			this.NickName = nickName;
			this.Email = email;
			this.FirstName = firstName;
			this.LastName = lastName;
			this.FullName = string.Format("{0} {1}", firstName, lastName);
		}
	}
}
