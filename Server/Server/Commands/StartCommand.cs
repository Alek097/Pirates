using System;
using Server.Commands.Informations;

namespace Server.Commands
{
	class StartCommand : ServerCommand
	{
		protected override ParametrInformation[] Parametrs
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public override InformationBuilder Information()
		{
			throw new NotImplementedException();
		}

		public override void StartCommand(params Parametr[] parametrs)
		{
			throw new NotImplementedException();
		}
	}
}
