using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BabysitterKata5._0
{
	public class PaymentCalculator
	{
		decimal hoursWorkedAtCurrentRate = 0;

		public Invoice CalculateBabysitterPaymentFromBabySitterContract(BabySitterContract babySitterContract)
		{
			Invoice invoice = new Invoice();
			InputValidation validation = new InputValidation();
			invoice.totalPayment = 0;
			hoursWorkedAtCurrentRate = 0;
			bool stillWorking = false;

			invoice.response = validation.ValidateUserInput(babySitterContract);
			if (invoice.response == Invoice.validationFailed)
			{
				return invoice;
			}

			foreach (Rate rate in babySitterContract.ListOfRatesInBabysitterContract)
			{
				// Set up variables
				bool babySitterStartTimeisInRateBlock;
				bool babySitterEndTimeisInRateBlock;
				decimal ratePayment = 0;

				bool babysitterWorksDuringOnlyOneRate = DoesBabysitterWorkDuringOnlyOneRate(babySitterContract, rate);

				babySitterStartTimeisInRateBlock = DetermineIfBabysitterStartTimeIsInRateBlock(babySitterContract, rate);
				babySitterEndTimeisInRateBlock = DetermineIfBabysitterEndTimeIsInRateBlock(babySitterContract, rate);

				//Logic
				if (babysitterWorksDuringOnlyOneRate)
				{
					invoice.totalPayment = CalculatePaymentIfBabysitterWorksDuringOnlyOneRate(invoice, babySitterContract, rate);
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
				invoice.totalPayment = invoice.totalPayment + ratePayment;
			}

			return invoice;
		}

		private bool DetermineIfBabysitterStartTimeIsInRateBlock(BabySitterContract babySitterContract, Rate rate)
		{
			return (babySitterContract.BabysitterStartTime >= rate.rateStartTime &&
			        babySitterContract.BabysitterStartTime < rate.rateEndTime);
		}

		private bool DetermineIfBabysitterEndTimeIsInRateBlock(BabySitterContract babySitterContract, Rate rate)
		{
			return (babySitterContract.BabysitterEndTime > rate.rateStartTime &&
			        babySitterContract.BabysitterEndTime <= rate.rateEndTime);
		}

		private decimal CalculatePaymentIfBabysitterWorksDuringOnlyOneRate(Invoice invoice, BabySitterContract babySitterContract, Rate rate)
		{
				invoice.totalPayment = rate.dollarsPerHour*
				                       (babySitterContract.BabysitterEndTime - babySitterContract.BabysitterStartTime);
			return invoice.totalPayment;
		}

		private bool DoesBabysitterWorkDuringOnlyOneRate(BabySitterContract babySitterContract, Rate rate)
		{
			return DetermineIfBabysitterStartTimeIsInRateBlock(babySitterContract, rate) &&
			       DetermineIfBabysitterEndTimeIsInRateBlock(babySitterContract, rate);
		}

	}
}
