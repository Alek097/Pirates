namespace Server.Data.Models
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
		public  Role Role { get; set; }
		public Status Status { get; set; }

		public Player(Pirates.Model.Player player)
		{
			this.Id = player.Id;
			this.Email = player.Email;
			this.NickName = player.NickName;
			this.FirstName = player.FirstName;
			this.LastName = player.LastName;
			this.FullName = player.FirstName;
			this.Role = Role.Player;
		}

		public Player()
		{

		}

		public override string ToString()
		{
			return string.Format(
@"
NickName:{0};
Full name: {1};
E-mail:{2};
Role: {3};
------------------------------------
"
			, this.NickName, this.FullName, this.Email, this.Role);
		}
	}
}
