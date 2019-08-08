using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FFin.Models
{
    public class Batch
    {
        public string BatchIdentifier { get; set; }
        public Contract Contract { get; set; }
        public Batch() {
            Contract = new Contract();
        }
    }
    public class Contract
    {
        public string ContractCode { get; set; }
        public Data ContractData { get; set; }
        public List<SubjectRole> SubjectRole { get; set; }
        // public SubjectRole[] SubjectRole { get; set; }
        public Contract() {
             SubjectRole = new List<SubjectRole>();
           // SubjectRole = new SubjectRole[3];
            ContractData = new Data();
        }
    }
    public class Data
    {
        public string Branch { get; set; }

       
        public string PhaseOfContract { get; set; }

       
        public string ContractStatus { get; set; }

    
        public string TypeOfContract { get; set; }

       
        public string ContractSubtype { get; set; }

        public string OwnershipType { get; set; }

        public string PurposeOfFinancing { get; set; }

        public string CurrencyOfContract { get; set; }

        public Amount TotalAmount { get; set; }

        public string NextPaymentDate { get; set; }

        public Amount TotalMonthlyPayment{ get; set; }

        public int? PaymentPeriodicity { get; set; }

        public string StartDate { get; set; }

        public string RestructuringDate { get; set; }

        public string ExpectedEndDate { get; set; }

        public string RealEndDate { get; set; }

        public bool? NegativeStatusOfContract { get; set; }

        public Amount ProlongationAmount { get; set; }

        public string ProlongationDate { get; set; }

        public Data() {
            TotalAmount = new Amount();
            TotalMonthlyPayment = new Amount();
            ProlongationAmount = new Amount();
        }

    }
    public class SubjectRole
    {
        public string CustomerCode { get; set; }

        public string RoleOfCustomer { get; set; }

        public int GuarantorRelationship { get; set; }

        public string RealEndDate { get; set; }
    }
    public class Amount
    {

        public decimal Value { get; set; }
        public string Currency { get; set; }
    }
}