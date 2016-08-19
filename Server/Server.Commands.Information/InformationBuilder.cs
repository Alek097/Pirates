namespace Server.Commands.Informations
{
	public class InformationBuilder
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public ParameterInformation[] Parameters { get; set; }
		/// <summary>
		/// Строит объект InformationBuilder
		/// </summary>
		/// <param name="name">Имя команды</param>
		/// <param name="description">Описание команды</param>
		/// <param name="parameters">Параметры которые принимает команда</param>
		public InformationBuilder(string name, string description, params ParameterInformation[] parameters)
		{
			this.Name = name;
			this.Description = description;
			this.Parameters = parameters;
		}

		public override string ToString()
		{
			string information = string.Format("Name:{0}\n\nDescription:\n{1}", this.Name, this.Description);

			if(this.Parameters.Length > 0)
			{
				information += "\n\nParameters:\n";

				foreach (ParameterInformation parameter in this.Parameters)
				{
					information += parameter.ToString() + "\n";
				}
			}

			return information;
		}
	}
}
