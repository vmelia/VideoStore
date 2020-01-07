namespace VideoStore
{
    public class RegularMovieRental : RentalBase
    {
        public RegularMovieRental(string title, int priceCode) : base(title, priceCode)
        {
        }

        public override double Amount { get; }
        public override int FrequentRenterPoints { get; }
    }
}
