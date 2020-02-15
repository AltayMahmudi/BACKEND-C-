using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Library_Management_System.Models
{
	public class User
	{
		[Key]
		public int İd { get; set; }

		[Required]
		[MaxLength(50)]
		public string Username { get; set; }

		[Required]
		[MaxLength(100)]
		public string Password { get; set; }

		public BookInfo BookInfos { get; set; }


	}
}
