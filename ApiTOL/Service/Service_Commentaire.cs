using ApiTOL.Models;
using ApiTOL.Utils;
using DAL.IRepo;
using DAL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTOL.Service
{
    public class Service_Commentaire : Irepo<CommentaireApi>
    {

        #region singleton 

        private static Service_Commentaire _instance;

        public static Service_Commentaire Instance
        {
            get
            {
                _instance = _instance ?? new Service_Commentaire();
                return _instance;
            }
        }

        protected Service_Commentaire()
        {

        }

        #endregion


        ServicesCommentaire service = ServicesCommentaire.Instance;

        public CommentaireApi GetById(int id)
        {
            return service.GetById(id).ToApi();
        }

        public IEnumerable<CommentaireApi> GetAll()
        {
            return service.GetAll().ToList().lta();
        }

        public int Create(CommentaireApi entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(CommentaireApi entity)
        {
            throw new NotImplementedException();
        }
    }
}
