namespace AutoMapperDemo.Model;

public class Customer
{
	public int Id { get; set; }
	public string? FirstName { get; set; }
	public string? LastName { get; set; }
	public string? Email { get; set; }
	public Address Address { get; set; } = new();
	public List<Order> Orders { get; set; } = new();
	public DateTime CreatedDate { get; set; }
}
