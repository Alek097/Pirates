namespace Server.Data
{
	#region Using
	using Models;
	using System.Data.Entity;
	#endregion
	public class Context : DbContext
	{
		public DbSet<Player> Players { get; set; }
		public DbSet<Ship> Ships { get; set; }
		public DbSet<ShipCharacteristic> Characteristics { get; set; }
		public DbSet<NPC> NPC { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			
		}
	}
}
