namespace Server
{
	#region Using
	using System;
	#endregion
	class Parameter
	{
		public string Name { get; set; }
		public object Value { get; set; }
		public Type ValueType { get; set; }

		public Parameter(string name, string value)
		{
			this.Name = name;

			bool boolValue;
			double numberValue;

			if (bool.TryParse(value, out boolValue))
			{
				this.Value = boolValue;
				this.ValueType = boolValue.GetType();
			}
			else if (double.TryParse(value, out numberValue))
			{
				this.Value = numberValue;
				this.ValueType = numberValue.GetType();
			}
			else
			{
				this.Value = value;
				this.ValueType = value.GetType();
			}
		}
	}
}
