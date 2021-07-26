using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Online_Projects.Models
{
    public class Developers
    {

        //Developer id 
        public int Id { get; set; }

        //Developer name 
        [Required]
        public string Name { get; set; }

        //Experiance of the developer in years
        public int Experience { get; set; }
    }
}
