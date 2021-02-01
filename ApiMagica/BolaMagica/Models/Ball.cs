using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BolaMagica.Models
{ 
    public class Ball
    {
        [Key]
        public int BallId { get; set; }
        public string BallMessage { get; set; }

    }
}