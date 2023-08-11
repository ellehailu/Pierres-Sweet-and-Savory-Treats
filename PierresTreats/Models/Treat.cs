using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PierresTreats.Models
{
    public class Treat
    {
        public int TreatId { get; set; }

        [Required(ErrorMessage = "Please enter a valid treat name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter a valid selection")]
        public string Allergens { get; set; }

        public List<TreatFlavor> JoinEntities { get; }
    }
}