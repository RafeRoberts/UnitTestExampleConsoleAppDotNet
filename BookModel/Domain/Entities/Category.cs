using BookModel.Domain.Interface;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookModel.Domain.Entities
{
    [Table("Category")]
    public class Category : ICategory
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
}