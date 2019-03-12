using BookModel.Domain.Entities;
using System.Data.Entity;
using System.Data.SQLite;

namespace BookData.Repository
{
    public class DbBookStoreContext : DbContext
    {
        public DbBookStoreContext() :
            base(new SQLiteConnection()
            {
                ConnectionString = new SQLiteConnectionStringBuilder()
                {
                    DataSource = "DB\\bookstore.db",
                    ForeignKeys = true
                }.ConnectionString
            }, true)
        {
        }

        public virtual DbSet<Book> Book { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Promo> Promo { get; set; }
    }
}