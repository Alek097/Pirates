namespace Server.Commands
{

	#region Using
	using Informations;
	using Exceptions;
	using System.Linq;
	using Data;
	using Data.Models;
	#endregion
	class SetRoleCommand : ServerCommand
	{
		public SetRoleCommand()
			: base(
				"SetRole",
				"Setting role of user.",
				new ParameterInformation[]
				{
					new ParameterInformation("User", "Nick name of user.", Informations.ValueType.String, true),
					new ParameterInformation("Role", "Level of role. 1 - Player / 2 - Moderator / 3 - Administration", Informations.ValueType.Number, true)
				})
		{

		}

		public override void Start(params Parameter[] parameters)
		{
			Parameter parameterUser = parameters.FirstOrDefault(p => p.Name.ToLower() == "user");
			Parameter parameterRole = parameters.FirstOrDefault(p => p.Name.ToLower() == "role");

			if (parameterUser == null)
			{
				throw new ParameterException("Parameter user not found.");
			}
			else if (parameterRole == null)
			{
				throw new ParameterException("Parameter role not found.");
			}
			else
			{
				if (parameterRole.ValueType != typeof(double))
				{
					throw new ParameterException(string.Format("Parameter role has an invalid type {0}.", parameterRole.ValueType));
				}

				int role = (int)((double)parameterRole.Value);

				if(role > 3 || role < 1)
				{
					throw new ParameterException(string.Format("Parameter role has an invalid value {0}. 1 - Player / 2 - Moderator / 3 - Administration", role));
				}
				using (ServerDB db = new ServerDB())
				{
					Player player = db.Players.FirstOrDefault(p => p.NickName == parameterUser.Value.ToString());
					if(player == null)
					{
						throw new ServerException(string.Format("User with nickname {0} not found.", parameterUser.Value));
					}
					else
					{
						player.Role = (Role)role;
						db.Update(player);
					}
				}
			}
		}
	}
}
