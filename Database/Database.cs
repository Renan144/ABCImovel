using Microsoft.Data.SqlClient;

namespace Database {
	public class Database {
		public string Nome {
			get; set;
		}
		public static List<Database> AddClientes (string param) {
			var clientes = new List<Database>();
			clientes.Add(new Database() { Nome=param });
			return clientes;
		}
		public static SqlConnection conn = new();

	}
}