namespace Server.Commands.Informations
{
	class ParameterInformation
	{
		public string Name { get; private set; }
		public ValueType ValueType { get; private set; }
		public string Description { get; private set; }
		public bool Mandatory { get; private set; }

		/// <summary>
		/// Строит объект ParameterInformation
		/// </summary>
		/// <param name="name">Имя параметра</param>
		/// <param name="description">Описание параметра</param>
		/// <param name="valueType">Тип параметра</param>
		/// <param name="mandatory">Определяет является ли этот парметр обязательным</param>
		public ParameterInformation(string name, string description, ValueType valueType,bool mandatory)
		{
			this.Name = name;
			this.ValueType = valueType;
			this.Description = description;
			this.Mandatory = mandatory;
		}

		public override string ToString()
		{
			string informationOfParameter = string.Format("{0}:{1} - {2}", this.Name, this.ValueType, this.Description);

			if(!this.Mandatory)
			{
				informationOfParameter = "[" + informationOfParameter + "]";
			}

			return informationOfParameter;
		}
	}
}
