using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace ComplaintTicketingApp.Entities
{
	public class CTADBContext : DbContext
	{
		public CTADBContext(DbContextOptions<CTADBContext> options) : base(options)
		{
		}
		public DbSet<User> User { get; set; }
		public DbSet<Category> Category { get; set; }
		public DbSet<Document> Document { get; set; }
		public DbSet<Ticket> Ticket { get; set; }
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
					Name = "User1",
					Password = "User123",
					UserType = EntityConstant.UserType.User
				});

			modelBuilder.Entity<Category>()
			   .HasData(
			   new Category()
			   {
				   ID = 1,
				   Name = "Lawsuit",				   
			   });


			foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
			{
				relationship.DeleteBehavior = DeleteBehavior.Restrict;
			}
		}
	}
}
