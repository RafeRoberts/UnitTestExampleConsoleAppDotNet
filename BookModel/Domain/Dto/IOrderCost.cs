namespace BookModel.Domain.Dto
{
    public interface IOrderCost
    {
        double Subtotal { get; set; }
        double TotalCost { get; set; }
        double Totaltax { get; set; }
    }
}