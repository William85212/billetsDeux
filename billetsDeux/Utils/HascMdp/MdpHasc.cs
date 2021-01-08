using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace billetsDeux.Utils.HascMdp
{
    public class MdpHasc : IMdpHasc
    {
        public string Hasc(string mdp)
        {
            UnicodeEncoding unicodeEncoding = new UnicodeEncoding();
            HashAlgorithm hashAlgorithm = new SHA512Managed();
            byte[] result = hashAlgorithm.ComputeHash(unicodeEncoding.GetBytes(mdp));
            string mdpH = Convert.ToBase64String(result);

            return mdpH;
        }
    }
}
