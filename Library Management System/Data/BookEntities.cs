using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Library_Management_System.Models;

namespace Library_Management_System.Data
{
	public class BookEntities:DbContext
	{
		public BookEntities() : base("BookEntities")
		{
			Database.SetInitializer(new DropCreateDatabaseIfModelChanges<BookEntities>());
		}

		public DbSet<User> Users { get; set; }
		public DbSet<BookInfo> Bookİnfoes { get; set; }

        public DbSet<Person> People { get; set; }
        public DbSet<OrderBook> OrderBooks { get; set; }
	}
}
