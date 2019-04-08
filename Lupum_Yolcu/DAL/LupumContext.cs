using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Lupum_Yolcu.DAL
{
    public class LupumContext:DbContext
    {
        public LupumContext():base("LupumStr")
        {

        }
    }
}