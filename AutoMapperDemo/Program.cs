using AutoMapperDemo.Benchmark;
using AutoMapperDemo.Dto;
using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;

namespace AutoMapperDemo
{
	internal class Program
	{
		static void Main(string[] args)
		{
			// Benchmark'ı çalıştırma
			Summary summary = BenchmarkRunner.Run<AutoMapperBenchmark>();

			Console.WriteLine("\nManuel test:");

			AutoMapperBenchmark benchmark = new AutoMapperBenchmark();
			CustomerDto customerDto = benchmark.MapCustomerToDto();


			// Sonuçları gösterme
			Console.WriteLine($"Id: {customerDto.Id}");
			Console.WriteLine($"FullName: {customerDto.FullName}");
			Console.WriteLine($"Email: {customerDto.Email}");
			Console.WriteLine($"CreatedDate: {customerDto.CreatedDateFormatted}");
			Console.WriteLine($"Address: {customerDto.Address.FullAddress}");

			Console.WriteLine("\nOrders:");

			foreach (OrderDto order in customerDto.Orders)
			{
				Console.WriteLine($"  Order Id: {order.Id}, Total: {order.Total}, Date: {order.OrderDateFormatted}");
			}

			Console.ReadLine();


		}
	}
}
