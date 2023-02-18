using LinqExtensionMethods.db.Extensions;
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
	
	public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
	{
		return await _context.Customers.ToListAsync();
	}

	public async Task<IEnumerable<Customer>> GetAllCustomersOlderThanAge(int age)
	{
		return await _context.Customers
			.Where(c => c.Age == null || c.Age > age).ToListAsync();
	}
	
	public async Task<IEnumerable<Customer>> GetAllCustomersWithName(string name)
	{
		return await _context.Customers
			.WhereIf(!string.IsNullOrWhiteSpace(name), c => c.Name == name).ToListAsync();
	}
}