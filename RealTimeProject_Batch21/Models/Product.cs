﻿using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealTimeProject_Batch21.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }
        [Required]
        [MaxLength(100)]
        [MinLength(10)]
        public string Title {  get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string ISBN { get; set;}
        [Required]
        public string Author { get;set; }
        [Required]
        public float Price { get;set; }
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
        [ValidateNever]
        public string ImageUrl { get; set; }

        [ValidateNever]
        public List<ProductImages> ProductImages { get; set; }
    }
}
