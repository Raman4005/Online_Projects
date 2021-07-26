using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Online_Projects.Models
{
    public class Bids
    {
        //Bid id 
        public int Id { get; set; }

        //Bid value 
        public decimal BidValue { get; set; }


        // Project id related key
       
        public int ProjectId { get; set; }

        //Developer related key
        public int DeveloperId { get; set; }

        //Project reference
        
        public Project Project { get; set; }

        //Developer reference
        public Developers Developer { get; set; }


    }
}
