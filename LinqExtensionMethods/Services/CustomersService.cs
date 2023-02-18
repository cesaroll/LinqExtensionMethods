using LinqExtensionMethods.db.Models;
using LinqExtensionMethods.db.Repositories;

namespace LinqExtensionMethods.Services;

public class CustomersService
{
	private readonly CustomersRepository _customersRepository;

	public CustomersService(CustomersRepository customersRepository)
	{
		_customersRepository = customersRepository;
	}
	
	public async Task DisplayAllCustomers()
	{
		var customers = await _customersRepository.GetAllCustomersAsync();
		DisplayCustomerNames(customers);
	}

	public async Task DisplayAllAdultCustomers()
	{
		var customers = await _customersRepository.GetAllCustomersOlderThanAge(17);
		DisplayCustomerNames(customers);
	}
	
	public async Task DisplayAllCustomersWithName(string name)
	{
		var customers = await _customersRepository.GetAllCustomersWithName(name);
		DisplayCustomerNames(customers);
	}

	private static void DisplayCustomerNames(IEnumerable<Customer> customers)
	{
		foreach (var customer in customers)
		{
			Console.WriteLine(customer.Name);
		}
	}
}