using LinqExtensionMethods.db.Models;
using Microsoft.EntityFrameworkCore;

namespace LinqExtensionMethods.db.Repositories;

public class CustomersRepository
{
	private readonly PostgresContext _context;
	
	public CustomersRepository(PostgresContext context)
	{
		_context = context;
	}
	
	public async Task<IEnumerable<Customer>> GetCustomersAsync()
	{
		return await _context.Customers.ToListAsync();
	}
}