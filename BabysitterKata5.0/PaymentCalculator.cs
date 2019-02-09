using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabysitterKata5._0
{
	public class PaymentCalculator
	{
		public int CalculateBabysitterPayment(List<Rate> rates)
		{
			int totalPayment = 0;
			foreach (Rate rate in rates)
			{
				totalPayment = totalPayment + rate.dollarsPerHour * (rate.endTime - rate.startTime);
			}
			return totalPayment;
		}
	}
}
