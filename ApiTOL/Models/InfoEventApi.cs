using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTOL.Models
{
    public class InfoEventApi
    {
        public int Id { get; set; }
        public DateTime DateEvent { get; set; }
        public int IdSalle { get; set; }
        public int IdEvent { get; set; }
        public int PlaceRestante { get; set; }
        public int PrixPlace { get; set; }
    }
}
