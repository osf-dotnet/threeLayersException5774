using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL
{
    public class FactoryBl
    {
        public static IBL getBl()
        {
            return new BlClassAdapter();
        }
    }
}
