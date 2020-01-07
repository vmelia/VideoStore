using System.Collections.Generic;

namespace VideoStore
{
	public class Customer
	{
		public Customer(string name)
		{
			_name = name;
		}

		public void AddRental(Rental rental)
		{
			_rentals.Add(rental);
		}

		public string Statement()
		{
			double totalAmount = 0;
			int frequentRenterPoints = 0;
			string result = "Rental Record for " + _name + "\n";

			foreach(Rental rental in _rentals)
			{
				double thisAmount = 0;

				// determines the amount for each line
				switch (rental.Movie.PriceCode)
				{
					case Movie.Regular:
						thisAmount += 2;
						if (rental.DaysRented > 2)
							thisAmount += (rental.DaysRented - 2) * 1.5;
						break;
					case Movie.NewRelease:
						thisAmount += rental.DaysRented * 3;
						break;
					case Movie.Childrens:
						thisAmount += 1.5;
						if (rental.DaysRented > 3)
							thisAmount += (rental.DaysRented - 3) * 1.5;
						break;
				}

				frequentRenterPoints++;

				if (rental.Movie.PriceCode == Movie.NewRelease
				    && rental.DaysRented > 1)
					frequentRenterPoints++;

				result += "\t" + rental.Movie.Title + "\t"
				          + thisAmount.ToString("0.0") + "\n";
				totalAmount += thisAmount;
			}

			result += "You owed " + totalAmount.ToString("0.0") + "\n";
			result += "You earned " + frequentRenterPoints + " frequent renter points\n";

			return result;
		}

		private readonly string _name;
		private readonly IList<Rental> _rentals = new List<Rental>();
	}
}
