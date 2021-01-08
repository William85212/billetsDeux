using DAL.IRepo;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Text;

namespace DAL.Services
{
    public class ServicesInfoReservation : Irepo<InfoEvent>
    {
        #region singleton 

        private static ServicesInfoReservation _instance;

        public static ServicesInfoReservation Instance
        {
            get
            {
                _instance = _instance ?? new ServicesInfoReservation();
                return _instance;
            }
        }

        #endregion

        #region SqlConnection

        private SqlConnection _connection;

        public ServicesInfoReservation()
        {
            _connection = new SqlConnection(@"Data Source = DESKTOP - DLBID37\SQL2019DEV; Initial Catalog = DataBaseTOL; Integrated Security = True");
            _connection.Open();
        }

        #endregion


        public InfoEvent GetById(int id)
        {
            using (SqlCommand cmd = _connection.CreateCommand())
            {
                cmd.CommandText = "select * from InfoEvent where Id = @id";
                cmd.Parameters.AddWithValue("id",id);

                using(SqlDataReader reader = cmd.ExecuteReader())
                {
                    if(reader.Read())
                    {
                        return new InfoEvent
                        {
                            Id = (int)reader["Id"],
                            DateEvent = (DateTime)reader["DateEvent"],
                            IdEvent = (int)reader["IdEvent"],
                            IdSalle = (int)reader["IdSalle"],
                            PlaceRestante = (int)reader["PlaceRestante"],
                            PrixPlace = (int)reader["PrixPlace"],
                        };
                    }
                    return null;
                }
            }
        }

        public IEnumerable<InfoEvent> GetAll()
        {
            using(SqlCommand cmd = _connection.CreateCommand())
            {
                cmd.CommandText = "select * from InfoEvent";

                using(SqlDataReader reader = cmd.ExecuteReader())
                {
                    List<InfoEvent> list = new List<InfoEvent>();
                    while (reader.Read())
                    {
                        list.Add(new InfoEvent
                        {
                            Id = (int)reader["Id"],
                            DateEvent = (DateTime)reader["DateEvent"],
                            IdEvent = (int)reader["IdEvent"],
                            IdSalle = (int)reader["IdSalle"],
                            PlaceRestante = (int)reader["PlaceRestante"],
                            PrixPlace = (int)reader["PrixPlace"],
                        });
                    }
                    return list;
                }
            }
        }

        public int Create(InfoEvent entity)
        {
            using (SqlCommand cmd = _connection.CreateCommand())
            {
                cmd.CommandText = "insert into InfoEvent output inserted.Id values (DateEvent = @DateEvent, IdEvent = @IdEvent , IdSalle = @IdSalle, PlaceRestante = @PlaceRestante, PrixPlace = @PrixPlace)";
                cmd.Parameters.AddWithValue("DateEvent", entity.DateEvent);
                cmd.Parameters.AddWithValue("IdEvent", entity.IdEvent);
                cmd.Parameters.AddWithValue("IdSalle",entity.IdSalle);
                cmd.Parameters.AddWithValue("PlaceRestante", entity.PlaceRestante);
                cmd.Parameters.AddWithValue("PrixPlace", entity.PrixPlace);

                return (int)cmd.ExecuteScalar();
            }
        }

        public void Delete(int id)
        {
            using(SqlCommand cmd = _connection.CreateCommand())
            {
                cmd.CommandText = "delete from InfoEvent where Id = @id";
                cmd.Parameters.AddWithValue("id",id);

                cmd.ExecuteNonQuery();
            }
        }

        public void Update(InfoEvent entity)
        {
            using (SqlCommand cmd = _connection.CreateCommand())
            {
                cmd.CommandText = "update client DateEvent = @DateEvent , IdEvent = @IdEvent, IdSalle = @IdSalle, PlaceRestante = @PlaceRestante , PrixPlace = @PrixPlace)";
                cmd.Parameters.AddWithValue("DateEvent", entity.DateEvent);
                cmd.Parameters.AddWithValue("IdEvent", entity.IdEvent);
                cmd.Parameters.AddWithValue("IdSalle", entity.IdSalle);
                cmd.Parameters.AddWithValue("PlaceRestante", entity.PlaceRestante);
                cmd.Parameters.AddWithValue("PrixPlace", entity.PrixPlace);

                cmd.ExecuteNonQuery();
            }
        }

    }
}
