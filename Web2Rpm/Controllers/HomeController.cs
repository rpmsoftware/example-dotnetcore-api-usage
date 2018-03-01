using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Web2Rpm.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System;

namespace Web2Rpm.Controllers
{
	public class HomeController : Controller
	{
		// CONFIGURATION
		private const string API_KEY = "fffff-fffff-fffff-fffff-fffff";
		private const string API_URL = "http://api.cubedms.com/rpm/api2.svc/ProcFormAdd";
		private const int API_PROCESSID = -1;

		// GET: /<controller>/
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Index(Lead leadForm)
		{
			if (!ModelState.IsValid)
			{
				return View(leadForm);
			}
			
			// Make the RPM form object
			RpmProcess rpmLead = new RpmProcess();
			rpmLead.ProcessID = API_PROCESSID;
			
			// Add the fields
			rpmLead.Form.Fields.Add(new RpmField() { Field = "Contact Name (First & Last)", Value = leadForm.Name });
			rpmLead.Form.Fields.Add(new RpmField() { Field = "Primary Contact Number", Value = leadForm.Phone });
			rpmLead.Form.Fields.Add(new RpmField() { Field = "Email", Value = leadForm.Email });
			rpmLead.Form.Fields.Add(new RpmField() { Field = "Company", Value = leadForm.Company });
			rpmLead.Form.Fields.Add(new RpmField() { Field = "Website", Value = leadForm.Website });
			rpmLead.Form.Fields.Add(new RpmField() { Field = "Web Lead Comment", Value = leadForm.Comment });

			// Turn into JSON
			string body = JsonConvert.SerializeObject(rpmLead);

			// Send
			HttpClient client = new HttpClient();
			try
			{
				var content = new StringContent(body, Encoding.UTF8, "application/json");
				content.Headers.Add("RpmApiKey", API_KEY);
				var response = await client.PostAsync(API_URL, content);
			}
			catch (HttpRequestException hre)
			{
				return RedirectToAction("Error");
			}
			catch (Exception ex)
			{
				return RedirectToAction("Error");
			}

			// Change the page
			return RedirectToAction("Sent");
		}

		public ActionResult Sent()
		{
			return View();
		}

		public ActionResult Error()
		{
			return View();
		}
	}
}
