using BookModel.Domain.Entities;
using Moq;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace UnitTestBookStore
{
    public class UnitTestDBset
    {
        public static Mock<DbSet<T>> CreateDbSetMock<T>(IEnumerable<T> elements) where T : class
        {
            var elementsAsQueryable = elements.AsQueryable();
            var dbSetMock = new Mock<DbSet<T>>();

            dbSetMock.As<IQueryable<T>>().Setup(m => m.Provider).Returns(elementsAsQueryable.Provider);
            dbSetMock.As<IQueryable<T>>().Setup(m => m.Expression).Returns(elementsAsQueryable.Expression);
            dbSetMock.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(elementsAsQueryable.ElementType);
            dbSetMock.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(elementsAsQueryable.GetEnumerator());

            return dbSetMock;
        }

        public static List<Category> CategoryList()
        {
            List<Category> listofcategory = new List<Category>();
            listofcategory.Add(new Category { ID = 1, Name = "Crime" });
            listofcategory.Add(new Category { ID = 2, Name = "Romance" });
            listofcategory.Add(new Category { ID = 3, Name = "Fantasy" });
            return listofcategory;
        }

        public static List<Book> BookList()
        {
            List<Book> listofbook = new List<Book>();
            listofbook.Add(new Book { ID = 2, Name = "Unsolved crimes", CategoryID = 1, Cost = 10.99, PromoID = 1 });
            listofbook.Add(new Book { ID = 3, Name = "Heresy", CategoryID = 3, Cost = 6.8, PromoID = 0 });
            listofbook.Add(new Book { ID = 4, Name = "Jack the Ripper", CategoryID = 1, Cost = 16, PromoID = 1 });
            listofbook.Add(new Book { ID = 5, Name = "The Tolkien Years", CategoryID = 3, Cost = 22.9, PromoID = 0 });
            listofbook.Add(new Book { ID = 6, Name = "A Little LoveStoryr", CategoryID = 2, Cost = 2.4, PromoID = 0 });
            return listofbook;
        }

        public static List<Promo> PromoList()
        {
            List<Promo> listofpromo = new List<Promo>();
            listofpromo.Add(new Promo { ID = 1, Discount = 0.05, Description = "product discounted by 5%" });
            return listofpromo;
        }
    }
}