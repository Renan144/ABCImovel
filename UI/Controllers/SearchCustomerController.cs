using Business;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers {
	public class SearchCustomerController:Controller {
		public IActionResult Index (string? select, string? selTxt) {
			if (select!=null&&selTxt!=null) {
				var sql = "SELECT * FROM clientes WHERE "+select+" LIKE '%"+selTxt+"%'";
				var customers = new Consult().ResultsDb(sql);
				ViewBag.Customers=customers;
				ViewBag.SelTxt=selTxt;
				ViewBag.Success=true;
			}
			return View();
		}
	}
}