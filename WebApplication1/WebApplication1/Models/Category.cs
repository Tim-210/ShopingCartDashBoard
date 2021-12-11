using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace WebApplication1.Models
{
    [Table("Category")]
    public partial class Category
    {
        [Key]
        [Column("CategoryID")]
        public int CategoryId { get; set; }


        [Required]
        [StringLength(10)]
        public string Name { get; set; }
    }
}
