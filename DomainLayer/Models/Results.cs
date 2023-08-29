﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public class Results : BaseEntity
    {
        [Key]
        public int Id { get; set; }

        public string? ResultsStatus { get; set; }
        
        public int StudentId { get; set; }

        public Student Students { get; set; }

    }
}
