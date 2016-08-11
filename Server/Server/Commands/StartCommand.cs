using System;
using Server.Commands.Informations;

namespace Server.Commands
{
	class StartCommand : ServerCommand
	{
		private ParametrInformation[] parametrs = new ParametrInformation[0];
		protected override ParametrInformation[] Parameters
		{
			get
			{
				return parametrs;
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

		public override void Start(params Parametr[] parametrs)
		{
			throw new NotImplementedException();
		}
	}
}
