using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace SongsApi.Models
{
    public partial class SongsAppContext : DbContext
    {
        public SongsAppContext()
        {
        }

        public SongsAppContext(DbContextOptions<SongsAppContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Favorite> Favorites { get; set; }
        public virtual DbSet<Song> Songs { get; set; }
        public virtual DbSet<VwSong> VwSongs { get; set; }
        public virtual DbSet<VwSong1> VwSongs1 { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS01;Database=SongsApp;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.Property(e => e.CategoryId).HasColumnName("categoryId");

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("categoryName");
            });

            modelBuilder.Entity<Favorite>(entity =>
            {
                entity.ToTable("Favorite");

                entity.Property(e => e.FavoriteId).HasColumnName("favoriteId");

                entity.Property(e => e.FavoriteName)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("favoriteName");
            });

            modelBuilder.Entity<Song>(entity =>
            {
                entity.ToTable("Song");

                entity.Property(e => e.SongId).HasColumnName("songId");

                entity.Property(e => e.Author)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("author");

                entity.Property(e => e.CategoryId).HasColumnName("categoryId");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("date")
                    .HasColumnName("createdAt")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FavoriteId).HasColumnName("favoriteId");

                entity.Property(e => e.Link)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("link");

                entity.Property(e => e.ModifiedAt)
                    .HasColumnType("date")
                    .HasColumnName("modifiedAt")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Rate).HasColumnName("rate");

                entity.Property(e => e.SongName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("songName");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Songs)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Song__categoryId__3A81B327");

                entity.HasOne(d => d.Favorite)
                    .WithMany(p => p.Songs)
                    .HasForeignKey(d => d.FavoriteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Song__favoriteId__3D5E1FD2");
            });

            modelBuilder.Entity<VwSong>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vwSong");

                entity.Property(e => e.Author)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("author");

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("categoryName");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("date")
                    .HasColumnName("createdAt");

                entity.Property(e => e.FavoriteName)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("favoriteName");

                entity.Property(e => e.Link)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("link");

                entity.Property(e => e.ModifiedAt)
                    .HasColumnType("date")
                    .HasColumnName("modifiedAt");

                entity.Property(e => e.Rate).HasColumnName("rate");

                entity.Property(e => e.SongId).HasColumnName("songId");

                entity.Property(e => e.SongName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("songName");
            });

            modelBuilder.Entity<VwSong1>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vwSongs");

                entity.Property(e => e.Author)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("author");

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("categoryName");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("date")
                    .HasColumnName("createdAt");

                entity.Property(e => e.Favorite)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("favorite");

                entity.Property(e => e.Link)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("link");

                entity.Property(e => e.ModifiedAt)
                    .HasColumnType("date")
                    .HasColumnName("modifiedAt");

                entity.Property(e => e.Rate).HasColumnName("rate");

                entity.Property(e => e.SongId).HasColumnName("songId");

                entity.Property(e => e.SongName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("songName");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
