﻿namespace Server.Data
{
	#region Using
	using Logging;
	using Models;
	using Exceptions;
	using System.Data;
	using System.Data.Entity;
	using System.Threading.Tasks;
	#endregion
	public class ServerDB : DbContext
	{
		public DbSet<Player> Players { get; set; }
		public DbSet<Log> Logs { get; set; }
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
		private new async Task<int> SaveChangesAsync()
		{
			try
			{
				return await base.SaveChangesAsync();
			}
			catch (DataException ex)
			{
				throw new FatalServerException("Fatal error has occurred, watch the inner exception", new Log(ex, ex.Message, LogLevel.Fatal));
			}
		}
		private new int SaveChanges()
		{
			try
			{
				return base.SaveChanges();
			}
			catch (DataException ex)
			{
				throw new FatalServerException("Fatal error has occurred, watch the inner exception", new Log(ex, ex.Message, LogLevel.Fatal));
			}
		}

		//public DbSet<Ship> Ships { get; set; }
		//public DbSet<ShipCharacteristic> ShipCharacteristic { get; set; }
		//public DbSet<NPC> NPC { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Log>()
				.Property(log => log.Exception)
				.HasColumnType("xml");
		}
	}
}
