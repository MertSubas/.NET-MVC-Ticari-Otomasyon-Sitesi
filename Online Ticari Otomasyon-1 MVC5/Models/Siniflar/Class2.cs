using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Online_Ticari_Otomasyon_1_MVC5.Models.Siniflar
{
    public class Class2
    {
        [Key]
        public int id { get; set; }
        public string deneme { get; set; }
    }
}