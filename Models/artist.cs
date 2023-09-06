namespace TunaPianoSB.Models
{
    public class Artist
    {
        public int ArtistId { get; set; }
        public string? ArtistName { get; set; }
        public int Age { get; set; }
        public string? Bio { get; set; }
        public List<Song> Songs { get; set; }
    }
}
