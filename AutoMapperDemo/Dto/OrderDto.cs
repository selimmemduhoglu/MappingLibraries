namespace AutoMapperDemo.Dto;

public class OrderDto
{
	public int Id { get; set; }
	public decimal Total { get; set; }
	public string? OrderDateFormatted { get; set; }
}
