namespace Server.Commands
{
	#region Using
	using Informations;
	#endregion
	abstract class ServerCommand
	{
		private string description;
		public ServerCommand(string name, string description, ParameterInformation[] parameters)
		{
			this.Name = name;
			this.description = description;
			this.Parameters = parameters;

		}
		/// <summary>
		/// Имя команды
		/// </summary>
		public string Name { get; private set; }
		/// <summary>
		/// Возможные и обязательные входящие парметры
		/// </summary>
		protected ParameterInformation[] Parameters { get; }
		/// <summary>
		/// Запуск команды
		/// </summary>
		public abstract void Start(params Parameter[] parameters);
		/// <summary>
		/// Возвращает информацию о команде
		/// </summary>
		/// <returns>Информация о команде</returns>
		public InformationBuilder Information()
		{
			return new InformationBuilder(this.Name, this.description, this.Parameters);
		}

	}
}
