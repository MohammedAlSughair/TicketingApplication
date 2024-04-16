using System.Collections.Generic;
using System.Net.Sockets;
using System.Reflection.Emit;
using System.Reflection.Metadata;
using Microsoft.EntityFrameworkCore;


namespace  TicketingApplication.Entities
{
	public class TSDBContext: DbContext
	{
		public TSDBContext(DbContextOptions<TSDBContext> options) : base(options)
		{
		}
		public DbSet<Areas> Areas { get; set; }
		public DbSet<Cities> Cities { get; set; }
		public DbSet<Countries> Countries { get; set; }
		public DbSet<CustomerBranch> CustomerBranch { get; set; }
		public DbSet<CustomerLocation> CustomerLocation { get; set; }
		public DbSet<Customers> Customers { get; set; }
		public DbSet<Tags> Tags { get; set; }
		public DbSet<Technicians> Technicians { get; set; }
		public DbSet<Tickets> Tickets { get; set; }
		public DbSet<TicketTransaction> TicketTransaction { get; set; }


		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.Entity<User>()
			   .HasData(
			   new User()
			   {
				   ID = 1,
				   Name = "Admin1",
				   Password = "Admin123",
				   UserType = EntityConstant.UserType.Admin
			   },
				new User()
				{
					ID = 2,
					Name = "Technician1",
					Password = "Technician123",
					UserType = EntityConstant.UserType.Technician
				});

			modelBuilder.Entity<Countries>()
			   .HasData(
			   new Countries()
			   {
				   ID = 1,
				   Name = "Jordan",
			   });

			modelBuilder.Entity<Cities>()
			   .HasData(
			   new Cities()
			   {
				   ID = 1,
				   Name = "Amman",
				   CountryId=1
			   });

			modelBuilder.Entity<Areas>()
			   .HasData(
			   new Areas()
			   {
				   ID = 1,
				   Name = "Center",
				   CityId = 1
			   });

			modelBuilder.Entity<Customers>()
			   .HasData(
			   new Customers()
			   {
				   ID = 1,
				   Description = "Arab Bank",
			   });

			modelBuilder.Entity<CustomerBranch>()
			   .HasData(
			   new CustomerBranch()
			   {
				   ID = 1,
				   Description = "Arab Bank",
				   CustomerId = 1
			   });

			modelBuilder.Entity<CustomerLocation>()
			   .HasData(
			   new CustomerLocation()
			   {
				   ID = 1,
				   CustomerId = 1,
				   BranchId =1,
				   CountryId = 1,
				   CityId = 1,
				   AreaId = 1
			   });

			modelBuilder.Entity<Tags>()
			   .HasData(
			   new Tags()
			   {
				   ID = 1,
				   TagNumber = 1,	
				   CustomerID =1
			   });

			modelBuilder.Entity<Technicians>()
			   .HasData(
			   new Technicians()
			   {
				   ID = 1,
				   Name = "Technician1"
			   });

			foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
			{
				relationship.DeleteBehavior = DeleteBehavior.Restrict;
			}
		}

	}
}
