namespace VideoStore
{
    public class ChildrensMovieRental : RentalBase
    {
        public ChildrensMovieRental(string title, int priceCode) : base(title, priceCode)
        {
        }

        public override double Amount { get; }
        public override int FrequentRenterPoints { get; }
    }
}
