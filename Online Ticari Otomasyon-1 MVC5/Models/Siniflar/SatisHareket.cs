using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Online_Ticari_Otomasyon_1_MVC5.Models.Siniflar
{
    public class SatisHareket
    {
        [Key]
        public int SatisID { get; set; }
        //ürün
        //cari
        //personel
        public DateTime Tarih { get; set; }
        public int Adet { get; set; }
        public decimal Fiyat { get; set; }
        public decimal Toplamtutar { get; set; }

        public int Urunid { get; set; }
        public int Cariid { get; set; }
        public int Personelid { get; set; }

        public virtual Urun Urun { get; set; }
        public virtual Cariler Cariler{ get; set; }
        public virtual Personel Personel{ get; set; }


    }
}