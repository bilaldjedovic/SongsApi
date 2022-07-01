using System;
using System.Collections.Generic;

#nullable disable

namespace SongsApi.Models
{
    public partial class Song
    {
        public int SongId { get; set; }
        public string SongName { get; set; }
        public int CategoryId { get; set; }
        public string Author { get; set; }
        public int Rate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public string Link { get; set; }
        public int FavoriteId { get; set; }

        public virtual Category Category { get; set; }
        public virtual Favorite Favorite { get; set; }
    }
}
