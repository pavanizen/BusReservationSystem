using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Bus.DomainModels.Models
{
    public class Trip
    {
        [Key]
        public int TripID { get; set; }
        

        [Required(ErrorMessage ="Please enter the Journey Date")]
        public string JourneyDate { get; set; }


        [Required(ErrorMessage = "Please enter the number of available seats")]
        [Display(Name = "Available Seats")]
        public string AvailableSeats { get; set; }

        [Required(ErrorMessage = "Please enter the Route Id")]
        [ForeignKey("Route")]
        public int RouteID { get; set; }

        [Required(ErrorMessage = "Please enter the Bus Id")]
        [ForeignKey("BusDetails")]
        public int BusID { get; set; }
        
        public virtual Route Route { get; set; }
        public virtual BusDetails BusDetails { get; set; }
        public virtual List<Ticket> Tickets { get; set; }
    }
}
