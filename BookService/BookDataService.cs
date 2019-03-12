using BookData;
using BookData.Infractructure;
using BookData.Repository;
using BookModel.Domain.Dto;
using BookModel.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookService
{
    public class BookDataService
    {
        private DbBookStoreContext _dbBookStore;
        private BookManager _dbBookManager;

        public BookDataService(DbBookStoreContext dbBook)
        {
            SetDbService(dbBook);
        }

        public BookDataService()
        {
            SetDbService(new DbBookStoreContext());
        }

        public void SetDbService(DbBookStoreContext dbBook)
        {
            _dbBookStore = dbBook;
            _dbBookManager = new BookManager(_dbBookStore);
        }

        public Task<List<IBook>> GetBookOrderList()
        {
            return Task.FromResult(_dbBookManager.GetBookOrderList().Result);
        }

        public Task<IBook> GetBookOriginalPrice(IBook book)
        {
            return Task.FromResult<IBook>(_dbBookManager.Promo.GetBookOriginalPrice(book).Result);
        }

        public Task<IBookSale> GetBookOnSale(IBook book)
        {
            IBookSale booksale = new BookSale(book);
            booksale.PromoDetail = _dbBookManager.Promo.GetBookPromo(book).Result;
            booksale.CategoryDetail = _dbBookManager.Category.GetBookCategory(book).Result;
            return Task.FromResult<IBookSale>(booksale);
        }

        public Task<IOrderCost> CalculateTotalCost()
        {
            IOrderCost totalcost = new OrderCost();

            try
            {
                var booklist = GetBookOrderList().Result;
                if (booklist != null)
                {
                    foreach (var item in booklist)
                    {
                        IBookSale booksale = GetBookOnSale(item).Result;
                        if (Math.Abs(booksale.DiscountedPrice()) > 0)
                        {
                            totalcost.Subtotal += booksale.DiscountedPrice();
                        }
                        else
                        {
                            totalcost.Subtotal += booksale.BookDetail.Cost;
                        }
                    }

                    totalcost.Subtotal = Math.Round(totalcost.Subtotal, 2);
                    totalcost.Totaltax = Math.Round(totalcost.Subtotal * (Constant.ORDER_TAX_TOTAL), 2);
                    totalcost.TotalCost = Math.Round((totalcost.Subtotal + totalcost.Totaltax), 2);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return Task.FromResult<IOrderCost>(totalcost);
        }
    }
}