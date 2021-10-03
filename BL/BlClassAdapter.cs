using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
namespace BL
{
    class BlClassAdapter : IBL
    {        
        IDAL dal;
        public BlClassAdapter()
        {           
            dal = FactoryDal.getDal();
        }

        public void InsertValue(int item)
        {
            if (item > 400 || item < 0)
                throw new ArgumentOutOfRangeException("BL Exception: wrong value");

            try
            {
                dal.InsertValue(item);
            }
            catch (Exception)
            {
                throw; // the original exception is thrown
            }
        }
    }
}
