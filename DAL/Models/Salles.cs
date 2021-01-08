using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class Salles
    {
        public int Id { get; set; }
        public string NomSalle { get; set; }
        public string AdresseSalle { get; set; }
        public int Capacite { get; set; }
        public string ImageSalles { get; set; }
        public string HistoireSalle { get; set; }
    }
}
