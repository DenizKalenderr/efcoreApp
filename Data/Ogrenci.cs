using System.ComponentModel.DataAnnotations;

namespace efcoreApp.Data
{
    public class Ogrenci
    {
        [Key]
        public int OgrenciId { get; set; }
        public string? OgrenciAdi { get; set; }
        public string? OgrenciSoyad { get; set; }
        public string AdSoyad { 
            get
            {
                return this.OgrenciAdi + " " + this.OgrenciSoyad;
            }
            
            }
        public string? Email { get; set; }
        public string? Telefon { get; set; }
        //Öğrenci tarafından bakınca her öğrencinin katılacağı birden fazla kurs için liste tipinde. Öğrencinin kurs kayıt tablosundaki yabancı anahtarları toptan getirecek bir navigation property.
        public ICollection<KursKayit> KursKayitlari { get; set; } = new List<KursKayit>();
    }
}