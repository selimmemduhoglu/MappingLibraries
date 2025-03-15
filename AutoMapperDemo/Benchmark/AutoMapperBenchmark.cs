using AutoMapper;
using AutoMapperDemo.Dto;
using AutoMapperDemo.Model;
using BenchmarkDotNet.Attributes;

namespace AutoMapperDemo.Benchmark;

[MemoryDiagnoser]
public class AutoMapperBenchmark
{
	private readonly IMapper _mapper;
	private readonly Customer _customer;

	public AutoMapperBenchmark()
	{
		// AutoMapper konfigürasyonu
		var config = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>()); 
		_mapper = config.CreateMapper();

		// Test verisi oluşturma
		_customer = CreateSampleCustomer();
	}

	[Benchmark]
	public CustomerDto MapCustomerToDto()
	{
		return _mapper.Map<CustomerDto>(_customer);
	}

	[Benchmark]
	public List<CustomerDto> MapCustomerListToDto()
	{
		var customers = new List<Customer>();
		for (int i = 0; i < 1000; i++)
		{
			customers.Add(CreateSampleCustomer(i));
		}

		return _mapper.Map<List<CustomerDto>>(customers);
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
