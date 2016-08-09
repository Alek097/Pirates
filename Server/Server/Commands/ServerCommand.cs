namespace Server.Commands
{
	abstract class ServerCommand
	{
		/// <summary>
		/// Имя команды
		/// </summary>
		public string Name { get; protected set; }
		/// <summary>
		/// Запуск команды
		/// </summary>
		public abstract void StartCommand(params string[] parametrs);
		/// <summary>
		/// Возвращает информацию о команде
		/// </summary>
		/// <returns>Информация о команде</returns>
		public abstract string Information();

	}
}
