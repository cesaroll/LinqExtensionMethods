using LinqExtensionMethods.db.Models;

namespace LinqExtensionMethods.db;

public static class Sed
{
	public static async Task AddCustomers()
	{
		using (var db = new PostgresContext())
		{
			Customer[] customers =
			{
				new() { Name = "Cesar", Email = "cesar@x.com", Age = 30 },
				new() { Name = "Denise", Email = "denise@x.com", Age = 15 },
				new() { Name = "Nicole", Email = "nicole@x.com", Age = 20 },
			};

			await db.Customers.AddRangeAsync(customers);
			var count = await db.SaveChangesAsync();
			
			Console.WriteLine("{0} records saved to database", count);
		}
	}
}