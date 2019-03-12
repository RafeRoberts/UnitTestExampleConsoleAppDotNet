using BookData.Infractructure;
using BookData.Repository;
using BookModel.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace UnitTestBookStore
{
    [TestClass]
    public class UnitTestBookManager
    {
        [TestMethod]
        public void BookManager_GetBookOrderList_NotNUll()
        {
            Mock<DbBookStoreContext> mockdb = new Mock<DbBookStoreContext>();
            List<Book> listofbooks = UnitTestDBset.BookList();

            var usersMock = UnitTestDBset.CreateDbSetMock(listofbooks);
            mockdb.Setup(x => x.Book).Returns(usersMock.Object);

            var bookmnager = new BookManager(mockdb.Object);
            var orderlist = bookmnager.GetBookOrderList().Result;

            var testbook = orderlist.Find(x => x.ID.Equals(2));
            var resultbook = orderlist.Find(x => x.ID.Equals(2));

            Assert.AreEqual(listofbooks.Count, orderlist.Count);
            Assert.AreEqual(testbook.Name, resultbook.Name);
            Assert.AreEqual(testbook.Cost, resultbook.Cost);
            Assert.AreEqual(testbook.PromoID, resultbook.PromoID);
            Assert.AreEqual(testbook.CategoryID, resultbook.CategoryID);
        }

        [TestMethod]
        public void BookManager_GetBookOrderList_EmptyOrNull()
        {
            Mock<DbBookStoreContext> mockdb = new Mock<DbBookStoreContext>();
            List<Book> listofbooks = new List<Book>();

            var usersMock = UnitTestDBset.CreateDbSetMock(listofbooks);
            mockdb.Setup(x => x.Book).Returns(usersMock.Object);
            var bookmnager = new BookManager(mockdb.Object);
            var orderlist = bookmnager.GetBookOrderList().Result;
            var testbook = orderlist.Find(x => x.ID.Equals(1));
            var resultbook = orderlist.Find(x => x.ID.Equals(1));

            Assert.AreEqual(listofbooks.Count, orderlist.Count);
        }
    }
}