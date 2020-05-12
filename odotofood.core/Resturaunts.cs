using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace odotofood.core
{
    public class Resturaunts
    {
        public int ID { get; set; }
        [Required,MaxLength(80)]
        public string Name { get; set; }
        [Required, MaxLength(250)]
        public string location { get; set; }
        public CuisineType Type { get; set; }
       
    }
}
