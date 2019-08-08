namespace ModelsXLMforDB.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class BankContext : DbContext
    {
        public BankContext()
            : base("name=BankContext")
        {
        }

        public virtual DbSet<Amount> Amount { get; set; }
        public virtual DbSet<Batch> Batch { get; set; }
        public virtual DbSet<ContractDB> ContractDB { get; set; }
        public virtual DbSet<DataDB> DataDB { get; set; }
        public virtual DbSet<SubjectRole> SubjectRole { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Amount>()
                .HasMany(e => e.DataDB)
                .WithOptional(e => e.Amount)
                .HasForeignKey(e => e.ProlongationAmountId);

            modelBuilder.Entity<Amount>()
                .HasMany(e => e.DataDB1)
                .WithOptional(e => e.Amount1)
                .HasForeignKey(e => e.TotalAmountId);

            modelBuilder.Entity<Amount>()
                .HasMany(e => e.DataDB2)
                .WithOptional(e => e.Amount2)
                .HasForeignKey(e => e.TotalMonthlyPaymentId);

            modelBuilder.Entity<Batch>()
                .HasMany(e => e.ContractDB1)
                .WithOptional(e => e.Batch1)
                .HasForeignKey(e => e.ButchId);

            modelBuilder.Entity<ContractDB>()
                .HasMany(e => e.Batch)
                .WithOptional(e => e.ContractDB)
                .HasForeignKey(e => e.ContractId);

            modelBuilder.Entity<ContractDB>()
                .HasMany(e => e.SubjectRole)
                .WithOptional(e => e.ContractDB)
                .HasForeignKey(e => e.ContractId);

            modelBuilder.Entity<DataDB>()
                .HasMany(e => e.ContractDB)
                .WithOptional(e => e.DataDB)
                .HasForeignKey(e => e.ContractDataId);
        }
    }
}
