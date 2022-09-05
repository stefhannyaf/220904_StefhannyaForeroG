using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _220904_StefhannyaForeroG.Models
{
    public class Institute
    {
        public int Id { get; set; }
        public string Institute_name { get; set; }
        public string Institute_address { get; set; }
        public int Students_Number { get; set; }
        public int Time_service { get; set; }
        public int Price { get; set; }

    }
}