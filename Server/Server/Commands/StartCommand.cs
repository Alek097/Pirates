using System;
using Server.Commands.Informations;

namespace Server.Commands
{
	class StartCommand : ServerCommand
	{
		private ParameterInformation[] parameters = new ParameterInformation[0];
		protected override ParameterInformation[] Parameters
		{
			get
			{
				return parameters;
			}
		}

		public override InformationBuilder Information()
		{
			return new InformationBuilder(
				"Start",
				"Starting server",
				this.Parameters
				);
		}

		public override void Start(params Parameter[] parameters)
		{
			throw new NotImplementedException();
		}
	}
}
