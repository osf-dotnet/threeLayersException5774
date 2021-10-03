using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class FactoryDal
    {
        public static IDAL getDal()
        {
            return new Class_dal_save_at_arr();
        }

    }
}
