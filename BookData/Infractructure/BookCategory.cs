using BookData.Repository;
using BookModel.Domain.Interface;
using System.Linq;
using System.Threading.Tasks;

namespace BookData.Infractructure
{
    public class BookCategory
    {
        private DbBookStoreContext _dbBookStore;

        public BookCategory(DbBookStoreContext bookdb)
        {
            _dbBookStore = bookdb;
        }

        public Task<ICategory> GetBookCategory(IBook bookprmo)
        {
            var category = _dbBookStore.Category.FirstOrDefault(x => x.ID.Equals(bookprmo.CategoryID));
            return Task.FromResult<ICategory>(category);
        }
    }
}