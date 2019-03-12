using BookData.Repository;
using BookModel.Domain.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookData.Infractructure
{
    public class BookManager
    {
        private DbBookStoreContext _dbBookStore;

        public BookCategory Category;
        public BookPromo Promo;

        public BookManager(DbBookStoreContext bookdb)
        {
            _dbBookStore = bookdb;
            Category = new BookCategory(_dbBookStore);
            Promo = new BookPromo(_dbBookStore);
        }

        public Task<List<IBook>> GetBookOrderList()
        {
            return Task.FromResult(_dbBookStore.Book.ToList<IBook>());
        }
    }
}