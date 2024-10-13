using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Project2WooxTravel.Entities
{
    public class Category
    {
        public int CategoryId { get; set; }
        [StringLength(100)]
        public string CategoryName { get; set; }
        public bool CategoryStatus { get; set; }
    }
}