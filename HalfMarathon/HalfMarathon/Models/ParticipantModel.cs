namespace HalfMarathon.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ParticipantModel : DbContext
    {
        public ParticipantModel()
            : base("name=HalfMModel")
        {
        }

        public virtual DbSet<Participant> Participant { get; set; }
        public virtual DbSet<Result> Result { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Participant>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<Participant>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<Participant>()
                .Property(e => e.Club)
                .IsUnicode(false);

            modelBuilder.Entity<Participant>()
                .HasMany(e => e.Result)
                .WithRequired(e => e.Participant)
                .HasForeignKey(e => e.Participant_Id)
                .WillCascadeOnDelete(false);
        }
    }
}
