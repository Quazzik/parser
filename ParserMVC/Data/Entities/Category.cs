﻿using System.ComponentModel.DataAnnotations;

namespace parser.Models.Entities
{
    public class Category
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
