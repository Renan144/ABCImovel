using Business;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers {
	public class DeleteCustomerController:Controller {
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
		public IActionResult Delete (string id) {
			if (id!=null) {
				var sql = "DELETE FROM clientes WHERE clienteid='"+id+"'";
				var customer = new Consult().ResultsDb(sql);
				ViewBag.Customer=customer;
				Console.WriteLine(sql);
			}
			return RedirectToAction("Index");
		}
	}
}
