﻿using System.ComponentModel.DataAnnotations;

namespace lab6.Data

{
    public class Address
    {
        [Key]
        public int ID { get; set; }
        public string Street { get; set; } = null!;
        public string House { get; set; } = null!;
        public string Apartment { get; set; } = null!;

    }
}
