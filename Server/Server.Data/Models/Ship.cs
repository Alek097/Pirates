namespace Server.Models
{
	#region Using
	using System;
	using System.Collections.Generic;
	#endregion
	public class Ship
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public virtual Player Captain { get; set; }
		public virtual ICollection<NPC> Team { get; set; }
		public virtual ICollection<Characteristic> Characteristic { get; set; }

		public Ship()
		{
			this.Id = Guid.NewGuid();
		}
	}
}
