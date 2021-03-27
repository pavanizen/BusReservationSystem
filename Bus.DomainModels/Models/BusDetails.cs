using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Bus.DomainModels.Models
{
   public class BusDetails
    {
        [Key]
        public int BusId { get; set; }
        [Required(ErrorMessage ="Please enter the BusName")]
        [StringLength(20,MinimumLength =3,ErrorMessage ="Maximum 20 characters")]
        public string BusName { get; set; }

       

        [Required]
        [EnumDataType(typeof(Category))]
        public Category Category { get; set; }
        [Required]
        //[Range(1, 30)]
        [RegularExpression(@"^(3[00]|[12][0-9]|[1-9])$", ErrorMessage = "Maximum capacity is 30")]
        public int Capacity { get; set; }
        public virtual List<Trip> Trips { get; set; }
    }
}
