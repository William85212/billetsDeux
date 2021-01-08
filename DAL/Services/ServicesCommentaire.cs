using DAL.IRepo;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DAL.Services
{
    public class ServicesCommentaire : Irepo<Commentaire>
    {

        #region singleton 
        private static ServicesCommentaire _instance;

        public static ServicesCommentaire Instance
        {
            get
            {
                _instance = _instance ?? new ServicesCommentaire();
                return _instance;
            }
        }


        #endregion

        #region SqlConnection 

        private SqlConnection _connection;
        public ServicesCommentaire()
        {
            _connection = new SqlConnection(@"Data Source=DESKTOP-DLBID37\SQL2019DEV;Initial Catalog=DbtOOL2;Integrated Security=True");
            _connection.Open();
        }

        #endregion


        public Commentaire GetById(int id)
        {
            using(SqlCommand cmd = _connection.CreateCommand())
            {
                cmd.CommandText = "select Commentaire where Id = @id";
                cmd.Parameters.AddWithValue("id", id);
                using(SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Commentaire
                        {
                            Id = (int)reader["Id"],
                            Commentaires = (string)reader["Commentaire"],
                            Jaime = (int)reader["Jaime"],
                            JaimePas = (int)reader["JaimePas"],
                            IdClient = (int)reader["IdClient"],
                            IdEvent = (int)reader["IdEvent"]
                        };
                    }
                    else return null;
                }
            }
        }

        public IEnumerable<Commentaire> GetAll()
        {
            using(SqlCommand cmd = _connection.CreateCommand())
            {
                cmd.CommandText = "Select * from Commentaire";
                using(SqlDataReader reader = cmd.ExecuteReader())
                {
                    List<Commentaire> list = new List<Commentaire>();
                    while (reader.Read())
                    {
                        list.Add(new Commentaire
                        {
                            Id = (int)reader["Id"],
                            Commentaires = (string)reader["Commentaire"],
                            Jaime = (int)reader["Jaime"],
                            JaimePas = (int)reader["JaimePas"],
                            IdClient = (int)reader["IdClient"],
                            IdEvent = (int)reader["IdEvent"]
                        });
                    }
                    return list;
                }
            }
        }

        public int Create(Commentaire c)
        {
            using(SqlCommand cmd = _connection.CreateCommand())
            {
                cmd.CommandText = "insert into Commentaire output inserted.Id values(@commentaire, @jaime, @jaimePas, @idClient, @idEvent)";
                cmd.Parameters.AddWithValue("commentaire", c.Commentaires);
                cmd.Parameters.AddWithValue("jaime", c.Jaime);
                cmd.Parameters.AddWithValue("jaimePas", c.JaimePas);
                cmd.Parameters.AddWithValue("idClient", c.IdClient);
                cmd.Parameters.AddWithValue("idEvent", c.IdEvent);

                return (int)cmd.ExecuteScalar();
            }
        }

        #region delete

        public void Delete(int id)
        {
            using (SqlCommand cmd = _connection.CreateCommand())
            {
                cmd.CommandText = "delete from Commentaire where Id = @id";
                cmd.Parameters.AddWithValue("id", id);
                cmd.ExecuteNonQuery();
            }
        }

        #endregion

        #region Update

        public void Update(Commentaire client)
        {
            using(SqlCommand cmd = _connection.CreateCommand())
            {
                cmd.CommandText = "update Commentaire Id = @id , Commentaire = @commentaire , Jaime = @jaime, JaimePas = @jaimePas, IdClient = @idClient , IdEvent = @idEvent";
                cmd.Parameters.AddWithValue("id", client.Id);
                cmd.Parameters.AddWithValue("commentaire", client.Commentaires);
                cmd.Parameters.AddWithValue("jaime", client.Jaime);
                cmd.Parameters.AddWithValue("jaimePas", client.JaimePas);
                cmd.Parameters.AddWithValue("idClient", client.IdClient);
                cmd.Parameters.AddWithValue("idEvent", client.IdEvent);

                cmd.ExecuteNonQuery();
            }
        }
        #endregion
    }
}
