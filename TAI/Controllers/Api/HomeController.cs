using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using TAI.Models;

namespace TAI.Controllers.Api
{
    public class HomeController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        //[HttpPost]
        [ValidateAntiForgeryToken]
        public void MessageUs([FromBody]messageModel message)
        {
            string fromAddress = "contactus@thaiassociationiowa.com";
            string toAddress = "grindlockfirm@gmail.com";
            const string fromPassword = "thailand";
            string body = string.Format("From: {0}, Email: {1}\n\n{2}", message.name, message.email, message.messageContent);
            var smtp = new System.Net.Mail.SmtpClient();
            {
                smtp.Host = "relay-hosting.secureserver.net";
                smtp.Port = 25;
                smtp.EnableSsl = false;
                smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                smtp.Credentials = new NetworkCredential(fromAddress, fromPassword);
                smtp.Timeout = 20000;
            }
            try
            {
            smtp.Send(fromAddress, toAddress, "Message from TAI", body);
            }
            catch (Exception e)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}