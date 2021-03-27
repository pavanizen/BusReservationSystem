using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Bus.DomainModels.Models
{
   public class Ticket
    {
        [Key]
        public int TicketId { get; set; }
        public int PassengerCount { get; set; }
        [Required]
        [ForeignKey("Trip")]
        public int TripID { get; set; }

       
        public virtual Trip Trip { get; set; }

    }
}
