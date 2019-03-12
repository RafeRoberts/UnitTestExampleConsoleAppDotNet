using BookModel.Domain.Interface;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookModel.Domain.Entities
{
    [Table("Promo")]
    public class Promo : IPromo
    {
        public int ID { get; set; }
        public double Discount { get; set; }
        public string Description { get; set; }
    }
}