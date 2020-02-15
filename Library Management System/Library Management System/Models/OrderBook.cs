using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System.Models
{
	public class OrderBook
	{
		public int id { get; set; }

		public int OrderId { get; set; }

		public int BookId { get; set; }

		public DateTime Deadline { get; set; }

		public DateTime ReturnDate { get; set; }

		public string QuantityLeft { get; set; }

		public Order Orders { get; set; }

		public BookInfo BookInfo { get; set; }

	}
}

