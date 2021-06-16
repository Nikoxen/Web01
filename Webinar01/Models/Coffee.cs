﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Webinar01.Models
{
    public class Coffee
    { 
        [Key]
        public int Id { get; set; }

        public String Name { get; set; }

        public int Volume { get; set; }

        [ForeignKey("Company")]
        public int CompanyId { get; set; }

        public Company Company { get; set; }
    }

    public class Company
    {
        public int Id { get; set; }

        public String CompanyName { get; set; }
    }
}