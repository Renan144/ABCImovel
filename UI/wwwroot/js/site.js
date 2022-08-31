// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code

$(document).ready(function () {

	var address = $(location).attr("href");
	var temp = "";
	var pgAddress = address.match(/\/([^/]*)$/)[1];
	switch (pgAddress) {
		case "ViewCustomers":
			var temp = "Passando resposta SQL em Model List para Javascript via Serialization \n";
			for (i in customersJs) {
				temp += i + ": ";
				for (j in customersJs[i]) {
					temp += j + " = " + customersJs[i][j] + ", ";
				}
				temp += "; \n";
			}
			break;
		case "AddCustomer":
			break;
		case "SearchCustomer":
		case "DeleteCustomer":
			$("#fId label").text($("select option:selected").text());
			$("select").on("change", function () {
				$("#fId label").text($("select option:selected").text());
			});
			$("input").attr("placeholder", "")
			isIdNumeric = function () {
				if ($.isNumeric($("#selTxt").val()) == false && $("select option:selected").val() == "id") {
					alert("O campo ID precisa ser um número");
					$("#selTxt").focus();
				}
			};
			$("#send").mouseover(isIdNumeric);
			break;
		case "Edit":
			break;
		case "Delete":
			break;
		default:
			pgAddress = "home";
			break;
	}

});