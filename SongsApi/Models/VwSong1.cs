using System;
using System.Collections.Generic;

#nullable disable

namespace SongsApi.Models
{
    public partial class VwSong1
    {
        public int SongId { get; set; }
        public string SongName { get; set; }
        public string CategoryName { get; set; }
        public string Author { get; set; }
        public int Rate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public string Link { get; set; }
        public string Favorite { get; set; }
    }
}
