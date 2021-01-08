using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DAL.Services.ServicesSpecialJoin
{
    public class ServicesDetailEvent
    {
        private static ServicesDetailEvent _instance;
        public static ServicesDetailEvent Instance
        {
            get
            {
                _instance = _instance ?? new ServicesDetailEvent();
                return _instance;
            }
        }

        private SqlConnection _connection;

        protected ServicesDetailEvent()
        {
            _connection = new SqlConnection(@"Data Source=DESKTOP-DLBID37\SQL2019DEV;Initial Catalog=DbtOOL2;Integrated Security=True");
            _connection.Open();
        }
        public List<DetailsEvent> GetInfoEventById(int id)
        {
            using(SqlCommand cmd = _connection.CreateCommand())
            {
                cmd.CommandText = "Select * from Event e join InfoEvent i on e.Id = IdEvent where e.Id = @Id";
                cmd.Parameters.AddWithValue("Id", id);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    List<DetailsEvent> lde = new List<DetailsEvent>();
                    while (reader.Read())
                    {
                        lde.Add(new DetailsEvent
                        {
                            Id = (int)reader["Id"],
                            Realisateur = (string)reader["Realisateur"],
                            Description = (string)reader["Description"],
                            Duree = (int)reader["Duree"],
                            Image = (string)reader["Image"],
                            IdInfoEvent = (int)reader["Id"],
                            Date = (DateTime)reader["Date"],
                            IdSalle = (int)reader["IdSalle"],
                            IdEvent = (int)reader["IdEvent"],
                            PlaceRestante = (int)reader["PlaceRestante"],
                            PrixPlace = (int)reader["PrixPlace"]
                        });
                    }
                    return lde;
                }
            }
        }
    }
}
