using Asd.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Asd
{
	public class Database: IdentityDbContext<User>
	{
		public Database(DbContextOptions<Database> options) : base(options)
		{
			Database.EnsureCreated();

			if (!Flowers.Any())
			{
				Flowers.Add(new Flower()
				{
					Name = "Пионы",
					Height = 100,
					Width = 100,
					Compound = "3 Пиона",
					Description = "Что-то",
					Image = "flowerImages/04.18.2023.jpg",
					Price = 100,
				});
				SaveChanges();
			}
		}
		public DbSet<Flower> Flowers { get; set; }
	}
}
