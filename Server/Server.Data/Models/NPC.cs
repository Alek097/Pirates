namespace Server.Models
{
	#region Using
	using System;
	#endregion
	public class NPC
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string FullName { get; set; }
		public virtual Ship Ship { get; set; }

		public NPC()
		{
			this.Id = Guid.NewGuid();
		}
	}
}