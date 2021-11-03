using financasPrebelli.Models;
using Microsoft.EntityFrameworkCore;


namespace financasPrebelli.Data
{
	public class DataContext : DbContext
	{
		public DataContext(DbContextOptions<DataContext> options) : base(options)
		{ }

		public DbSet<Despesas> despesas { get; set; }
		public DbSet<Receitas> receitas { get; set; }

	}
}
