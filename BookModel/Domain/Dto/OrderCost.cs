namespace BookModel.Domain.Dto
{
    public class OrderCost : IOrderCost
    {
        public double Subtotal { get; set; }
        public double Totaltax { get; set; }
        public double TotalCost { get; set; }
    }
}