namespace Server.Data.Models
{
	#region Using
	using System;
	using System.ComponentModel.DataAnnotations.Schema;
	#endregion
	public class Player
	{
		public Guid Id { get; set; }
		public string Email { get; set; }
		public string NickName { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string FullName { get; set; }
		[Column("Role")]
		public string RoleString
		{
			get
			{
				return _roleString;
			}
			set
			{
				this._roleString = value;
				this._role = (Role)Enum.Parse(typeof(Role), value);
			}
		}
		[Column("Status")]
		public string StatusString
		{
			get
			{
				return _statusString;
			}
			set
			{
				this._statusString = value;
				this._status = (Status)Enum.Parse(typeof(Status), value);
			}
		}
		[NotMapped]
		public Role Role
		{
			get
			{
				return _role;
			}
			set
			{
				_role = value;
				_roleString = value.ToString();
			}
		}
		[NotMapped]
		public Status Status
		{
			get
			{
				return _status;
			}
			set
			{
				_status = value;
				_statusString = value.ToString();
			}
		}

		private Role _role;
		private Status _status;
		private string _roleString;
		private string _statusString;

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
Status: {4};
------------------------------------
"
			, this.NickName, this.FullName, this.Email, this.Role, this.Status);
		}
	}
}
