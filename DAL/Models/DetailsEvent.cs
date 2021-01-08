using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class DetailsEvent
    {
        public int Id { get; set; }
        public string Realisateur { get; set; }
        public string Description { get; set; }
        public int Duree { get; set; }
        public string Image { get; set; }
        public int IdInfoEvent { get; set; }
        public DateTime Date { get; set; }
        public int IdSalle { get; set; }
        public int IdEvent { get; set; }
        public int PlaceRestante { get; set; }
        public int PrixPlace { get; set; }
    }
}
