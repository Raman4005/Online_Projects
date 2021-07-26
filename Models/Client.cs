using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Online_Projects.Models
{
    public class Client
    {
        
        //Client id
        public int Id { get; set; }

        //Client name
        [Required]
        public string Name { get; set; }

        //Client email
        public string Email { get; set; }

        //is a senior or not
        public Boolean Vetran { get; set; }
    }
}
