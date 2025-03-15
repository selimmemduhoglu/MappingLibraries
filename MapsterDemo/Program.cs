using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;
using MapsterDemo.Dto;
using MapsterDemo.MapsterBenchmarkFolder;

namespace MapsterDemo
{
	internal class Program
	{
		static void Main(string[] args)
		{
			// Benchmark'ı çalıştırma
			Summary summary = BenchmarkRunner.Run<MapsterBenchmark>();

			Console.WriteLine("\nManuel test:");

			// Manuel olarak test etme
			MapsterBenchmark benchmark = new MapsterBenchmark();
			CustomerDto customerDto = benchmark.MapCustomerToDto();

			// Sonuçları gösterme
			Console.WriteLine($"Id: {customerDto.Id}");
			Console.WriteLine($"FullName: {customerDto.FullName}");
			Console.WriteLine($"Email: {customerDto.Email}");
			Console.WriteLine($"CreatedDate: {customerDto.CreatedDateFormatted}");
			Console.WriteLine($"Address: {customerDto.Address.FullAddress}");

			Console.WriteLine("\nOrders:");
			foreach (var order in customerDto.Orders)
			{
				Console.WriteLine($"  Order Id: {order.Id}, Total: {order.Total}, Date: {order.OrderDateFormatted}");
			}

			Console.ReadLine();
		}
	}
}
