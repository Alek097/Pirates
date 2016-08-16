namespace Server.Data
{
	#region Using
	using Models;
	using System.Data.Entity;
	#endregion
	public class ServerDB : DbContext
	{
		public DbSet<Models.Player> Players { get; set; }

		public async void AddAsync<T>(T entity)
			where T : class
		{
			this.Entry<T>(entity).State = EntityState.Added;
			await this.SaveChangesAsync();
		}

		public async void DeleteAsync<T>(T entity)
			where T : class
		{
			this.Entry<T>(entity).State = EntityState.Deleted;
			await this.SaveChangesAsync();
		}

		public async void UpdateAsync<T>(T entity)
			where T : class
		{
			this.Entry<T>(entity).State = EntityState.Modified;
			await this.SaveChangesAsync();
		}
		public void Add<T>(T entity)
			where T : class
		{
			this.Entry<T>(entity).State = EntityState.Added;
			this.SaveChanges();
		}

		public void Delete<T>(T entity)
			where T : class
		{
			this.Entry<T>(entity).State = EntityState.Deleted;
			this.SaveChanges();
		}

		public void Update<T>(T entity)
			where T : class
		{
			this.Entry<T>(entity).State = EntityState.Modified;
			this.SaveChanges();
		}

		//public DbSet<Ship> Ships { get; set; }
		//public DbSet<ShipCharacteristic> ShipCharacteristic { get; set; }
		//public DbSet<NPC> NPC { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{

		}
	}
}
