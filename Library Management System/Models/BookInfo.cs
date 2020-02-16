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

		[Required]
		[MaxLength(50)]
		public string BookName { get; set; }

		[Required]
		[MaxLength(50)]
		public string BookAuthor { get; set; }

		[Required]
		[MaxLength(50)]
		public string BookPublicationName { get; set; }

		[Column(TypeName="date")]
		public DateTime BookReleaseDate { get; set; }

		[Required]
		[MaxLength(50)]
		public string BookPrice { get; set; }

		[Required]
		[MaxLength(50)]
		public string BookQuantity { get; set; }


	}
}
