namespace TunaPianoSB.Models
{
    public class Song_Genre
    {
        public int Song_GenreId { get; set; }
        public int SongId { get; set; }
        public int GenreId { get; set; }
        public List<Song> Songs { get; set; }
        public List<Genre> Genres { get; set; }
    }
}
