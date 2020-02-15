using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library_Management_System.Models
{
	public class BookInfo
	{
	    [Key]
	    public int BookID { get; set; }
		
		public string BookName { get; set; }
		public string BookAuthor { get; set; }
		public string BookPublicationName { get; set; }

		[Column(TypeName="date")]
		public DateTime BookPurchaseDate { get; set; }
		public string BookPrice { get; set; }
		public string BookQuantity { get; set; }


	}
}
