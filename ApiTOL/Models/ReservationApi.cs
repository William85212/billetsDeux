using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTOL.Models
{
    public class ReservationApi
    {
        public int Id { get; set; }
        public DateTime DateReservation { get; set; }
        public int NbrPlace { get; set; }
        public int IdClient { get; set; }
        public int IdEvent { get; set; }
        public int PrixTatal { get; set; }
    }
}
