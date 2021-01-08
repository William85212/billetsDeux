using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTOL.Models
{
    public class SalleApi
    {
        public int Id { get; set; }
        public string NomSalle { get; set; }
        public string AdresseSalle { get; set; }
        public int Capacite { get; set; }
        public string ImageSalles { get; set; }
        public string HistoireSalle { get; set; }
    }
}
