using BenchmarkDotNet.Attributes;
using Mapster;
using MapsterDemo.Dto;
using MapsterDemo.MapsterConfig;
using MapsterDemo.Model;

namespace MapsterDemo.MapsterBenchmarkFolder;


[MemoryDiagnoser]
public class MapsterBenchmark
{
	private readonly Customer _customer;
	public MapsterBenchmark()
	{
		// Mapster konfigürasyonu
		MappingConfig.Configure();

		// Test verisi oluşturma
		_customer = CreateSampleCustomer();

	}

	//Burada bir nesneyi mapliyoruz.
	[Benchmark]
	public CustomerDto MapCustomerToDto()
	{
		return _customer.Adapt<CustomerDto>();
	}


	//Burada listeyi doldurup mapliyoruz.
	[Benchmark]
	public List<CustomerDto> MapCustomerListToDto()
	{
		List<Customer> customers = new List<Customer>();
		for (int i = 0; i < 1000; i++)
		{
			customers.Add(CreateSampleCustomer(i));
		}

		return customers.Adapt<List<CustomerDto>>();
	}

	private Customer CreateSampleCustomer(int id = 1)
	{
		return new Customer
		{
			Id = id,
			FirstName = "John",
			LastName = "Doe",
			Email = $"john.doe{id}@example.com",
			CreatedDate = DateTime.Now,
			Address = new Address
			{
				Street = "123 Main St",
				City = "Anytown",
				ZipCode = "12345",
				Country = "USA"
			},
			Orders = new List<Order>
				{
					new Order { OrderId = 1, TotalAmount = 99.99m, OrderDate = DateTime.Now.AddDays(-5) },
					new Order { OrderId = 2, TotalAmount = 149.99m, OrderDate = DateTime.Now.AddDays(-2) }
				}
		};
	}


}
