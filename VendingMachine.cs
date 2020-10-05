using System;
using System.Collections.Generic;

namespace VendingMachine_CSPD
{
    public class VendingMachine
	{
		Product[] items = new Product[4];

		/// <summary>
		/// 
		/// </summary>
		public VendingMachine()
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

		/// <summary>
		/// 
		/// </summary>
		public void DisplayItems()
		{
			Console.Out.WriteLine("Available Items ...");
			Console.Out.WriteLine();

			int i = 1;
			foreach (var item in items)
			{
				Console.Out.WriteLine("{0} {1} ({2})- Price {3:c}",i, item.Name, item.quantity, item.Price);
				i= i + 1;
			}

			Console.Out.WriteLine();

			var selectionChar = RequestSelection();

			Product product = FindAndReturnProduct(selectionChar);

			Calculator calculator = new Calculator();

			var paymentInfo = calculator.ReturnPaymentAndChange(product.Price);

			MakePayment(paymentInfo[0], paymentInfo[1], product.Name);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public char RequestSelection()
		{
			List<char> accepted = new List<char>();

			Console.Out.WriteLine("Please make your selection...");

			foreach (var item in items)
			{
				char productCharacter = item.Name[0];
				accepted.Add(productCharacter);
				Console.Out.WriteLine("Please enter {0} for {1}.", productCharacter, item.Name);
			}

			char selection = Console.ReadLine().ToUpper()[0];

			while (!accepted.Contains(selection))
			{
				Console.Out.WriteLine("{0} Not vailable, please choose again.", selection);

				selection = Console.ReadLine().ToUpper()[0];
			}

			return selection;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="selection"></param>
		/// <returns></returns>
		public Product FindAndReturnProduct(char selection)
		{
			string stringselection = Convert.ToString(selection);

			var product = Array.Find(this.items, item => item.name.StartsWith(stringselection, StringComparison.Ordinal));

			return product;
		}

		/// <summary>
		/// Make Payment after selecting the product
		/// </summary>
		/// <param name="coinsRequired"></param>
		/// <param name="change"></param>
		/// <param name="productName"></param>
		public void MakePayment(double coinsRequired, double change, string productName)
		{
			int total = 0;
			double paymentReceived = 0;
			double receivedCoin = 0;

			Console.WriteLine("Please enter a payment of 50p as 0.50");

			while (total < coinsRequired)
			{
				try
				{
					receivedCoin = double.Parse(Console.ReadLine(), System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.NumberFormatInfo.InvariantInfo);
					if (receivedCoin == 0.50)
					{
						total += 1;
						paymentReceived += receivedCoin;
						Console.Out.WriteLine("Received {0}, Outstanding {1}", total, coinsRequired - total);
					}
					else
					{
						Console.Out.WriteLine("Sorry only 50p coins are accepted");
					}
				}

				catch (FormatException)
				{
					Console.Out.WriteLine("Sorry please enter a 50p coin as \"0.50\"");
				}
			}

			OutputMessage(paymentReceived, productName, change);
		}

		/// <summary>
		/// Message to Customer
		/// </summary>
		/// <param name="paymentReceived"></param>
		/// <param name="name"></param>
		/// <param name="change"></param>
		public void OutputMessage(double paymentReceived, string name, double change)
		{
			Console.WriteLine("Thank you for your payment of {0:c}", paymentReceived);
			Console.WriteLine("Your product {0} has been dispensed", name);
			Console.WriteLine("Your change of {0:c} has been dispensed also", change);
		}
	}
}
