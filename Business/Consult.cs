using Database;
using System.Data;

namespace Business {

	public class Consult {
		public int Id { get; set; }
		public string Cliente { get; set; }
		public string TipoCliente { get; set; }
		public string Nome { get; set; }
		public string Telefone { get; set; }
		public string Cidade { get; set; }
		public string Bairro { get; set; }
		public string Logradouro { get; set; }
		public string DataCadastro { get; set; }
		public string DataAtualizacao { get; set; }
		/// <summary>
		/// Resulta do banco de dados SELECT * FROM clientes
		/// </summary>
		/// <returns></returns>
		public List<Consult> ResultsDb () {
			var result = new List<Consult>();
			var dbResult = new ContextDb().DbList("select * from clientes");
			foreach (DataRow row in dbResult.Rows) {
				var consult = new Consult();
				consult.Id=Convert.ToInt32(row["clienteid"]);
				consult.Cliente=row["Cliente"].ToString();
				consult.TipoCliente=row["TipoCliente"].ToString();
				consult.Nome=row["Nomecontato"].ToString();
				consult.Telefone=row["Telefonecontato"].ToString();
				consult.Cidade=row["Cidade"].ToString();
				consult.Bairro=row["Bairro"].ToString();
				consult.Logradouro=row["Logradouro"].ToString();
				consult.DataCadastro=row["DataCadastro"].ToString();
				consult.DataAtualizacao=row["DataAtualizacao"].ToString();

				result.Add(consult);
			}
			return result;
		}
		/// <summary>
		/// Retorna do banco de dados a SQL passada
		/// </summary>
		/// <param name="sql"></param>
		/// <returns></returns>
		public List<Consult> ResultsDb (string sql) {
			var result = new List<Consult>();
			switch (sql) {
				case "search":
					sql="select * from clientes";
					break;
			}
			var dbResult = new ContextDb().DbList(sql);
			foreach (DataRow row in dbResult.Rows) {
				var consult = new Consult();
				consult.Id=Convert.ToInt32(row["clienteid"]);
				consult.Cliente=row["Cliente"].ToString();
				consult.TipoCliente=row["TipoCliente"].ToString();
				consult.Nome=row["Nomecontato"].ToString();
				consult.Telefone=row["Telefonecontato"].ToString();
				consult.Cidade=row["Cidade"].ToString();
				consult.Bairro=row["Bairro"].ToString();
				consult.Logradouro=row["Logradouro"].ToString();
				consult.DataCadastro=row["DataCadastro"].ToString();
				consult.DataAtualizacao=row["DataAtualizacao"].ToString();

				result.Add(consult);
			}
			return result;
		}
	}
}