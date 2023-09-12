using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebDemoMVC.EntitiesFrameWork.Entites
{
    [Table("Category")]

    public class Category
    {
        public int CategoryId { get; set; }

        [Required]
        [Column("CategoryName")]
        [MaxLength(200)]
        public string CategoryName { get; set; }

        public string CategoryDescription { get; set; }
    }
}