using Microsoft.AspNetCore.Html;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace UI.Controllers {
	public static class JSPassController {
		public static HtmlString SerializeObject (object passStr) {
			StringWriter strWriter;
			JsonTextWriter jsonWriter;
			using (strWriter=new()) {
				using (jsonWriter=new(strWriter)) {

					var serializer = new JsonSerializer {
						ContractResolver=new CamelCasePropertyNamesContractResolver()
					};
					jsonWriter.QuoteName=false;
					serializer.Serialize(jsonWriter, passStr);
				}
				/***/
				var rtrn = new HtmlString(strWriter.ToString());
				/*/
				var rtrn = strWriter.ToString();
				/***/
				return rtrn;
			}
		}
	}
}