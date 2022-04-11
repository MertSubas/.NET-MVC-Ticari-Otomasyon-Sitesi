using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Online_Ticari_Otomasyon_1_MVC5.Models.Siniflar
{
    public class Kategori
    {
        [Key]
        public int KategoriID { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public String KategoriAD { get; set; }

        public ICollection<Urun> Uruns { get; set; }


    }
}