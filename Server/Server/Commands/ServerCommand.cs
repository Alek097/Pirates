namespace Server.Commands
{
	#region Using
	using Informations;
	#endregion
	abstract class ServerCommand
	{
		/// <summary>
		/// Имя команды
		/// </summary>
		public string Name { get; protected set; }
		/// <summary>
		/// Возможные и обязательные входящие парметры
		/// </summary>
		protected abstract ParametrInformation[] Parametrs { get; }
		/// <summary>
		/// Запуск команды
		/// </summary>
		public abstract void StartCommand(params Parametr[] parametrs);
		/// <summary>
		/// Возвращает информацию о команде
		/// </summary>
		/// <returns>Информация о команде</returns>
		public abstract InformationBuilder Information();

	}
}
