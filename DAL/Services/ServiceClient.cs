using DAL.IRepo;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DAL.Services
{
    public class ServiceClient : Irepo<Client>
    {
        #region singleton 
        private static ServiceClient _instance; 
        public static ServiceClient Instance
        {
            get
            {
                _instance = _instance ?? new ServiceClient();
                return _instance; 
            }
        }
        #endregion

        #region sqlConnection

        private SqlConnection _connection;
        protected ServiceClient()
        {
            _connection = new SqlConnection(@"Data Source=DESKTOP-DLBID37\SQL2019DEV;Initial Catalog=DbtOOL2;Integrated Security=True");
            _connection.Open();

        }
        #endregion


        #region get, getAll, getById

        public Client GetById(int id)
        {
            using (SqlCommand cmd = _connection.CreateCommand())
            {
                cmd.CommandText = "select * from Client where Id = @id";
                cmd.Parameters.AddWithValue("id", id);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Client
                        {
                            Id = (int)reader["Id"],
                            Nom = (string)reader["Nom"],
                            Prenom = (string)reader["Nom"],
                            DateNaissance = (DateTime)reader["DateNaissance"],
                            Sexe = (string)reader["Sexe"],
                            Adresse = (string)reader["Adresse"],
                            Email = (string)reader["Email"],
                            IsActive = (bool)reader["IsActive"],
                            IsAdmin = (bool)reader["IsAdmin"],
                            Password = (string)reader["Password"],
                            Image = (string)reader["Image"]
                        };
                    }
                    return null;
                }
            }
        }

        public IEnumerable<Client> GetAll()
        {
            using (SqlCommand cmd = _connection.CreateCommand())
            {
                cmd.CommandText = "Select *from Client";
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    List<Client> lc = new List<Client>();
                    while (reader.Read())
                    {
                        lc.Add(new Client
                        {
                            Id = (int)reader["Id"],
                            Nom = (string)reader["Nom"],
                            Prenom = (string)reader["Nom"],
                            DateNaissance = (DateTime)reader["DateNaissance"],
                            Sexe = (string)reader["Sexe"],
                            Adresse = (string)reader["Adresse"],
                            Email = (string)reader["Email"],
                            IsActive = (bool)reader["IsActive"],
                            IsAdmin = (bool)reader["IsAdmin"],
                            Password = (string)reader["Password"],
                            Image = (string)reader["Image"]
                        });
                    }
                    return lc;
                }
            }
        }


        #endregion

        #region create 

        //public int Create(Client client)
        //{
        //    using (SqlCommand cmd = _connection.CreateCommand())
        //    {
        //        cmd.CommandText = "insert into Client ouptut inserted.Id values(@Nom, @Prenom, @DateNaissance, @Sexe, @Adresse, @Email, @IsActive, @IsAdmin, @Password, @Image)";

        //        cmd.Parameters.AddWithValue("Nom", client.Nom);
        //        cmd.Parameters.AddWithValue("Prenom", client.Prenom);
        //        cmd.Parameters.AddWithValue("DateNaissance", client.DateNaissance);
        //        cmd.Parameters.AddWithValue("Sexe", client.Sexe);
        //        cmd.Parameters.AddWithValue("Adresse", client.Adresse);
        //        cmd.Parameters.AddWithValue("Email", client.Email);
        //        cmd.Parameters.AddWithValue("IsActive", 1);
        //        cmd.Parameters.AddWithValue("IsAdmin", 0);
        //        cmd.Parameters.AddWithValue("Password", client.Password);
        //        cmd.Parameters.AddWithValue("Image", client.Image);

        //        return (int)cmd.ExecuteScalar();
        //    }
        //}
        public int Create(Client client)
        {
            using (SqlCommand cmd = _connection.CreateCommand())
            {
                cmd.CommandText = "insert into client output inserted.Id values(@Nom, @Prenom, @DateNaissance, @Sexe, @Adresse, @Email, @IsActive, @IsAdmin, @Password, @Image ) ";
                // cmd.Parameters.AddWithValue("id", client.Id);
                cmd.Parameters.AddWithValue("Nom", client.Nom);
                cmd.Parameters.AddWithValue("Prenom", client.Prenom);
                cmd.Parameters.AddWithValue("DateNaissance", client.DateNaissance);
                cmd.Parameters.AddWithValue("Sexe", client.Sexe);
                cmd.Parameters.AddWithValue("Adresse", client.Adresse);
                cmd.Parameters.AddWithValue("Email", client.Email);
                cmd.Parameters.AddWithValue("IsActive", 1);
                cmd.Parameters.AddWithValue("IsAdmin", 0);
                cmd.Parameters.AddWithValue("Password", client.Password);
                cmd.Parameters.AddWithValue("Image", client.Image);

                return (int)cmd.ExecuteScalar();
            }
        }


        #endregion

        #region Delete
        public void Delete(int id)
        {
            using(SqlCommand cmd = _connection.CreateCommand())
            {
                cmd.CommandText = "delete from Client where Id = @id";
                cmd.Parameters.AddWithValue("id", id);
                cmd.ExecuteNonQuery();
            }
        }


        #endregion

        #region Update
        public void Update(Client client)
        {
            using(SqlCommand cmd = _connection.CreateCommand())
            {
                cmd.CommandText = "update client Nom = @Nom, Prenom = @Prenom, DateNaissance = @DateNaissance , Sexe = @Sexe , Adresse = @Adresse , Email = @Email, Image = @Image";

                cmd.Parameters.AddWithValue("Nom", client.Nom);
                cmd.Parameters.AddWithValue("Prenom", client.Prenom);
                cmd.Parameters.AddWithValue("DateNaissance", client.DateNaissance);
                cmd.Parameters.AddWithValue("Sexe", client.Sexe);
                cmd.Parameters.AddWithValue("Adresse", client.Adresse);
                cmd.Parameters.AddWithValue("Email", client.Email);
                cmd.Parameters.AddWithValue("Image", client.Image);

                cmd.ExecuteNonQuery();
            }
        }

        #endregion

    }
}
