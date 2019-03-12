namespace BookModel.Domain.Interface
{
    public interface IBook
    {
        int ID { get; set; }
        string Name { get; set; }
        double Cost { get; set; }
        int CategoryID { get; set; }
        int PromoID { get; set; }
    }
}