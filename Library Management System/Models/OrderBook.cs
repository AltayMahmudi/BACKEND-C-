using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library_Management_System.Models
{
	public class OrderBook
	{
		[Key]
		public int OrderID { get; set; }

		public string BookName { get; set; }

		public string StudientName { get; set; }

		public DateTime IssueDate { get; set; }

		public DateTime Deadline { get; set; }

		public DateTime ReturnDate { get; set; }

		public string QuantityLeft { get; set; }

		public BookInfo BookInfo { get; set; }

	}
}

