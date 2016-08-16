namespace Server.Commands
{
	#region Using
	using System;
	using Informations;
	using Data;
	using Models;
	using System.Linq;
	using Exceptions;
	#endregion
	class UserInfoCommand : ServerCommand
	{
		public UserInfoCommand()
			: base("UserInfo",
				 "View user(s) information.",
				 new ParameterInformation[] { new ParameterInformation("User", "The user that you want to see.", Informations.ValueType.String, false) })
		{

		}

		public override void Start(params Parameter[] parameters)
		{
			if (parameters.Length == 0)
			{
				using (ServerDB db = new ServerDB())
				{
					foreach (Player item in db.Players)
					{
						Console.WriteLine(item);
					}
				}
			}
			else
			{
				Parameter parameter = parameters.FirstOrDefault(p => p.Name.ToLower() == "user");

				if (parameter == null)
				{
					throw new ParameterException(string.Format("The {0} is not a command parameter.", parameters[0].Name), parameters[0]);
				}
				else
				{
					using (ServerDB db = new ServerDB())
					{
						Player player = db.Players.FirstOrDefault(p => p.NickName == parameter.Value.ToString());
						if (player == null)
						{
							throw new ServerException(string.Format("User with nickname {0} not found.", parameter.Value));
						}
						else
						{
							Console.WriteLine(player);
						}
					}
				}
			}
		}
	}
}
