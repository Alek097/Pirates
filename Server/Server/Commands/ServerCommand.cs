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
		protected abstract ParameterInformation[] Parameters { get; }
		/// <summary>
		/// Запуск команды
		/// </summary>
		public abstract void Start(params Parameter[] parameters);
		/// <summary>
		/// Возвращает информацию о команде
		/// </summary>
		/// <returns>Информация о команде</returns>
		public abstract InformationBuilder Information();

	}
}
