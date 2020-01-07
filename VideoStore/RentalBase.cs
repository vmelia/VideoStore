namespace VideoStore
{
    public abstract class RentalBase
    {
        protected RentalBase(Movie movie, int daysRented)
        {
            Movie = movie;
            DaysRented = daysRented;
        }

        public Movie Movie { get; }
        public int DaysRented { get; }

        public abstract double Amount { get; }
        public abstract int FrequentRenterPoints { get; }
    }
}