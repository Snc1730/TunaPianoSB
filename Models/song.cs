namespace TunaPianoSB.Models
{
    public class Song
    {
        public int SongId { get; set; }
        public string? SongName { get; set;}
        public int ArtistId { get; set; }
        public Artist Artist { get; set; }
        public string? AlbumName { get; set; }
        public string? Length { get; set; }
        public ICollection<Genre> Genres { get; set; }
    }
}
