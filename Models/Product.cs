using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace FormsAppPractice.Models
{
    // [Bind("Name","Price")]
    public class Product
    {
        [Display(Name="Urun ID")]
        // [BindNever]
        public int Id { get; set; }

        [Required]
        [Display(Name="Ad")]
        [StringLength(100)]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Gerekli bir alan")]
        [Range(0,100000,ErrorMessage = "Fiyat aralığa dikkat ediniz")]
        [Display(Name="Fiyat")]
        public decimal? Price { get; set; }

        [Display(Name="Resim")]
        public string? Image { get; set; }

        public bool IsActive { get; set; }

        [Required]
        [Display(Name="Kategori")]
        public int? CategoryId { get; set; }
    }
}