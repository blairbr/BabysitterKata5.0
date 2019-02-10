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
		public int CalculateBabysitterPaymentFromBabySitterContract(BabySitterContract babySitterContract)
		{
			int hoursWorkedAtCurrentRate = 0;

			int totalPayment = 0;
			bool stillWorking = false;
			foreach (Rate rate in babySitterContract.ListOfRatesInBabysitterContract)
			{
				// Set up variables
				int ratePayment = 0;
				bool babySitterStartTimeisInRateBlock = false;
				bool babySitterEndTimeisInRateBlock = false;

				if (babySitterContract.BabysitterStartTime >= rate.rateStartTime &&
					babySitterContract.BabysitterStartTime < rate.rateEndTime)
				{
					babySitterStartTimeisInRateBlock = true;
				}

				if (babySitterContract.BabysitterEndTime > rate.rateStartTime &&
					babySitterContract.BabysitterEndTime <= rate.rateEndTime)
				{
					babySitterEndTimeisInRateBlock = true;
				}

				//Logic

				//if the whole time the babysitter works is in a single rate, break out of loop and return total payment.
				if (babySitterStartTimeisInRateBlock && babySitterEndTimeisInRateBlock)
				{
					totalPayment = rate.dollarsPerHour *
								   (babySitterContract.BabysitterEndTime - babySitterContract.BabysitterStartTime);
					break;
				}

				// otherwise, if the time the babysitter is there spans across multiple rates
				if (babySitterStartTimeisInRateBlock)
				{
					hoursWorkedAtCurrentRate = rate.rateEndTime - babySitterContract.BabysitterStartTime;
					ratePayment = hoursWorkedAtCurrentRate * rate.dollarsPerHour;
					stillWorking = true;
				}

				else if (babySitterEndTimeisInRateBlock)
				{
					hoursWorkedAtCurrentRate = babySitterContract.BabysitterEndTime - rate.rateStartTime;
					ratePayment = hoursWorkedAtCurrentRate * rate.dollarsPerHour;
					stillWorking = false;
				}

				//otherwise if stillWorking is true, babysitterEndTime hasn't been reached &
				//we can assume they're working the whole time during the rate block
				else if (stillWorking)
				{
					hoursWorkedAtCurrentRate = rate.rateEndTime - rate.rateStartTime;
					ratePayment = hoursWorkedAtCurrentRate * rate.dollarsPerHour;
				}
				totalPayment = totalPayment + ratePayment;
			}

			return totalPayment;
		}
	}
}
