using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_Sales.Controllers
{
    public class DistrictModel
    {
        public int ID { get; set; } 
        public string Name { get; set; }
        public int ProvinceID { set; get; }
    }
}