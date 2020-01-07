using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace VideoStore.Tests
{
	[TestClass]
	public class VideoStoreTests
	{
        private Statement _statement; 

        [TestInitialize] 
		public void TestInitialize()
		{ 
			_statement = new Statement("Customer"); 
		} 

		[TestMethod] 
		public void TestSingleNewReleaseTotals()
		{ 
			_statement.AddRental (new Rental (new Movie ("New Release Movie 1", Movie.NewRelease), 3));

            _statement.GenerateStatement();

            Assert.AreEqual(9.0, _statement.TotalAmount);
            Assert.AreEqual(2, _statement.FrequentRenterPoints);
		}
		
		[TestMethod]
		public void TestDualNewReleaseTotals()
		{ 
			_statement.AddRental(new Rental (new Movie ("New Release Movie 1", Movie.NewRelease), 3)); 
			_statement.AddRental(new Rental (new Movie ("New Release Movie 2", Movie.NewRelease), 3));

            _statement.GenerateStatement();
            
            Assert.AreEqual(18.0, _statement.TotalAmount);
            Assert.AreEqual(4, _statement.FrequentRenterPoints);
		}

        [TestMethod]
        public void TestSingleChildrensTotals()
        { 
            _statement.AddRental(new Rental (new Movie ("Childrens Movie", Movie.Childrens), 3));

            _statement.GenerateStatement();
            
            Assert.AreEqual(1.5, _statement.TotalAmount);
            Assert.AreEqual(1, _statement.FrequentRenterPoints);
        }		
        
        [TestMethod]
        public void TestSingleChildrensFourDayRentalTotals()
        { 
            _statement.AddRental(new Rental (new Movie ("Childrens Movie", Movie.Childrens), 4));
            
            _statement.GenerateStatement();

            Assert.AreEqual(3.0, _statement.TotalAmount);
            Assert.AreEqual(1, _statement.FrequentRenterPoints);
        }
		
        [TestMethod]
        public void TestMultipleRegularTotals()
        { 
            _statement.AddRental(new Rental (new Movie ("Regular Movie 1", Movie.Regular), 1)); 
            _statement.AddRental(new Rental (new Movie ("Regular Movie 2", Movie.Regular), 2)); 
            _statement.AddRental(new Rental (new Movie ("Regular Movie 3", Movie.Regular), 3)); 
			
            _statement.GenerateStatement();

            Assert.AreEqual(7.5, _statement.TotalAmount);
            Assert.AreEqual(3, _statement.FrequentRenterPoints);
        } 		
        
        [TestMethod]
        public void TestMultipleRegularStatementText()
        { 
            _statement.AddRental(new Rental (new Movie ("Regular Movie 1", Movie.Regular), 1)); 
            _statement.AddRental(new Rental (new Movie ("Regular Movie 2", Movie.Regular), 2)); 
            _statement.AddRental(new Rental (new Movie ("Regular Movie 3", Movie.Regular), 3));  
			
            var statement = _statement.GenerateStatement();

            Assert.AreEqual("Rental Record for Customer\n\tRegular Movie 1\t2.0\n\tRegular Movie 2\t2.0\n\tRegular Movie 3\t3.5\nYou owed 7.5\nYou earned 3 frequent renter points\n", statement); 
        }
    }
}
