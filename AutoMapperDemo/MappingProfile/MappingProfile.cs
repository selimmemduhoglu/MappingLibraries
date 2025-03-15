using AutoMapper;
using AutoMapperDemo.Dto;
using AutoMapperDemo.Model;

namespace AutoMapperDemo.MappingProfile;

public class MappingProfile : Profile
{
	public MappingProfile()
	{
		// Customer -> CustomerDto
		CreateMap<Customer, CustomerDto>()
			.ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
			.ForMember(dest => dest.CreatedDateFormatted, opt => opt.MapFrom(src => src.CreatedDate.ToString("dd.MM.yyyy")));

		// Address -> AddressDto
		CreateMap<Address, AddressDto>()
			.ForMember(dest => dest.FullAddress, opt => opt.MapFrom(src => $"{src.Street}, {src.City}, {src.ZipCode}, {src.Country}"));

		// Order -> OrderDto
		CreateMap<Order, OrderDto>()
			.ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.OrderId))
			.ForMember(dest => dest.Total, opt => opt.MapFrom(src => src.TotalAmount))
			.ForMember(dest => dest.OrderDateFormatted, opt => opt.MapFrom(src => src.OrderDate.ToString("dd.MM.yyyy")));

	}


}
