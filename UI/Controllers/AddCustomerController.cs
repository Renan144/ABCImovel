using Business;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers {
	public class AddCustomerController:Controller {

		public IActionResult Index (string? id) {
			if (id!=null) {
				var sql = "SELECT * FROM clientes WHERE clienteid='"+id+"'";
				ViewBag.Customer=new Consult().ResultsDb(sql);
				ViewBag.Success=true;
			}
			return View();
		}
		public IActionResult Add (string id, string cliente, string tipocliente, string nome, string telefone, string cidade, string bairro, string logradouro, string datacad, string dataatt) {
			var sql = "INSERT INTO clientes"+
				" (clienteid, cliente, tipocliente, nome, telefone, cidade, bairro, logradouro, datacadastro, dataatualizacao) values ("+
						"'"+cliente+"'"+
						", '"+tipocliente+"'"+
						", '"+nome+"'"+
						", '"+telefone+"'"+
						", '"+cidade+"'"+
						", '"+bairro+"'"+
						", '"+logradouro+"'"+
						", "+datacad+"'"+
						", '"+dataatt+"'"+
						")";

			new Consult().ResultsDb(sql);
			return RedirectToAction("Index", new { id = id });
		}
	}
}
