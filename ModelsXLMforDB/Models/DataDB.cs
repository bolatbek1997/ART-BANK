namespace ModelsXLMforDB.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DataDB")]
    public partial class DataDB
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DataDB()
        {
            ContractDB = new HashSet<ContractDB>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Branch { get; set; }

        [Required]
        [StringLength(50)]
        public string PhaseOfContract { get; set; }

        [Required]
        [StringLength(50)]
        public string ContractStatus { get; set; }

        [Required]
        [StringLength(50)]
        public string TypeOfContract { get; set; }

        [Required]
        [StringLength(50)]
        public string ContractSubtype { get; set; }

        [Required]
        [StringLength(50)]
        public string OwnershipType { get; set; }

        [Required]
        [StringLength(50)]
        public string PurposeOfFinancing { get; set; }

        [Required]
        [StringLength(10)]
        public string CurrencyOfContract { get; set; }

        public int? TotalAmountId { get; set; }

        public DateTime NextPaymentDate { get; set; }

        public int? TotalMonthlyPaymentId { get; set; }

        public int? PaymentPeriodicity { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime RestructuringDate { get; set; }

        public DateTime ExpectedEndDate { get; set; }

        public DateTime? RealEndDate { get; set; }

        public bool? NegativeStatusOfContract { get; set; }

        public int? ProlongationAmountId { get; set; }

        public DateTime? ProlongationDate { get; set; }

        public virtual Amount Amount { get; set; }

        public virtual Amount Amount1 { get; set; }

        public virtual Amount Amount2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ContractDB> ContractDB { get; set; }
    }
}
