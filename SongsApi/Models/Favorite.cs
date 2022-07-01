using System;
using System.Collections.Generic;

#nullable disable

namespace SongsApi.Models
{
    public partial class Favorite
    {
        public Favorite()
        {
            Songs = new HashSet<Song>();
        }

        public int FavoriteId { get; set; }
        public string FavoriteName { get; set; }

        public virtual ICollection<Song> Songs { get; set; }
    }
}
