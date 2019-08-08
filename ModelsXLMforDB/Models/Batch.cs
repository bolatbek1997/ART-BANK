namespace ModelsXLMforDB.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Batch")]
    public partial class Batch
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Batch()
        {
            ContractDB1 = new HashSet<ContractDB>();
        }

        public int Id { get; set; }

        public DateTime Date { get; set; }

        public int Count { get; set; }

        public int? ContractId { get; set; }

        public virtual ContractDB ContractDB { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ContractDB> ContractDB1 { get; set; }
    }
}
