using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FormsAppPractice.Models
{
    public class Product
    {
        [Display(Name="Urun ID")]
        public int Id { get; set; }

        [Display(Name="Ad")]
        public string? Name { get; set; }

        [Display(Name="Fiyat")]
        public decimal Price { get; set; }

        [Display(Name="Resim")]
        public string? Image { get; set; }
        public bool IsActive { get; set; }
        public int CategoryId { get; set; }
    }
}