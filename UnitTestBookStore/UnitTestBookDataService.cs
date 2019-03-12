using BookData.Repository;
using BookModel.Domain.Dto;
using BookModel.Domain.Interface;
using BookService;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace UnitTestBookStore
{
    [TestClass]
    public class UnitTestBookDataService
    {
        [TestMethod]
        public void BookDataService_GetBookOrderList_NotNull()
        {
            Mock<DbBookStoreContext> mockdb = new Mock<DbBookStoreContext>();

            var usersMockBook = UnitTestDBset.CreateDbSetMock(UnitTestDBset.BookList());
            mockdb.Setup(x => x.Book).Returns(usersMockBook.Object);

            var usersMockCategory = UnitTestDBset.CreateDbSetMock(UnitTestDBset.CategoryList());
            mockdb.Setup(x => x.Category).Returns(usersMockCategory.Object);

            var usersMockPromo = UnitTestDBset.CreateDbSetMock(UnitTestDBset.PromoList());
            mockdb.Setup(x => x.Promo).Returns(usersMockPromo.Object);

            //==========================================================
            var bookservice = new BookDataService(mockdb.Object);
            var resultlist = bookservice.GetBookOrderList().Result;

            Assert.AreEqual(UnitTestDBset.BookList().Count, resultlist.Count);
        }

        [TestMethod]
        public void BookDataService_GetBookOnSale_No_Discount()
        {
            Mock<DbBookStoreContext> mockdb = new Mock<DbBookStoreContext>();

            var usersMockBook = UnitTestDBset.CreateDbSetMock(UnitTestDBset.BookList());
            mockdb.Setup(x => x.Book).Returns(usersMockBook.Object);

            var usersMockCategory = UnitTestDBset.CreateDbSetMock(UnitTestDBset.CategoryList());
            mockdb.Setup(x => x.Category).Returns(usersMockCategory.Object);

            var usersMockPromo = UnitTestDBset.CreateDbSetMock(UnitTestDBset.PromoList());
            mockdb.Setup(x => x.Promo).Returns(usersMockPromo.Object);

            //==========================================================
            IBook testbook = UnitTestDBset.BookList()[1];
            var bookservice = new BookDataService(mockdb.Object);
            var resultlist = bookservice.GetBookOnSale(testbook).Result;

            Assert.AreEqual(0, resultlist.DiscountedPrice());
        }

        [TestMethod]
        public void BookDataService_GetBookOnSale_With_Discount()
        {
            Mock<DbBookStoreContext> mockdb = new Mock<DbBookStoreContext>();

            var usersMockBook = UnitTestDBset.CreateDbSetMock(UnitTestDBset.BookList());
            mockdb.Setup(x => x.Book).Returns(usersMockBook.Object);

            var usersMockCategory = UnitTestDBset.CreateDbSetMock(UnitTestDBset.CategoryList());
            mockdb.Setup(x => x.Category).Returns(usersMockCategory.Object);

            var usersMockPromo = UnitTestDBset.CreateDbSetMock(UnitTestDBset.PromoList());
            mockdb.Setup(x => x.Promo).Returns(usersMockPromo.Object);

            //==========================================================
            IBook testbook = UnitTestDBset.BookList()[3];
            var bookservice = new BookDataService(mockdb.Object);
            var resultlist = bookservice.GetBookOnSale(testbook).Result;

            Assert.IsNotNull(resultlist.DiscountedPrice());
        }

        [TestMethod]
        public void BookDataService_CalculateTotalCost_Verify()
        {
            Mock<DbBookStoreContext> mockdb = new Mock<DbBookStoreContext>();

            var usersMockBook = UnitTestDBset.CreateDbSetMock(UnitTestDBset.BookList());
            mockdb.Setup(x => x.Book).Returns(usersMockBook.Object);

            var usersMockCategory = UnitTestDBset.CreateDbSetMock(UnitTestDBset.CategoryList());
            mockdb.Setup(x => x.Category).Returns(usersMockCategory.Object);

            var usersMockPromo = UnitTestDBset.CreateDbSetMock(UnitTestDBset.PromoList());
            mockdb.Setup(x => x.Promo).Returns(usersMockPromo.Object);

            //==========================================================
            IBook testbook = UnitTestDBset.BookList()[3];
            var bookservice = new BookDataService(mockdb.Object);
            var resultcost = bookservice.CalculateTotalCost().Result;

            IOrderCost testordercost = new OrderCost
            {
                Subtotal = 57.74,
                Totaltax = 5.77,
                TotalCost = 63.51
            };

            Assert.AreEqual(testordercost.Subtotal, resultcost.Subtotal);
            Assert.AreEqual(testordercost.Totaltax, resultcost.Totaltax);
            Assert.AreEqual(testordercost.TotalCost, resultcost.TotalCost);
        }
    }
}