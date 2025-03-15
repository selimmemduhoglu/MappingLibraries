using Mapster;
using MapsterDemo.Dto;
using MapsterDemo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapsterDemo.MapsterConfig;

public static class MappingConfig
{
	public static void Configure()
	{
	
		// Customer -> CustomerDto
		TypeAdapterConfig<Customer, CustomerDto>
			.NewConfig()
			.Map(dest => dest.FullName, src => $"{src.FirstName} {src.LastName}")
			.Map(dest => dest.CreatedDateFormatted, src => src.CreatedDate.ToString("dd.MM.yyyy"));

		// Address -> AddressDto
		TypeAdapterConfig<Address, AddressDto>
			.NewConfig()
			.Map(dest => dest.FullAddress, src => $"{src.Street}, {src.City}, {src.ZipCode}, {src.Country}");


		// Order -> OrderDto
		TypeAdapterConfig<Order, OrderDto>
			.NewConfig()
			.Map(dest => dest.Id, src => src.OrderId)
			.Map(dest => dest.Total, src => src.TotalAmount)
			.Map(dest => dest.OrderDateFormatted, src => src.OrderDate.ToString("dd.MM.yyyy"));


	}
}
