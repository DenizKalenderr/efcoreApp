using System.ComponentModel.DataAnnotations;

namespace efcoreApp.Data
{
    public class Ogrenci
    {
        [Key]
        public int OgrenciId { get; set; }
        public string? OgrenciAdi { get; set; }
        public string? OgrenciSoyad { get; set; }
        public string? Email { get; set; }
        public string? Telefon { get; set; }
    }
}