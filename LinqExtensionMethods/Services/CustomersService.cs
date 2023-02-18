using LinqExtensionMethods.db.Repositories;

namespace LinqExtensionMethods.Services;

public class CustomersService
{
	private readonly CustomersRepository _customersRepository;

	public CustomersService(CustomersRepository customersRepository)
	{
		_customersRepository = customersRepository;
	}
	
	public async Task DisplayCustomers()
	{
		var customers = await _customersRepository.GetCustomersAsync();
		foreach (var customer in customers)
		{
			Console.WriteLine(customer.Name);
		}
	}
}