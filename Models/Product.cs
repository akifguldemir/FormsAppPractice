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

        [Required]
        [Display(Name="Ad")]
        public string? Name { get; set; }

        [Display(Name="Fiyat")]
        public decimal Price { get; set; }

        [Display(Name="Resim")]
        public string? Image { get; set; }

        [Display(Name="Aktif")]
        public bool IsActive { get; set; }

        [Display(Name="Kategori")]
        public int CategoryId { get; set; }
    }
}