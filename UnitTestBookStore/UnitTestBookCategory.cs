using BookData.Infractructure;
using BookData.Repository;
using BookModel.Domain.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Linq;

namespace UnitTestBookStore
{
    [TestClass]
    public class UnitTestBookCategory
    {
        [TestMethod]
        public void BookCategory_GetBookCategory_NotNull()
        {
            Mock<DbBookStoreContext> mockdb = new Mock<DbBookStoreContext>();

            var usersMockBook = UnitTestDBset.CreateDbSetMock(UnitTestDBset.BookList());
            mockdb.Setup(x => x.Book).Returns(usersMockBook.Object);

            var usersMockCategory = UnitTestDBset.CreateDbSetMock(UnitTestDBset.CategoryList());
            mockdb.Setup(x => x.Category).Returns(usersMockCategory.Object);

            var usersMockPromo = UnitTestDBset.CreateDbSetMock(UnitTestDBset.PromoList());
            mockdb.Setup(x => x.Promo).Returns(usersMockPromo.Object);

            //===============================================
            var Category = new BookCategory(mockdb.Object);
            IBook testbook = UnitTestDBset.BookList()[1];
            ICategory testcategory = UnitTestDBset.CategoryList().FirstOrDefault(x => x.ID.Equals(testbook.CategoryID));

            var bookcategory = Category.GetBookCategory(testbook).Result;

            Assert.AreEqual(testbook.CategoryID, bookcategory.ID);
            Assert.AreEqual(testcategory?.Name, bookcategory.Name);
        }
    }
}