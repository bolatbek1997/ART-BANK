namespace ModelsXLMforDB.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SubjectRole")]
    public partial class SubjectRole
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string CustomerCode { get; set; }

        [Required]
        [StringLength(50)]
        public string RoleOfCustomer { get; set; }

        public int GuarantorRelationship { get; set; }

        public int? ContractId { get; set; }

        public DateTime? RealEndDate { get; set; }

        public virtual ContractDB ContractDB { get; set; }
    }
}
