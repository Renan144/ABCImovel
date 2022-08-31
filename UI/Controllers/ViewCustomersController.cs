using Business;
using Microsoft.AspNetCore.Mvc;
using UI.Models;

namespace UI.Controllers {
	public class ViewCustomersController:Controller {
		private IConfiguration Config { get; }
		public IActionResult Index () {
			var customers = new Consult().ResultsDb();
			var passView = new ViewCustomersModel(customers);
			ViewBag.Customers=customers;
			/***
			return View(passView);
			/*/
			return View();
			/***/
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
		public IActionResult Edit (string id, string cliente, string tipocliente, string nome, string telefone, string cidade, string bairro, string logradouro, string datacad, string dataatt) {
			var sql = "UPDATE clientes SET"+
				" cliente='"+cliente+"'"+
				" tipocliente='"+tipocliente+"'"+
				" nomecontato='"+nome+"'"+
				" telefonecontato='"+telefone+"'"+
				" cidade='"+cidade+"'"+
				" bairro='"+bairro+"'"+
				" logradouro='"+logradouro+"'"+
				" datacadastro='"+datacad+"'"+
				" dataatualizacao='"+dataatt+"'"+
				" WHERE id='"+id+"'";

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
