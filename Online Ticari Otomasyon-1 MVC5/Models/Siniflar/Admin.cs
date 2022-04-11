using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Online_Ticari_Otomasyon_1_MVC5.Models.Siniflar
{
    public class Admin
    {
        [Key]
        public int AdminID { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(10)]
        public string KullaniciAD { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Sifre { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(1)]
        public string Yetki { get; set; }
    }
}