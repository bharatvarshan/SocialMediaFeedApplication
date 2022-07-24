using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SocialMediaApplication.Models
{
    public partial class socialfeeddbContext : DbContext
    {
        public socialfeeddbContext()
        {
        }

        public socialfeeddbContext(DbContextOptions<socialfeeddbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Comment> Comments { get; set; } = null!;
        public virtual DbSet<Feed> Feeds { get; set; } = null!;
        public virtual DbSet<Like> Likes { get; set; } = null!;
        public virtual DbSet<Tag> Tags { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;port=3306;user=root;password=root;database=socialfeeddb", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.29-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.ToTable("comments");

                entity.HasIndex(e => e.CommentedBy, "CommentedBy_idx");

                entity.HasIndex(e => e.CommentedFeed, "CommentedFeed_idx");

                entity.Property(e => e.Comment1).HasColumnName("Comment");

                entity.HasOne(d => d.CommentedByNavigation)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.CommentedBy)
                    .HasConstraintName("CommentedBy");

                entity.HasOne(d => d.CommentedFeedNavigation)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.CommentedFeed)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("CommentedFeed");
            });

            modelBuilder.Entity<Feed>(entity =>
            {
                entity.ToTable("feeds");

                entity.HasIndex(e => e.PostedBy, "PostedBy_idx");
            });

            modelBuilder.Entity<Like>(entity =>
            {
                entity.ToTable("likes");

                entity.HasIndex(e => e.FeedLiked, "FeedLiked_idx");

                entity.HasIndex(e => e.UserLiked, "UserLiked_idx");

                entity.Property(e => e.LikeId).ValueGeneratedNever();

                entity.HasOne(d => d.FeedLikedNavigation)
                    .WithMany(p => p.Likes)
                    .HasForeignKey(d => d.FeedLiked)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FeedLiked");

                entity.HasOne(d => d.UserLikedNavigation)
                    .WithMany(p => p.Likes)
                    .HasForeignKey(d => d.UserLiked)
                    .HasConstraintName("UserLiked");
            });

            modelBuilder.Entity<Tag>(entity =>
            {
                entity.ToTable("tags");

                entity.HasIndex(e => e.FeedTagged, "FeedId_idx");

                entity.HasIndex(e => e.UserTagged, "UserTagged_idx");

                entity.Property(e => e.TagId).ValueGeneratedNever();

                entity.HasOne(d => d.FeedTaggedNavigation)
                    .WithMany(p => p.Tags)
                    .HasForeignKey(d => d.FeedTagged)
                    .HasConstraintName("FeedTagged");

                entity.HasOne(d => d.UserTaggedNavigation)
                    .WithMany(p => p.Tags)
                    .HasForeignKey(d => d.UserTagged)
                    .HasConstraintName("UserTagged");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.Property(e => e.IsAdmin).HasColumnName("isAdmin");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
