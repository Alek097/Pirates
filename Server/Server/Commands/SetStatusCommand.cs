using System;

namespace Server.Commands
{
	#region Using
	using Informations;
	using System.Linq;
	using Exceptions;
	using Data;
	using Data.Models;
	#endregion
	class SetStatusCommand : ServerCommand
	{
		public SetStatusCommand()
			:base("SetStatus",
				 "Setting status of user",
				 new ParameterInformation[]
				{
					new ParameterInformation("User", "Nick name of user.", Informations.ValueType.String, true),
					new ParameterInformation("Status", "1 - OK / 2 - Muted / 3 - Locked", Informations.ValueType.Number, true)
				})
		{

		}
		public override void Start(params Parameter[] parameters)
		{
			Parameter parameterUser = parameters.FirstOrDefault(p => p.Name.ToLower() == "user");
			Parameter parameterStatus = parameters.FirstOrDefault(p => p.Name.ToLower() == "status");

			if (parameterUser == null)
			{
				throw new ParameterException("Parameter user not found.");
			}
			else if (parameterStatus == null)
			{
				throw new ParameterException("Parameter status not found.");
			}
			else
			{
				if (parameterStatus.ValueType != typeof(double))
				{
					throw new ParameterException(string.Format("Parameter status has an invalid type {0}.", parameterStatus.ValueType));
				}

				int status = (int)((double)parameterStatus.Value);

				if (status > 3 || status < 1)
				{
					throw new ParameterException(string.Format("Parameter status has an invalid value {0}.  1 - OK / 2 - Muted / 3 - Locked", status));
				}
				using (ServerDB db = new ServerDB())
				{
					Player player = db.Players.FirstOrDefault(p => p.NickName == parameterUser.Value.ToString());
					if (player == null)
					{
						throw new ServerException(string.Format("User with nickname {0} not found.", parameterUser.Value));
					}
					else
					{
						player.Status = (Status)status;
						db.Update(player);
					}
				}
			}
		}
	}
}
