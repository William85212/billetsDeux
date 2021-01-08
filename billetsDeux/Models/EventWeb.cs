using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace billetsDeux.Models
{
    public class EventWeb
    {
        public int Id { get; set; }
        public string NomSpectacle { get; set; }
        public string Realisateur { get; set; }
        public string Description { get; set; }
        public int Duree { get; set; }
        public string Image { get; set; }
    }
}
