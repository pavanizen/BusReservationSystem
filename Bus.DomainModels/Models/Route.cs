using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Bus.DomainModels.Models
{
    public class Route
    {
        [Key]
        public int RouteId { get; set; }
        [Required(ErrorMessage = "Please enter Location")]
        public string FromLocation { get; set; }
        [Required(ErrorMessage = "Please enter Location")]
        public string ToLocation { get; set; }
        
        [Required(ErrorMessage = "Please enter the Price")]
        [Range(0, Double.MaxValue)]
        
        public decimal Price { get; set; }
        public virtual List<Trip> Trips { get; set; }
    }
}
