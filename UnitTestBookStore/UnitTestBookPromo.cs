using BookData.Infractructure;
using BookData.Repository;
using BookModel.Domain.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace UnitTestBookStore
{
    [TestClass]
    public class UnitTestBookPromo
    {
        [TestMethod]
        public void BookPromo_GetBookPromo_NotNull()
        {
            Mock<DbBookStoreContext> mockdb = new Mock<DbBookStoreContext>();

            var usersMockBook = UnitTestDBset.CreateDbSetMock(UnitTestDBset.BookList());
            mockdb.Setup(x => x.Book).Returns(usersMockBook.Object);

            var usersMockCategory = UnitTestDBset.CreateDbSetMock(UnitTestDBset.CategoryList());
            mockdb.Setup(x => x.Category).Returns(usersMockCategory.Object);

            var usersMockPromo = UnitTestDBset.CreateDbSetMock(UnitTestDBset.PromoList());
            mockdb.Setup(x => x.Promo).Returns(usersMockPromo.Object);

            //===============================================
            IBook testbook = UnitTestDBset.BookList()[0];
            var bookpromo = new BookPromo(mockdb.Object);
            var resultpromo = bookpromo.GetBookPromo(testbook).Result;

            Assert.AreEqual(testbook.PromoID, resultpromo.ID);
            Assert.AreNotEqual(0, resultpromo.Discount);
        }

        [TestMethod]
        public void BookPromo_GetBookPromo_EmptyOrNull()
        {
            Mock<DbBookStoreContext> mockdb = new Mock<DbBookStoreContext>();

            var usersMockBook = UnitTestDBset.CreateDbSetMock(UnitTestDBset.BookList());
            mockdb.Setup(x => x.Book).Returns(usersMockBook.Object);

            var usersMockCategory = UnitTestDBset.CreateDbSetMock(UnitTestDBset.CategoryList());
            mockdb.Setup(x => x.Category).Returns(usersMockCategory.Object);

            var usersMockPromo = UnitTestDBset.CreateDbSetMock(UnitTestDBset.PromoList());
            mockdb.Setup(x => x.Promo).Returns(usersMockPromo.Object);

            //===============================================
            IBook testbook = UnitTestDBset.BookList()[1];
            var bookpromo = new BookPromo(mockdb.Object);
            var resultpromo = bookpromo.GetBookPromo(testbook).Result;

            Assert.IsNull(resultpromo);
        }

        [TestMethod]
        public void BookPromo_GetBookOriginalPrice_NotNull()
        {
            Mock<DbBookStoreContext> mockdb = new Mock<DbBookStoreContext>();

            var usersMockBook = UnitTestDBset.CreateDbSetMock(UnitTestDBset.BookList());
            mockdb.Setup(x => x.Book).Returns(usersMockBook.Object);

            var usersMockCategory = UnitTestDBset.CreateDbSetMock(UnitTestDBset.CategoryList());
            mockdb.Setup(x => x.Category).Returns(usersMockCategory.Object);

            var usersMockPromo = UnitTestDBset.CreateDbSetMock(UnitTestDBset.PromoList());
            mockdb.Setup(x => x.Promo).Returns(usersMockPromo.Object);

            //===============================================
            IBook testbook = UnitTestDBset.BookList()[0];
            var bookpromo = new BookPromo(mockdb.Object);
            var resultbook = bookpromo.GetBookOriginalPrice(testbook).Result;

            Assert.AreEqual(testbook.Cost, resultbook.Cost);
            Assert.AreEqual(testbook.Name, resultbook.Name);
            Assert.AreEqual(testbook.CategoryID, resultbook.CategoryID);
        }

        [TestMethod]
        public void BookPromo_GetBookOriginalPrice_EmptyOrNull()
        {
            Mock<DbBookStoreContext> mockdb = new Mock<DbBookStoreContext>();

            var usersMockBook = UnitTestDBset.CreateDbSetMock(UnitTestDBset.BookList());
            mockdb.Setup(x => x.Book).Returns(usersMockBook.Object);

            var usersMockCategory = UnitTestDBset.CreateDbSetMock(UnitTestDBset.CategoryList());
            mockdb.Setup(x => x.Category).Returns(usersMockCategory.Object);

            var usersMockPromo = UnitTestDBset.CreateDbSetMock(UnitTestDBset.PromoList());
            mockdb.Setup(x => x.Promo).Returns(usersMockPromo.Object);

            //===============================================
            IBook testbook = UnitTestDBset.BookList()[0];
            var bookpromo = new BookPromo(mockdb.Object);
            var resultbook = bookpromo.GetBookOriginalPrice(testbook).Result;

            Assert.IsNotNull(resultbook.Cost);
            Assert.AreNotEqual(0, resultbook.Cost);
        }
    }
}