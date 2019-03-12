using BookModel.Domain.Dto;
using BookService;
using System;
using System.Text;

namespace BookStore
{
    public class BookStore
    {
        private readonly BookDataService _dbBookManager;

        public BookStore()
        {
            _dbBookManager = new BookDataService();
        }

        public string DisplayOrder()
        {
            StringBuilder displaydata = new StringBuilder();

            try
            {
                var booklist = _dbBookManager.GetBookOrderList().Result;
                if (booklist != null)
                {
                    foreach (var item in booklist)
                    {
                        IBookSale booksale = _dbBookManager.GetBookOnSale(item).Result;
                        string ordername = booksale.BookDetail.Name.PadRight(30) + booksale.CategoryDetail.Name.PadRight(20);

                        if (Math.Abs(booksale.DiscountedPrice()) > 0)
                        {
                            string discountorder = booksale.PromoDetail.Description.PadRight(25) + booksale.BookDetail.Cost;
                            displaydata.AppendLine(ordername + booksale.DiscountedPrice());
                            displaydata.AppendLine(discountorder);
                        }
                        else
                        {
                            displaydata.AppendLine(ordername + booksale.BookDetail.Cost);
                        }
                    }

                    IOrderCost totalorder = _dbBookManager.CalculateTotalCost().Result;

                    displaydata.AppendLine();
                    displaydata.AppendLine("============================");
                    displaydata.AppendLine("Sub Total :" + totalorder.Subtotal);
                    displaydata.AppendLine("Total Tax :" + totalorder.Totaltax);
                    displaydata.AppendLine("Total     :" + totalorder.TotalCost);
                    displaydata.AppendLine("============================");
                    displaydata.AppendLine();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return displaydata.ToString();
        }
    }
}