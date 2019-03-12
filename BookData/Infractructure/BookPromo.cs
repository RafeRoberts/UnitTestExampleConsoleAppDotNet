using BookData.Repository;
using BookModel.Domain.Interface;
using System.Linq;
using System.Threading.Tasks;

namespace BookData.Infractructure
{
    public class BookPromo
    {
        private DbBookStoreContext _dbBookStore;

        public BookPromo(DbBookStoreContext bookdb)
        {
            _dbBookStore = bookdb;
        }

        public Task<IPromo> GetBookPromo(IBook bookprmo)
        {
            if (bookprmo == null)
                return null;

            var promodetail = _dbBookStore.Promo.FirstOrDefault(x => x.ID.Equals(bookprmo.PromoID));
            return Task.FromResult<IPromo>(promodetail);
        }

        public Task<IBook> GetBookOriginalPrice(IBook bookprmo)
        {
            var bookdetail = _dbBookStore.Book.FirstOrDefault(x => x.ID.Equals(bookprmo.ID));
            return Task.FromResult<IBook>(bookdetail);
        }
    }
}