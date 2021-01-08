using ApiTOL.Models;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ApiTOL.Utils
{
    public  static class MapperCommentaire
    {
        public static Commentaire toD(this 
            CommentaireApi api)
        {
            Commentaire c = new Commentaire
            {
                Id = api.Id,
                Commentaires = api.Commentaires,
                IdClient = api.IdClient,
                IdEvent = api.IdEvent,
                Jaime = api.Jaime,
                JaimePas = api.JaimePas
            };
            return c;
        }

        public static CommentaireApi ToApi(this Commentaire d)
        {
            CommentaireApi api = new CommentaireApi
            {
                Id = d.Id,
                Commentaires = d.Commentaires,
                IdClient = d.IdClient,
                IdEvent = d.IdEvent,
                Jaime = d.Jaime,
                JaimePas = d.JaimePas
            };
            return api;
        }

        public static List<Commentaire> ltD(this List<CommentaireApi> a)
        {
            List<Commentaire> l = new List<Commentaire>();
            foreach (CommentaireApi item in a)
            {
                l.Add(item.toD());
            }
            return l;
        }

        public static List<CommentaireApi> lta(this List<Commentaire> c)
        {
            List<CommentaireApi> a = new List<CommentaireApi>();
            foreach (Commentaire item in c)
            {
                a.Add(item.ToApi());
            }
            return a;
        }
    }
}
