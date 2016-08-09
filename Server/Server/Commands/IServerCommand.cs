namespace Server.Commands
{
	interface IServerCommand
	{
		/// <summary>
		/// Имя команды
		/// </summary>
		string Name { get; }
		/// <summary>
		/// Запуск команды
		/// </summary>
		void StartCommand(params string[] parametrs);
		/// <summary>
		/// Возвращает информацию о команде
		/// </summary>
		/// <returns>Информация о команде</returns>
		string Information();

	}
}
