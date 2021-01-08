using ApiTOL.Models;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTOL.Utils
{
    public static class MapperClient
    {
        public static Client ClientToDal(this ClientApi api)
        {
            Client c = new Client
            {
                Id = api.Id,
                Nom = api.Nom,
                Prenom = api.Prenom,
                DateNaissance = api.DateNaissance,
                Sexe = api.Sexe,
                Adresse = api.Adresse,
                Email = api.Email,
                IsActive = api.IsActive,
                IsAdmin = api.IsAdmin,
                Password = api.Password,
                Image = api.Image
            };
            return c;
        }

        public static ClientApi ClientToApi(this Client c)
        {
            ClientApi api = new ClientApi
            {
                Id = c.Id,
                Nom = c.Nom,
                Prenom = c.Prenom,
                DateNaissance = c.DateNaissance,
                Sexe = c.Sexe,
                Adresse = c.Adresse,
                Email = c.Email,
                IsActive = c.IsActive,
                IsAdmin = c.IsAdmin,
                Password = c.Password,
                Image = c.Image
            };
            return api;
        }

        public static List<Client> LtD(this List<ClientApi> ca)
        {
            List<Client> cl = new List<Client>();
            foreach (ClientApi item in ca)
            {
                cl.Add(item.ClientToDal());
            }

            return cl;
        }

        public static List<ClientApi> Lta(this List<Client> cl)
        {
            List<ClientApi> ca = new List<ClientApi>();
            foreach (Client item in cl)
            {
                ca.Add(item.ClientToApi());
            }

            return ca;
        }
    }
}
