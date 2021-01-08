using DAL.IRepo;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DAL.Services
{
    public class ServicesSalle : Irepo<Salles>
    {
        #region singleton

        private static ServicesSalle _instance;

        public static ServicesSalle Instance
        {
            get
            {
                _instance = _instance ?? new ServicesSalle();
                return _instance;
            }
        }

        #endregion

        #region SqlConnection

        private SqlConnection _connection;

        protected ServicesSalle()
        {
            _connection = new SqlConnection(@"Data Source=DESKTOP-DLBID37\SQL2019DEV;Initial Catalog=DbtOOL2;Integrated Security=True");
            _connection.Open();
        }

        #endregion

        public Salles GetById(int id)
        {
            using(SqlCommand cmd = _connection.CreateCommand())
            {
                cmd.CommandText = "select * from Salles where Id = @id";
                cmd.Parameters.AddWithValue("id", id);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Salles
                        {
                            Id = (int)reader["Id"],
                            AdresseSalle = (string)reader["AdresseSalle"],
                            Capacite = (int)reader["Capacite"],
                            NomSalle = (string)reader["NomSalle"],
                            ImageSalles = (string)reader["ImageSalles"],
                            HistoireSalle = (string)reader["HistoireSalle"]
                        }; 
                    }
                    return null;
                }
            }
        }

        public IEnumerable<Salles> GetAll()
        {
            using (SqlCommand cmd = _connection.CreateCommand())
            {
                cmd.CommandText = "select * from Salles ";

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    List<Salles> list = new List<Salles>();
                    while (reader.Read())
                    {
                        list.Add(new Salles
                        {
                            Id = (int)reader["Id"],
                            AdresseSalle = (string)reader["AdresseSalle"],
                            Capacite = (int)reader["Capacite"],
                            NomSalle = (string)reader["NomSalle"],
                            ImageSalles = (string)reader["ImageSalles"],
                            HistoireSalle = (string)reader["HistoireSalle"]
                        });
                    }
                    return list;
                }
            }
        }

        public int Create(Salles entity)
        {
            using (SqlCommand cmd = _connection.CreateCommand())
            {
                cmd.CommandText = "insert into salle output inserted.Id values (@AdresseSalle, @Capacite, @NomSalle, @ImageSalles, @HistoireSalle";
                cmd.Parameters.AddWithValue("AdresseSalle", entity.AdresseSalle);
                cmd.Parameters.AddWithValue("Capacite", entity.Capacite);
                cmd.Parameters.AddWithValue("NomSalle", entity.NomSalle);
                cmd.Parameters.AddWithValue("ImageSalles", entity.ImageSalles);
                cmd.Parameters.AddWithValue("HistoireSalle", entity.HistoireSalle);
                   
                return (int)cmd.ExecuteScalar();
            }
        }

        public void Delete(int id)
        {
            using (SqlCommand cmd = _connection.CreateCommand())
            {
                cmd.CommandText = "delete from salle where Id = @id";
                cmd.Parameters.AddWithValue("id", id);

                cmd.BeginExecuteNonQuery();
            }
        }

        public void Update(Salles entity)
        {
            using (SqlCommand cmd = _connection.CreateCommand())
            {
                cmd.CommandText = "update Salle AdresseSalle = @AdresseSalle, Capacite = @Capacite, NomSalle = @NomSalle, ImageSalles = @ImageSalles, HistoireSalle = @HistoireSalle";
                cmd.Parameters.AddWithValue("AdresseSalle", entity.AdresseSalle);
                cmd.Parameters.AddWithValue("Capacite", entity.Capacite);
                cmd.Parameters.AddWithValue("NomSalle", entity.NomSalle);
                cmd.Parameters.AddWithValue("ImageSalles", entity.ImageSalles);
                cmd.Parameters.AddWithValue("HistoireSalle", entity.HistoireSalle); 

                cmd.ExecuteNonQuery();
            }
        }
    }
}
