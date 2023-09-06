using Microsoft.EntityFrameworkCore;
using TunaPianoSB.Models;
using System.Runtime.CompilerServices;


public class TunaPianoDBContext : DbContext
{

    public DbSet<Artist> Artists { get; set; }
    public DbSet<Song> Songs { get; set; }
    public DbSet<Song_Genre> Song_Genres { get; set; }
    public DbSet<Genre> Genres { get; set; }

    public TunaPianoDBContext(DbContextOptions<TunaPianoDBContext> context) : base(context)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Seed data for artists
        modelBuilder.Entity<Artist>().HasData(
            new Artist { ArtistId = 1, ArtistName = "Adele", Age = 33, Bio = "British singer-songwriter" },
            new Artist { ArtistId = 2, ArtistName = "Ed Sheeran", Age = 30, Bio = "Acclaimed pop artist" },
            new Artist { ArtistId = 3, ArtistName = "Metallica", Age = 40, Bio = "Legendary metal band" }
        );

        // Seed data for songs
        modelBuilder.Entity<Song>().HasData(
            new Song { SongId = 1, SongName = "Hello", ArtistId = 1, AlbumName = "25", Length = TimeSpan.FromMinutes(4) + TimeSpan.FromSeconds(55) },
            new Song { SongId = 2, SongName = "Shape of You", ArtistId = 2, AlbumName = "÷", Length = TimeSpan.FromMinutes(3) + TimeSpan.FromSeconds(54) },
            new Song { SongId = 3, SongName = "Enter Sandman", ArtistId = 3, AlbumName = "Metallica", Length = TimeSpan.FromMinutes(5) + TimeSpan.FromSeconds(29) }
        );

        // Seed data for genres
        modelBuilder.Entity<Genre>().HasData(
            new Genre { GenreId = 1, Description = "Pop" },
            new Genre { GenreId = 2, Description = "Rock" },
            new Genre { GenreId = 3, Description = "Metal" }
        );

        // Seed data for song-genre associations
        modelBuilder.Entity<Song_Genre>().HasData(
            new Song_Genre { Song_GenreId = 1, SongId = 1, GenreId = 1 },
            new Song_Genre { Song_GenreId = 2, SongId = 2, GenreId = 1 },
            new Song_Genre { Song_GenreId = 3, SongId = 3, GenreId = 2 }
        );
    }


}