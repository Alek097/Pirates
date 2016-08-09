namespace Server.Commands.Informations
{
	class InformationBuilder
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public ParametrInformation[] Parametrs { get; set; }
		/// <summary>
		/// Строит объект InformationBuilder
		/// </summary>
		/// <param name="name">Имя команды</param>
		/// <param name="description">Описание команды</param>
		/// <param name="parametrs">Параметры которые принимает команда</param>
		public InformationBuilder(string name, string description, params ParametrInformation[] parametrs)
		{
			this.Name = name;
			this.Description = description;
			this.Parametrs = parametrs;
		}

		public override string ToString()
		{
			string information = string.Format("Name:{0}\nDescription:\n{1}", this.Name, this.Description);

			if(this.Parametrs.Length > 0)
			{
				information += "Parametrs:\n";

				foreach (ParametrInformation parametr in this.Parametrs)
				{
					information += parametr.ToString() + "\n";
				}
			}

			return information;
		}
	}
}
