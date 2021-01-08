using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace billetsDeux.Models
{
    public class SalleWeb
    {
        public int Id { get; set; }
        public string NomSalle { get; set; }
        public string AdresseSalle { get; set; }
        public int Capacite { get; set; }
        public string ImageSalles { get; set; }
        public string HistoireSalle { get; set; }
    }
}
