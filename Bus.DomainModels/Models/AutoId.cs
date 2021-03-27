using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Bus.DomainModels.Models
{
    public class AutoId
    {
        [Key]
        public string IdName { get; set; }
        [Required]
        public int Identity { get; set; }

    }
}
