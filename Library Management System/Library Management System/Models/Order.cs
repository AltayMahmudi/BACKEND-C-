using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library_Management_System.Models
{
	public class Order
	{

		[Key]
		public int OrderID { get; set; }


		[Required]
		public float Money { get; set; }

		[Required]
		public DateTime BookReturnededDate { get; set; }
	}
}
