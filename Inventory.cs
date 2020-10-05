using System;

namespace VendingMachine_CSPD
{
    public class Inventory
	{
		Product[] items = new Product[4];
		public Inventory()
		{
			items[0] = new Product("Coke", 10, 1.25);
			items[1] = new Product("M&M’s", 15, 1.89);
			items[2] = new Product("Water", 5, .89);
			items[3] = new Product("Snickers", 7, 2.05);
		}

		public Array Items
		{
			get
			{
				return items;
			}
		}
	}

	interface IProducts
	{
		void CreateCustomer();
	}

	public class Products : IProducts
	{
		public void CreateCustomer()
		{
			Console.WriteLine("Creating a customer with concrete class injected using constructor injection");
		}
	}

	class ConsoleApplication
	{
		private readonly IProducts _products;
		public ConsoleApplication(IProducts Products)
		{
			_products = Products;
		}

		public void Run()
		{
			_products.CreateCustomer();
		}
	}
}
