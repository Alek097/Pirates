namespace Server.Data.Models
{
	#region Using
	using System;
	#endregion
	public class ShipCharacteristic
	{
		public Guid Id { get; set; }
		public ShipCharacteristicType CharacteristicType { get; set; }
		public int Level { get; set; }
		public virtual Ship Ship { get; set; }
	}
}