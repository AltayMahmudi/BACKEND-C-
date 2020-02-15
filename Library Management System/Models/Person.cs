using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library_Management_System.Models
{
    public class Person
    {


        [Key]
        public int PersonID { get; set; }


        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string Surname { get; set; }

        [Required]
        [MaxLength(15)]
        public string Phone { get; set; }


        [Required]
        [MaxLength(50)]
        public string Email { get; set; }

        public int BookInventory { get; set; }


    }
 }
