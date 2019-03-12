using BookModel.Domain.Interface;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookModel.Domain.Entities
{
    [Table("Book")]
    public class Book : IBook
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public double Cost { get; set; }
        public int CategoryID { get; set; }
        public int PromoID { get; set; }
    }
}