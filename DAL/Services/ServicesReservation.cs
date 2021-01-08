using DAL.IRepo;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DAL.Services
{
    public class ServicesReservation : Irepo<Reservation>
    {
        #region singleton

        private static ServicesReservation _instance;

        public static ServicesReservation Instance
        {
            get
            {
                _instance = _instance ?? new ServicesReservation();
                return _instance;
            }
        }

        #endregion

        #region SqlConnection

        private static SqlConnection _connection;

        protected ServicesReservation()
        {
            _connection = new SqlConnection(@"Data Source=DESKTOP-DLBID37\SQL2019DEV;Initial Catalog=DbtOOL2;Integrated Security=True");
            _connection.Open();
        }

        #endregion

        public Reservation GetById(int id)
        {
            using(SqlCommand cmd = _connection.CreateCommand())
            {
                cmd.CommandText = "select * from Reservation where Id = @id";
                cmd.Parameters.AddWithValue("id", id);
                using(SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return  new Reservation
                        {
                            Id = (int)reader["Id"], 
                            DateReservation = (DateTime)reader["DateReservation"],
                            IdClient = (int)reader["IdClient"],
                            IdEvent = (int)reader["IdEvent"],
                            NbrPlace = (int)reader["NbrPlace"],
                            PrixTatal = (int)reader["PrixTotal"],
                        };
                    }
                    return null;
                }
            }
        }

        public IEnumerable<Reservation> GetAll()
        {
            using(SqlCommand cmd = _connection.CreateCommand())
            {
                cmd.CommandText = "select * from Reservation";
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    List<Reservation> list = new List<Reservation>();
                    while (reader.Read())
                    {
                        list.Add(new Reservation
                        {
                            Id = (int)reader["Id"],
                            DateReservation = (DateTime)reader["DateReservation"],
                            IdClient = (int)reader["IdClient"],
                            IdEvent = (int)reader["IdEvent"],
                            NbrPlace = (int)reader["NbrPlace"],
                            PrixTatal = (int)reader["PrixTotal"]
                        });
                    }
                    return list;
                };
            };
        }

        public int Create(Reservation entity)
        {
            using (SqlCommand cmd = _connection.CreateCommand())
            {
                cmd.CommandText = "insert into Reservation output inserted.Id values(@DateReservation, @IdClient, @IdEvent, @NbrPlace, @PrixTotal)";
                cmd.Parameters.AddWithValue("DateReservation", entity.DateReservation);
                cmd.Parameters.AddWithValue("IdClient",entity.IdClient);
                cmd.Parameters.AddWithValue("IdEvent", entity.IdEvent);
                cmd.Parameters.AddWithValue("NbrPlace",entity.NbrPlace );
                cmd.Parameters.AddWithValue("PrixTotal", entity.PrixTatal);

                return (int)cmd.ExecuteScalar();
            };
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Reservation entity)
        {
            throw new NotImplementedException();
        }
    }
}
