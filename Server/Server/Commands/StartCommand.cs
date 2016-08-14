namespace Server.Commands
{
	#region Using
	using System.Collections.Concurrent;
	using Server.Commands.Informations;
	#endregion
	class StartCommand : ServerCommand
	{
		private ParameterInformation[] parameters = new ParameterInformation[0];
		private ConcurrentDictionary<>
		protected override ParameterInformation[] Parameters
		{
			get
			{
				return parameters;
			}
		}

		public StartCommand()
		{
			base.Name = "Start";
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
			
		}
	}
}
