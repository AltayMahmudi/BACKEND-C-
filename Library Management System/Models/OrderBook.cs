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

		[Required]
		[MaxLength(50)]
		public string BookOrderName { get; set; }

		[Required]
		[MaxLength(50)]
		public string PersonOrderName { get; set; }

		[Column(TypeName = "date")]
		public DateTime Deadline { get; set; }

		[Column(TypeName = "date")]
		public DateTime IssueDate { get; set; }


		//public string QuantityLeft { get; set; }

	}
}

