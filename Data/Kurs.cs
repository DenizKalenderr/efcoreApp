namespace efcoreApp.Data
{
    public class Kurs
    {
        public int KursId { get; set; }
        public string? Baslik { get; set; }

        // OgretmenId i int verdik yani null olamaz bu durumda öğretmensiz bir kurs olamaz demiş oluyoruz. Zorunlu olmasın diyorsan ? koy
        public int? OgretmenId { get; set; }
        public Ogretmen Ogretmen { get; set; } = null!;

        public ICollection<KursKayit> KursKayitlari { get; set; } = new List<KursKayit>();
    }
}