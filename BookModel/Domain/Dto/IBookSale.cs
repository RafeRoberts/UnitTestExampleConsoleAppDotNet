using BookModel.Domain.Interface;

namespace BookModel.Domain.Dto
{
    public interface IBookSale
    {
        IBook BookDetail { get; set; }
        ICategory CategoryDetail { get; set; }
        IPromo PromoDetail { get; set; }

        double DiscountedPrice();
    }
}