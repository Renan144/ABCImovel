using Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using UI.Data;
using UI.Models;

namespace UI.Controllers {
	public class HomeController:Controller {
		public IConfiguration Config {
			get;
		}

		public ActionResult Index () {
			return View();
		}

		public void ConfigureServices (IServiceCollection services) {
			ContextDb sql = new();
			services.AddMvc();
			services.AddControllersWithViews();
			services.AddEntityFrameworkSqlServer()
				.AddDbContext<DtBaseContext>(o => o.UseSqlServer(sql.sqlConn("webconfig")));
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error () {
			return View(new ErrorViewModel { RequestId=Activity.Current?.Id??HttpContext.TraceIdentifier });
		}
	}
}