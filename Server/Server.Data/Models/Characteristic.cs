namespace Server.Models
{
	#region Using
	using System;
	#endregion
	public class Characteristic
	{
		public Guid Id { get; set; }
		public CharacteristicType CharacteristicType { get; set; }
		public int Level { get; set; }
	}
}