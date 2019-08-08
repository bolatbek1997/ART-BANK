using FFin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FFin.Controllers
{
    public class RublRateController : ApiController
    {
        public string Get(string id)
        {
            string retStr = "1 RUB-";
            var ser = new Serialize();
            ValCurs quiz = ser.DeSerialize<ValCurs>(SendRequest("http://www.cbr.ru/scripts/XML_daily.asp"));
            if (quiz.Valute.Any(x => x.CharCode == id.ToUpper()))
            {
                var item = Convert.ToDouble(quiz.Valute.FirstOrDefault(x => x.CharCode == id.ToUpper()).Value);
                var rate = Math.Round(1 / item, 4);
                retStr += rate.ToString() + " " +
                    id;
                return retStr;
            }
            else
            {
                return "Валюта " + id.ToUpper() + " с таким кодом не найден в";
            }

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
