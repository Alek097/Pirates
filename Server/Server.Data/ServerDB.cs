namespace Server.Data
{
	#region Using
	using Models;
	using System.Data.Entity;
	#endregion
	public class ServerDB : DbContext
	{
		public DbSet<Player> Players { get; set; }
		//public DbSet<Ship> Ships { get; set; }
		//public DbSet<ShipCharacteristic> ShipCharacteristic { get; set; }
		//public DbSet<NPC> NPC { get; set; }

		//protected override void OnModelCreating(DbModelBuilder modelBuilder)
		//{
		//	modelBuilder.Entity<Player>()
		//		.HasOptional(player => player.Ship)
		//		.WithRequired(ship => ship.Captain);

		//	modelBuilder.Entity<Ship>()
		//		.HasMany(ship => ship.Team)
		//		.WithOptional(npc => npc.Ship);

		//	modelBuilder.Entity<Ship>()
		//		.HasMany(ship => ship.Characteristic)
		//		.WithRequired(characteristic => characteristic.Ship);
		//}
	}
}
