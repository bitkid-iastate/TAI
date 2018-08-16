using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TAI.Models;

namespace TAI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            messageModel message = new messageModel();
            return View(message);
        }

        public ActionResult AboutUs()
        {
            messageModel message = new messageModel();
            return View(message);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ContactUsResult(messageModel message)
        {
            string fromAddress = "contactus@thaiassociationiowa.com";
            string toAddress = "contactus@thaiassociationiowa.com";
            const string fromPassword = "thailand";
            string body = string.Format("From: {0}, {1}\n\n{2}", message.name, message.email, message.messageContent);
            var smtp = new System.Net.Mail.SmtpClient();
            {
                smtp.Host = "smtpout.secureserver.net";
                smtp.Port = 80;
                smtp.EnableSsl = false;
                smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                smtp.Credentials = new NetworkCredential(fromAddress, fromPassword);
                smtp.Timeout = 20000;
            }
            try
            {
                smtp.Send(fromAddress, toAddress, "Message for TAI", body);
            }
            catch (Exception e)
            {
                //ViewBag.Result = "There was an error sending your message. Please try again later.";
                ViewBag.Result = e.Message;
                return View();
            }
            ViewBag.Result = "Your message has been delivered! Thank you for contacting us. We will get back to you as soon as we can.";
            return View();
        }

    }
}