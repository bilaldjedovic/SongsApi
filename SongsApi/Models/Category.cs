using System;
using System.Collections.Generic;

#nullable disable

namespace SongsApi.Models
{
    public partial class Category
    {
        public Category()
        {
            Songs = new HashSet<Song>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public virtual ICollection<Song> Songs { get; set; }
    }
}
