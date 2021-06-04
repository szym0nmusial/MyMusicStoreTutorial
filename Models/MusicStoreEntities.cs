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
        public MusicStoreEntities(
           DbContextOptions options) : base(options)
        {}
        public DbSet<Album> Albums { get; set; }
        public DbSet<Genre> Genres { get; set; }

    }
}
