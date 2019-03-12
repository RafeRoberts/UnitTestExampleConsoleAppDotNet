namespace BookModel.Domain.Interface
{
    public interface IPromo
    {
        string Description { get; set; }
        double Discount { get; set; }
        int ID { get; set; }
    }
}