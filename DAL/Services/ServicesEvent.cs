using DAL.IRepo;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DAL.Services
{
    public class ServicesEvent : Irepo<Event>
    {
        #region singleton

        private static ServicesEvent _instance;
        
        public static ServicesEvent Instance
        {
            get
            {
                _instance = _instance ?? new ServicesEvent();
                return _instance;
            }
        }

        #endregion

        #region Sqlconnection

        private SqlConnection _connection;
        public ServicesEvent()
        {
            _connection = new SqlConnection(@"Data Source=DESKTOP-DLBID37\SQL2019DEV;Initial Catalog=DbtOOL2;Integrated Security=True");
            _connection.Open();
        }


        #endregion




        public int Create(Event e )
        {
            using(SqlCommand cmd = _connection.CreateCommand())
            {
                cmd.CommandText = "insert into Event output inserted.Id values (NomSpectacle, Realisateur, Description, Duree , Image)";

                cmd.Parameters.AddWithValue("NomSpectacle", e.NomSpectacle);
                cmd.Parameters.AddWithValue("Realisateur",e.Realisateur);
                cmd.Parameters.AddWithValue("Description", e.Description);
                cmd.Parameters.AddWithValue("Duree", e.Duree);
                cmd.Parameters.AddWithValue("Image", e.Image);

                return (int)cmd.ExecuteScalar();
            }
        }

        public void Delete(int id)
        {
            using(SqlCommand cmd = _connection.CreateCommand())
            {
                cmd.CommandText = "delete from Event where Id = @id";
                cmd.Parameters.AddWithValue("id", id);

                cmd.ExecuteNonQuery();
            }
        }
        
        public IEnumerable<Event> GetAll()
        {
            using(SqlCommand cmd = _connection.CreateCommand())
            {
                cmd.CommandText = "select * from Event";
                using(SqlDataReader reader = cmd.ExecuteReader())
                {
                    List<Event> list = new List<Event>();
                    while (reader.Read())
                    {
                        list.Add(new Event
                        {
                            Id = (int)reader["Id"],
                            NomSpectacle = (string)reader["NomSpectacle"],
                            Realisateur = (string)reader["Realisateur"],
                            Description = (string)reader["Description"],
                            Duree = (int)reader["Duree"],
                            Image = (string)reader["Image"],
                        });
                    }
                    return list;
                }
            }
        }

        public Event GetById(int id)
        {
            using(SqlCommand cmd = _connection.CreateCommand())
            {
                cmd.CommandText = "select * from Event where Id = @id";
                cmd.Parameters.AddWithValue("id", id);

                using(SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Event
                        {
                            Id = (int)reader["Id"],
                            NomSpectacle = (string)reader["NomSpectacle"],
                            Realisateur = (string)reader["Realisateur"],
                            Description = (string)reader["Description"],
                            Duree = (int)reader["Duree"],
                            Image = (string)reader["Image"],
                        };
                    }
                    return null;
                }
            }
        }

        public void Update(Event e)
        {
            using(SqlCommand cmd = _connection.CreateCommand())
            {
                cmd.CommandText = "update Event Id = @id, NomSpectacle = @nomS , Realisateur = @real, Description = @desc , Duree = dure , Image = @imag";
                cmd.Parameters.AddWithValue("id", e.Id);
                cmd.Parameters.AddWithValue("nomS", e.NomSpectacle);
                cmd.Parameters.AddWithValue("real", e.Realisateur);
                cmd.Parameters.AddWithValue("desc", e.Description);
                cmd.Parameters.AddWithValue("dure", e.Duree);
                cmd.Parameters.AddWithValue("imag", e.Image);

                cmd.ExecuteNonQuery();

            }
        }
    }
}
