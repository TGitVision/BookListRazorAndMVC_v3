using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookListMVCCore31_v3.Models
{
    [Table ("ytRZMVC_Books")]
    public class Book
    {
        [Key]
        public int Book_ID { get; set; }

        [Required]
        public string Name { get; set; }

        public string Author { get; set; }

        public string ISBN { get; set; }

    }
}
