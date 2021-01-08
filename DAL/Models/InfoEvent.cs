using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace DAL.Models
{
    public class InfoEvent
    {
        public int Id { get; set; }
        public DateTime DateEvent { get; set; }
        public int IdSalle { get; set; }
        public int IdEvent { get; set; }
        public int PlaceRestante { get; set; }
        public int PrixPlace { get; set; }

    }
}
