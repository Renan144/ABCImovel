using System;
using System.ComponentModel.DataAnnotations;

namespace UI.Models {

	public class FormModel {
		public int Id { get; set; }
		public string Cliente { get; set; }
		public string TipoCliente { get; set; }
		public string Nome { get; set; }
		public string Telefone { get; set; }
		public string Cidade { get; set; }
		public string Bairro { get; set; }
		public string Logradouro { get; set; }
		public string DataAtualizacao { get; set; }
	}
}
