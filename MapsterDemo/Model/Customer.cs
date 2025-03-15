namespace MapsterDemo.Model;
internal class Customer
{
	public int Id { get; set; }
	public string? FirstName { get; set; }
	public string? LastName { get; set; }
	public string? Email { get; set; }
	public Address Address { get; set; } = new Address();
	public List<Order> Orders { get; set; } = [];
	public DateTime CreatedDate { get; set; }
}

