using System.Collections.Generic;

namespace VideoStore
{
	public class Statement
	{
        private readonly string _customerName;
        private readonly IList<Rental> _rentals = new List<Rental>();

		public Statement(string customerName)
		{
            _customerName = customerName;
		}

        public void AddRental(Rental rental)
		{
			_rentals.Add(rental);
		}

        public double TotalAmount { get; private set; }
        public int FrequentRenterPoints { get; private set; }

		public string GenerateStatement()
		{
			TotalAmount = 0;
			FrequentRenterPoints = 0;
			string result = "Rental Record for " + _customerName + "\n";

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

				FrequentRenterPoints++;

				if (rental.Movie.PriceCode == Movie.NewRelease
				    && rental.DaysRented > 1)
					FrequentRenterPoints++;

				result += "\t" + rental.Movie.Title + "\t"
				          + thisAmount.ToString("0.0") + "\n";
				TotalAmount += thisAmount;
			}

			result += "You owed " + TotalAmount.ToString("0.0") + "\n";
			result += "You earned " + FrequentRenterPoints + " frequent renter points\n";

			return result;
		}
    }
}
