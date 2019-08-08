using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using ModelsXLMforDB.Models;

namespace FFin.Models
{
    public class MethodForSoap
    {
        public Batch ReturnBatch() {
            var batch = new Batch();
            //x => DbFunctions.TruncateTime(x.Date) == DbFunctions.TruncateTime(DateTime.Now))
            var db = new BankContext();
            if (db.Batch.Any(x=>x.Date.Day==DateTime.Now.Day && x.Date.Month== DateTime.Now.Month && x.Date.Year == DateTime.Now.Year))
            {
                var batchMo = db.Batch.FirstOrDefault(x => x.Date.Day == DateTime.Now.Day && x.Date.Month == DateTime.Now.Month && x.Date.Year == DateTime.Now.Year);
                var model = (from b in db.Batch
                             join c in db.ContractDB on b.ContractId equals c.Id
                             join d in db.DataDB on c.ContractDataId equals d.Id
                             where b.Id==batchMo.Id
                             select new FFin.Models.Batch()
                             {
                                 BatchIdentifier = "Bank_" + b.Date.Year.ToString() + b.Date.Month.ToString() + b.Date.Day.ToString() + "_" + b.Count,
                                 Contract = new Contract()
                                 {
                                     ContractCode = c.ContractCode,

                                     SubjectRole = db.SubjectRole.Where(x => x.ContractId == c.Id).Select(x => new Models.SubjectRole()
                                     {
                                         CustomerCode = x.CustomerCode,
                                         GuarantorRelationship = x.GuarantorRelationship,
                                         RealEndDate = x.RealEndDate != null ? x.RealEndDate.Value.Year.ToString() + "-" + x.RealEndDate.Value.Month.ToString() + "-" + x.RealEndDate.Value.Day.ToString() : null,
                                         RoleOfCustomer = x.RoleOfCustomer
                                     }).ToList(),

                                     ContractData = new Data()
                                     {
                                         RealEndDate = d.RealEndDate != null ? d.RealEndDate.Value.Year.ToString() + "-" + d.RealEndDate.Value.Month.ToString() + "-" + d.RealEndDate.Value.Day.ToString() : null,
                                         Branch = d.Branch,
                                         ContractStatus = d.ContractStatus,
                                         ContractSubtype = d.ContractSubtype,
                                         CurrencyOfContract = d.CurrencyOfContract,
                                         ExpectedEndDate = d.ExpectedEndDate != null ? d.ExpectedEndDate.Year.ToString() + "-" + d.ExpectedEndDate.Month.ToString() + "-" + d.ExpectedEndDate.Day.ToString() : null,
                                         NegativeStatusOfContract = d.NegativeStatusOfContract,
                                         NextPaymentDate = d.NextPaymentDate != null ? d.NextPaymentDate.Year.ToString() + "-" + d.NextPaymentDate.Month.ToString() + "-" + d.NextPaymentDate.Day.ToString() : null,
                                         OwnershipType = d.OwnershipType,
                                         PaymentPeriodicity = d.PaymentPeriodicity,
                                         PhaseOfContract = d.PhaseOfContract,
                                         ProlongationDate = d.ProlongationDate != null ? d.ProlongationDate.Value.Year.ToString() + "-" + d.ProlongationDate.Value.Month.ToString() + "-" + d.ProlongationDate.Value.Day.ToString() : null,
                                         PurposeOfFinancing = d.PurposeOfFinancing,
                                         RestructuringDate = d.RestructuringDate != null ? d.RestructuringDate.Year.ToString() + "-" + d.RestructuringDate.Month.ToString() + "-" + d.RestructuringDate.Day.ToString() : null,
                                         StartDate = d.StartDate != null ? d.StartDate.Year.ToString() + "-" + d.StartDate.Month.ToString() + "-" + d.StartDate.Day.ToString() : null,
                                         TypeOfContract = d.TypeOfContract,
                                         TotalAmount = db.Amount.Where(l => l.Id == d.TotalAmountId).Select(o => new Models.Amount()
                                         {
                                             Currency = o.Currency,
                                             Value = o.Value
                                         }).FirstOrDefault(),
                                         ProlongationAmount = db.Amount.Where(l => l.Id == d.ProlongationAmountId).Select(o => new Models.Amount()
                                         {
                                             Currency = o.Currency,
                                             Value = o.Value
                                         }).FirstOrDefault(),
                                         TotalMonthlyPayment = db.Amount.Where(l => l.Id == d.TotalMonthlyPaymentId).Select(o => new Models.Amount()
                                         {
                                             Currency = o.Currency,
                                             Value = o.Value
                                         }).FirstOrDefault(),
                                     }
                                 }
                             }

                    ).FirstOrDefault();

               
              
                batchMo.Count += 1;
                db.Entry(batchMo).State = EntityState.Modified;
              
                try
                {
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    return batch = null;
                    throw ex;
                }
                return model;
            }
            else {
                var batchMo = db.Batch.FirstOrDefault();
                batchMo.Date = DateTime.Now;
                batchMo.Count =1;
                db.Batch.Add(batchMo);
                try
                {
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    return batch = null;
                    throw ex;
                }
              
                var model = (from b in db.Batch
                             join c in db.ContractDB on b.ContractId equals c.Id
                             join d in db.DataDB on c.ContractDataId equals d.Id
                             where b.Id==batchMo.Id
                             select new FFin.Models.Batch()
                             {
                                 BatchIdentifier = "Bank_" + b.Date.Year.ToString() + b.Date.Month.ToString() + b.Date.Day.ToString() + "_" + b.Count,
                                 Contract = new Contract()
                                 {
                                     ContractCode = c.ContractCode,

                                     SubjectRole = db.SubjectRole.Where(x => x.ContractId == c.Id).Select(x => new Models.SubjectRole()
                                     {
                                         CustomerCode = x.CustomerCode,
                                         GuarantorRelationship = x.GuarantorRelationship,
                                         RealEndDate = x.RealEndDate != null ? x.RealEndDate.Value.Year.ToString() + "-" + x.RealEndDate.Value.Month.ToString() + "-" + x.RealEndDate.Value.Day.ToString() : null,
                                         RoleOfCustomer = x.RoleOfCustomer
                                     }).ToList(),

                                     ContractData = new Data()
                                     {
                                         RealEndDate = d.RealEndDate != null ? d.RealEndDate.Value.Year.ToString() + "-" + d.RealEndDate.Value.Month.ToString() + "-" + d.RealEndDate.Value.Day.ToString() : null,
                                         Branch = d.Branch,
                                         ContractStatus = d.ContractStatus,
                                         ContractSubtype = d.ContractSubtype,
                                         CurrencyOfContract = d.CurrencyOfContract,
                                         ExpectedEndDate = d.ExpectedEndDate != null ? d.ExpectedEndDate.Year.ToString() + "-" + d.ExpectedEndDate.Month.ToString() + "-" + d.ExpectedEndDate.Day.ToString() : null,
                                         NegativeStatusOfContract = d.NegativeStatusOfContract,
                                         NextPaymentDate = d.NextPaymentDate != null ? d.NextPaymentDate.Year.ToString() + "-" + d.NextPaymentDate.Month.ToString() + "-" + d.NextPaymentDate.Day.ToString() : null,
                                         OwnershipType = d.OwnershipType,
                                         PaymentPeriodicity = d.PaymentPeriodicity!=null? d.PaymentPeriodicity:null,
                                         PhaseOfContract = d.PhaseOfContract,
                                         ProlongationDate = d.ProlongationDate != null ? d.ProlongationDate.Value.Year.ToString() + "-" + d.ProlongationDate.Value.Month.ToString() + "-" + d.ProlongationDate.Value.Day.ToString() : null,
                                         PurposeOfFinancing = d.PurposeOfFinancing,
                                         RestructuringDate = d.RestructuringDate != null ? d.RestructuringDate.Year.ToString() + "-" + d.RestructuringDate.Month.ToString() + "-" + d.RestructuringDate.Day.ToString() : null,
                                         StartDate = d.StartDate != null ? d.StartDate.Year.ToString() + "-" + d.StartDate.Month.ToString() + "-" + d.StartDate.Day.ToString() : null,
                                         TypeOfContract = d.TypeOfContract,
                                         TotalAmount = db.Amount.Where(l => l.Id == d.TotalAmountId).Select(o => new Models.Amount()
                                         {
                                             Currency = o.Currency,
                                             Value = o.Value
                                         }).FirstOrDefault(),
                                         ProlongationAmount = db.Amount.Where(l => l.Id == d.ProlongationAmountId).Select(o => new Models.Amount()
                                         {
                                             Currency = o.Currency,
                                             Value = o.Value
                                         }).FirstOrDefault(),
                                         TotalMonthlyPayment = db.Amount.Where(l => l.Id == d.TotalMonthlyPaymentId).Select(o => new Models.Amount()
                                         {
                                             Currency = o.Currency,
                                             Value = o.Value
                                         }).FirstOrDefault(),
                                     }
                                 }
                             }

                   ).FirstOrDefault();
                //   int count=db.SubjectRole.Count(x => x.ContractId ==model.Contract.)
                return model;
            }
          
            //try
            //{
            //    var model = (from b in db.Batch
            //                 join c in db.ContractDB on b.Id equals c.ButchId
            //                 join d in db.DataDB on c.ContractDataId equals d.Id
            //                 select new FFin.Models.Batch()
            //                 {
            //                     BatchIdentifier = "Bank_" + b.Date.Year.ToString() + b.Date.Month.ToString() + b.Date.Day.ToString() + "_" + b.Count,
            //                     Contract = new Contract()
            //                     {
            //                         ContractCode = c.ContractCode,

            //                         SubjectRole = db.SubjectRole.Where(x => x.ContractId == c.Id).Select(x => new Models.SubjectRole()
            //                         {
            //                             CustomerCode = x.CustomerCode,
            //                             GuarantorRelationship = x.GuarantorRelationship,
            //                             RealEndDate = d.RealEndDate != null ? d.RealEndDate.Value.ToString("yyyy-MM-dd") : null,
            //                             RoleOfCustomer = x.RoleOfCustomer
            //                         }).ToList(),

            //                         ContractData = new Data()
            //                         {
            //                             RealEndDate = d.RealEndDate != null ? d.RealEndDate.Value.ToString("yyyy-MM-dd") : null,
            //                             Branch = d.Branch,
            //                             ContractStatus = d.ContractStatus,
            //                             ContractSubtype = d.ContractSubtype,
            //                             CurrencyOfContract = d.CurrencyOfContract,
            //                             ExpectedEndDate = d.ExpectedEndDate.ToString("yyyy-MM-dd"),
            //                             NegativeStatusOfContract = d.NegativeStatusOfContract,
            //                             NextPaymentDate = d.NextPaymentDate.ToString("yyyy-MM-dd"),
            //                             OwnershipType = d.OwnershipType,
            //                             PaymentPeriodicity = d.PaymentPeriodicity,
            //                             PhaseOfContract = d.PhaseOfContract,
            //                             ProlongationDate = d.ProlongationDate!=null? d.ProlongationDate.Value.ToString("yyyy-MM-dd"):null,
            //                             PurposeOfFinancing = d.PurposeOfFinancing,
            //                             RestructuringDate = d.RestructuringDate != null ? d.RestructuringDate.ToString("yyyy-MM-dd") : null,
            //                             StartDate = d.StartDate.ToString(),
            //                             TypeOfContract = d.TypeOfContract,
            //                             TotalAmount = db.Amount.Where(l => l.Id == d.TotalAmountId).Select(o => new Models.Amount()
            //                             {
            //                                 Currency = o.Currency,
            //                                 Value = o.Value
            //                             }).FirstOrDefault(),
            //                             ProlongationAmount = db.Amount.Where(l => l.Id == d.ProlongationAmountId).Select(o => new Models.Amount()
            //                             {
            //                                 Currency = o.Currency,
            //                                 Value = o.Value
            //                             }).FirstOrDefault(),
            //                             TotalMonthlyPayment = db.Amount.Where(l => l.Id == d.TotalMonthlyPaymentId).Select(o => new Models.Amount()
            //                             {
            //                                 Currency = o.Currency,
            //                                 Value = o.Value
            //                             }).FirstOrDefault(),
            //                         }
            //                     }
            //                 }

            //           ).FirstOrDefault();
            // //   int count=db.SubjectRole.Count(x => x.ContractId ==model.Contract.)
            //    return model;

            //}
            //catch (Exception ex)
            //{
            //    return batch;
            //    throw ex;
            //}

           

            
        }
    }
}