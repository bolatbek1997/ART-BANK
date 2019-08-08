namespace ModelsXLMforDB.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ContractDB")]
    public partial class ContractDB
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ContractDB()
        {
            Batch = new HashSet<Batch>();
            SubjectRole = new HashSet<SubjectRole>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string ContractCode { get; set; }

        public int? ContractDataId { get; set; }

        public int? ButchId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Batch> Batch { get; set; }

        public virtual Batch Batch1 { get; set; }

        public virtual DataDB DataDB { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SubjectRole> SubjectRole { get; set; }
    }
}
