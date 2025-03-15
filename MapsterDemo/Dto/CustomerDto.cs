using Microsoft.Diagnostics.Tracing.Parsers.FrameworkEventSource;

namespace MapsterDemo.Dto;

public class CustomerDto
{
	public int Id { get; set; }
	public string? FullName { get; set; } // FirstName + LastName
	public string? Email { get; set; }
	public AddressDto Address { get; set; } = new AddressDto();
	public List<OrderDto> Orders { get; set; } = [];
	public string? CreatedDateFormatted { get; set; } // Tarih formatlanmış olarak
}
