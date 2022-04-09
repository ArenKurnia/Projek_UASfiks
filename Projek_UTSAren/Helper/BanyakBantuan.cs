using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projek_UTSAren.Helper
{
    public class BanyakBantuan
    {
        public int BuatOTP()
        {
            Random mulai = new Random();

            int nilainya = mulai.Next(1000, 9999);
            return nilainya;
        }
    }
}
