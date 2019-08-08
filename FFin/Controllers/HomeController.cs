
using FFin.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using System.Xml.Serialization;


using System.Timers;
using ModelsXLMforDB.Models;
using System.Data.Entity;

namespace FFin.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //System.Timers.Timer t = new System.Timers.Timer(TimeSpan.FromMinutes(10).TotalMilliseconds); // set the time (10 min in this case)
            //t.AutoReset = true;
            //t.Elapsed += new ElapsedEventHandler(getRetes);
            //t.Start();
            //Serialize ser = new Serialize();
            //var butch = ser.Deserializing(@"C:\Users\Bolatbek Tolepbergen\Desktop\BANK_20180115.xml");
            //if (butch != null) {
            //    ModelsXLMforDB.Models.Data data = new ModelsXLMforDB.Models.Data() {

            //    };
            //    ModelsXLMforDB.Models.Amount amount = new ModelsXLMforDB.Models.Amount();



            //    ModelsXLMforDB.Models.Batch butchDb = new ModelsXLMforDB.Models.Batch();

            //}
            //var db = new BankContext();
            ////var model0= db.Batch.Select(c=>new FFin.Models.Batch() {

            ////})
            //var batch = db.SubjectRole.ToArray();
           

            //var model = (from b in db.Batch
            //             join c in db.ContractDB on b.Id equals c.ButchId
            //             join d in db.DataDB on c.ContractDataId equals d.Id
            //             select new FFin.Models.Batch()
            //             {
            //                 BatchIdentifier = "Bank_" + b.Date.Year.ToString() + b.Date.Month.ToString() + b.Date.Day.ToString() + "_" + b.Count,
            //                 Contract = new Contract()
            //                 {
            //                     ContractCode = c.ContractCode,

            //                     SubjectRole = db.SubjectRole.Where(x => x.ContractId == c.Id).Select(x => new Models.SubjectRole()
            //                     {
            //                         CustomerCode = x.CustomerCode,
            //                         GuarantorRelationship = x.GuarantorRelationship,
            //                         RealEndDate = DbFunctions.TruncateTime(x.RealEndDate),
            //                         RoleOfCustomer = x.RoleOfCustomer
            //                     }).ToArray(),

            //                     ContractData = new Data()
            //                     {
            //                         RealEndDate = DbFunctions.TruncateTime(d.RealEndDate),
            //                         Branch = d.Branch,
            //                         ContractStatus = d.ContractStatus,
            //                         ContractSubtype = d.ContractSubtype,
            //                         CurrencyOfContract=d.CurrencyOfContract,
            //                         ExpectedEndDate=d.ExpectedEndDate,
            //                         NegativeStatusOfContract=d.NegativeStatusOfContract,
            //                         NextPaymentDate=d.NextPaymentDate,
            //                         OwnershipType=d.OwnershipType,
            //                         PaymentPeriodicity= d.PaymentPeriodicity,
            //                         PhaseOfContract=d.PhaseOfContract,
            //                        ProlongationDate=d.ProlongationDate,
            //                        PurposeOfFinancing=d.PurposeOfFinancing,
            //                        RestructuringDate=d.RestructuringDate,
            //                        StartDate=d.StartDate,
            //                        TypeOfContract=d.TypeOfContract,
            //                        TotalAmount=db.Amount.Where(l=>l.Id==d.TotalAmountId).Select(o=>new Models.Amount() {
            //                            Currency=o.Currency,
            //                            Value=o.Value
            //                        }).FirstOrDefault(),
            //                         ProlongationAmount = db.Amount.Where(l => l.Id == d.ProlongationAmountId).Select(o => new Models.Amount()
            //                         {
            //                             Currency = o.Currency,
            //                             Value = o.Value
            //                         }).FirstOrDefault(),
            //                         TotalMonthlyPayment = db.Amount.Where(l => l.Id == d.TotalMonthlyPaymentId).Select(o => new Models.Amount()
            //                         {
            //                             Currency = o.Currency,
            //                             Value = o.Value
            //                         }).FirstOrDefault(),
            //                     }
            //                 }
            //             }

            //           ).FirstOrDefault();

            return View();
        }


        public ActionResult About()
        {
           

            return View();
        }

        public ActionResult Contact()
        {
           
            return View();
        }
        public static string SendRequest(string Uri)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            System.Net.ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
            using (var client = new WebClient())
            {
                client.Proxy.Credentials = CredentialCache.DefaultCredentials;
                client.Headers.Add("Content-Type", "text/xml;charset=utf-8");
                string response = client.DownloadString(Uri);
                return response;
            }
        }
    }
}