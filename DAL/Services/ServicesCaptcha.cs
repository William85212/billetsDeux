using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DAL.Services
{
    public class ServicesCaptcha
    {

        #region singleton

        private static ServicesCaptcha _instance;

        public static ServicesCaptcha Instance
        {
            get
            {
                 _instance = _instance ?? new ServicesCaptcha();
                return _instance;
            }
        }

        #endregion

        #region SqlConnection

        private SqlConnection _connection;

        public ServicesCaptcha()
        {
            _connection = new SqlConnection(@"Data Source=DESKTOP-DLBID37\SQL2019DEV;Initial Catalog=DbtOOL2;Integrated Security=True");
            _connection.Open();
        }

        #endregion




    }
}
