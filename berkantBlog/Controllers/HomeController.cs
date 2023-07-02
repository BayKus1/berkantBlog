using berkantBlog.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net.Mail;

namespace berkantBlog.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string name, string email, string subject, string message)
        {
			try
			{

				// Configure SMTP settings for sending email
				SmtpClient smtpClient = new SmtpClient("smtp.office365.com", 587);
				smtpClient.EnableSsl = true;
				smtpClient.UseDefaultCredentials = false; 
				smtpClient.Credentials = new System.Net.NetworkCredential("berkant_yigit@outlook.com", "mail sifreniz"); //sent message

				// Compose the mail message
				MailMessage mailMessage = new MailMessage();
				mailMessage.From = new MailAddress("berkant_yigit@outlook.com");
				mailMessage.To.Add("berkant_yigit@outlook.com"); //take message
				mailMessage.Subject = subject;
				mailMessage.Body = message;

				// Send mail message to SMTP server
				smtpClient.Send(mailMessage);

			
				// Redirect user to successfully submitted page
				return RedirectToAction("Gonderildi");

			}
			catch (Exception ex)
			{
				// Redirect user to error page
				return RedirectToAction("ErrorMessage");
			}
			
		}


        public ActionResult Gonderildi()
        {
            return View("Message");
        }

        public ActionResult ErrorMessage()
        {
            return View("ErrorMsg");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}