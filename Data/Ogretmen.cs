using System.ComponentModel.DataAnnotations;

namespace efcoreApp.Data
{
    public class Ogretmen
    {
        [Key]
        public int OgretmenId { get; set; }
        public string? Ad { get; set; }
        public string? Soyad { get; set; }
        public string? Email { get; set; }
        public string? Telefon { get; set; }
        public DateTime BaslamaTarihi { get; set; }

        // Burada da bir öğretmen brden fazla kurs verebilir demiş oluyoruz.
        public ICollection<Kurs> Kurslar { get; set; } = new List<Kurs>();

    }
}