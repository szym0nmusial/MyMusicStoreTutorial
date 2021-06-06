using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMusicStoreTutorial.Models
{
    public class MusicStoreEntities : DbContext
    {

        public DbSet<Album> Albums { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
           => optionsBuilder.UseNpgsql("Host=192.168.1.2;Database=MyMusicStoreDatabase;Username=postgres;Password=root");







        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Artist>()
        //        .HasOne<Album>(a => a.album)
        //        .WithOne(b => b.Artist)
        //        .HasForeignKey<Album>(c => c.ArtistId);


        //    modelBuilder.Entity<Album>()
        //        .HasOne<Genre>(a => a.Genre)
        //        .WithMany(b => b.Albums)
        //        .HasForeignKey(c => c.GenreId);


        //    modelBuilder.Entity<Album>()
        //        .HasOne<Cart>(a => a.cart)
        //        .WithOne(c => c.Album)
        //        .HasForeignKey<Cart>(d => d.AlbumId);
        //}
    }
}
