using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace TweetCake.DAL.Entities
{
    public class TweetCakeDbContext : DbContext
    {
        public TweetCakeDbContext()
        {

        }
        public TweetCakeDbContext(DbContextOptions<TweetCakeDbContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserFriend>().HasOne(user => user.User).WithMany(x => x.UserFriends)
                .HasForeignKey(x => x.UserId);

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=TweetCake;Integrated Security=True");
        }
        public DbSet<Tweet> Tweets { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Mention> Mentions { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<UserFriend> UserFriends { get; set; }
    }
}
