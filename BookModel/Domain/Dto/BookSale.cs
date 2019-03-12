using BookModel.Domain.Interface;
using System;

namespace BookModel.Domain.Dto
{
    public class BookSale : IBookSale
    {
        public IBook BookDetail { get; set; }
        public IPromo PromoDetail { get; set; }
        public ICategory CategoryDetail { get; set; }

        public BookSale(IBook bookdata)
        {
            BookDetail = bookdata;
        }

        public double DiscountedPrice()
        {
            if (PromoDetail == null)
                return 0;

            try
            {
                double discount = PromoDetail.Discount * BookDetail.Cost;
                double discountedprice = BookDetail.Cost - discount;
                return Math.Round(discountedprice, 2);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return 0;
        }
    }
}