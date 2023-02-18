using LinqExtensionMethods.db.Models;

namespace LinqExtensionMethods.db;

public class SedDb
{
	private readonly PostgresContext _context;
	
	public SedDb(PostgresContext context)
	{
		_context = context;
	}
	public async Task AddCustomers()
	{
		Customer[] customers =
		{
			new() { Name = "Cesar", Email = "cesar@x.com", Age = 30 },
			new() { Name = "Denise", Email = "denise@x.com", Age = 15 },
			new() { Name = "Nicole", Email = "nicole@x.com", Age = 20 },
			new() { Name = "Mena", Email = "mena@x.com", Age = null }
		};

		await _context.Customers.AddRangeAsync(customers);
		var count = await _context.SaveChangesAsync();
			
		Console.WriteLine("{0} records saved to database", count);
	}
}