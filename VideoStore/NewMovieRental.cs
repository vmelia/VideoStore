namespace VideoStore
{
    public class NewMovieRental : RentalBase
    {
        public NewMovieRental(string title, int priceCode) : base(title, priceCode)
        {
        }

        public override double Amount { get; }
        public override int FrequentRenterPoints { get; }
    }
}
