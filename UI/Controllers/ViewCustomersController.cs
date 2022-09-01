using Business;
using Microsoft.AspNetCore.Mvc;
using UI.Models;

namespace UI.Controllers {
	public class ViewCustomersController:Controller {
		private IConfiguration Config { get; }
		public IActionResult Index (int? page) {
			if (page is null) {
				page=1;
			}

			ViewBag.Page=page;

			page=page-1;

			var pagelimit = 10;
			var pageRows = page * pagelimit;
			var offset = " ORDER BY clienteid OFFSET "+pageRows+" ROWS FETCH NEXT "+pagelimit+" ROWS ONLY";
			 
			var cTotal = new Consult().CountDb("SELECT count(*) FROM clientes");

			var sql = "SELECT * FROM clientes"+offset;
			var customers = new Consult().ResultsDb(sql);
			var passView = new ViewCustomersModel(customers);

			ViewBag.Customers=customers;
			ViewBag.Count = cTotal;
			ViewBag.PageLimit=pagelimit;

			Console.WriteLine(page);
			return View();
		}

		/// <summary>
		/// Retorna a página de edição dos clientes
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		public IActionResult Edit (string id) {
			var customers = new Consult().ResultsDb("select * from clientes where clienteid='"+id+"'");
			ViewBag.Customers=customers;
			return View();
		}
		/// <summary>
		/// Manda a edição para o SQL e retorna para a página de edição com o banco atualizado
		/// </summary>
		/// <returns></returns>
		[HttpPost]
		public IActionResult Edit (string id, string cliente, string tipocliente, string nomecontato, string telefonecontato, string cidade, string bairro, string logradouro, string datacad, string dataatt) {
			var sql = "UPDATE clientes SET "+
					"cliente='"+cliente+"', "+
					"tipocliente='"+tipocliente+"', "+
					"nomecontato='"+nomecontato+"', "+
					"telefonecontato='"+telefonecontato+"', "+
					"cidade='"+cidade+"', "+
					"bairro='"+bairro+"', "+
					"logradouro='"+logradouro+"', "+
					"datacadastro='"+datacad+"', "+
					"dataatualizacao='"+dataatt+"' "+
					"WHERE clienteid='"+id+"'";

			Console.WriteLine(sql);
			var customers = new Consult().ResultsDb(sql);
			return RedirectToAction("Index");
		}

		/// <summary>
		/// Deleta o cliente pelo Id passado
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public IActionResult Delete (string id) {
			var customers = new Consult().ResultsDb("DELETE FROM clientes WHERE clienteid='"+id+"'");
			var passView = new ViewCustomersModel(customers);
			ViewBag.Customers=customers;
			Console.WriteLine(id);
			return RedirectToAction("Index");
		}
	}
}
