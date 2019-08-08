namespace ModelsXLMforDB.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Amount")]
    public partial class Amount
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Amount()
        {
            DataDB = new HashSet<DataDB>();
            DataDB1 = new HashSet<DataDB>();
            DataDB2 = new HashSet<DataDB>();
        }

        public int Id { get; set; }
        [Column(TypeName = "decimal(16,0)")]
        public decimal Value { get; set; }

        [Required]
        [StringLength(10)]
        public string Currency { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DataDB> DataDB { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DataDB> DataDB1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DataDB> DataDB2 { get; set; }
    }
}
