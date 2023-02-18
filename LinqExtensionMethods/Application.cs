using LinqExtensionMethods.db;
using LinqExtensionMethods.Services;

namespace LinqExtensionMethods;

public class Application
{
	private readonly SedDb _sedDb;
	private readonly CustomersService _customersService;
	
	public Application(SedDb sedDb, CustomersService customersService)
	{
		_sedDb = sedDb;
		_customersService = customersService;
	}

	public async Task RunAsync()
	{
		// await _sedDb.AddCustomers();

		await _customersService.DisplayCustomers();
	}
}