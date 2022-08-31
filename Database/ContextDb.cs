using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Database {
	public class ContextDb {
		private IConfiguration Config { get; }
		public string sqlConn () {
			return "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=dbtest;Data Source=DESKTOP-Q4N95IU;";
		}
		public string sqlConn (string connStr) {
			string strTemp;
			switch (connStr) {
				case "json":
					strTemp="Server=DESKTOP-Q4N95IU;Database=dbtest;Integrated Security=SSPI;";
					break;

				case "webconfig":
					strTemp="Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=dbtest;Data Source=DESKTOP-Q4N95IU;";
					break;

				default:
					strTemp=Config.GetConnectionString("DataBase");
					break;
			}
			return strTemp;
		}

		public DataTable DbList (string sql) {
			using (SqlConnection conn = new(sqlConn("webconfig"))) {
				SqlCommand cmd = new SqlCommand(sql, conn);
				try {
					cmd.Connection.Open();
					cmd.ExecuteNonQuery();
					SqlDataAdapter adp = new();
					adp.SelectCommand=cmd;

					DataTable tbl = new();
					adp.Fill(tbl);

					return tbl;
				} catch (SqlException ex) {
					throw ex;
				} catch (Exception ex) {
					throw ex;
				}
			}
		}
	}
}
