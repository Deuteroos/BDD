using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESC2020.Model
{
    public class ESCContext : DbContext
    {

        public ESCContext(DbContextOptions<ESCContext> options) : base(options) { }

        

        public DbSet<Users> User { get; set; }

        public DbSet<Election> Elections { get; set; }

        public DbSet<Message> Messages { get; set; }

        public DbSet<Notification> Notifications { get; set; }

        public DbSet<Opinion> Opinions { get; set; }

        public DbSet<Participant> Participants { get; set; }

        public DbSet<Phase> Phases { get; set; }

        public DbSet<TypeOpinion> TypeOpinions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>().ToTable("Users");
            modelBuilder.Entity<Election>().ToTable("Election");
            modelBuilder.Entity<Message>().ToTable("Message");
            modelBuilder.Entity<Notification>().ToTable("Notification");
            modelBuilder.Entity<Opinion>().ToTable("Opinion");
            modelBuilder.Entity<Participant>().ToTable("Participant");
            modelBuilder.Entity<Phase>().ToTable("Phase");
            modelBuilder.Entity<TypeOpinion>().ToTable("TypeOpinion");
            modelBuilder.Entity<Participant>()
                .HasKey(c => new { c.UserId, c.ElectionId });
        }
    }
}
