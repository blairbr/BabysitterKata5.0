using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabysitterKata5._0
{
	public class Invoice
	{
		public const string validationFailed = "Validation failed. Please enter valid input.";
		public const string validationSucceeded = "Validation successful.";
		public string response { get; set; }
		public decimal totalPayment { get; set; }
	}

	
}
