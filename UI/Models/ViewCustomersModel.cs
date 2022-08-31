using Business;

namespace UI.Models {
	public class ViewCustomersModel {
		public IEnumerable<Consult> Customers { get; set; }

		public ViewCustomersModel (IEnumerable<Consult> customers) {
			Customers=customers;
		}
	}
}