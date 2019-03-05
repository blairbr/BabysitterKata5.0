using BabysitterKata5._0.Interfaces;


namespace BabysitterKata5._0
{
	public class PaymentCalculator : ICalculator
	{
		private readonly IBabySitterValidation validation;

		public PaymentCalculator(IBabySitterValidation validation)
		{
			this.validation = validation;
		}
		public Invoice CalculateBabysitterPaymentFromBabySitterContract(BabySitterContract babySitterContract)
		{
			var invoice = InitializeInvoice(babySitterContract);
			//if validation fails, return the invoice and do not calculate total payment
			if (!invoice.response)
			{
				return invoice;
			}

			CalculateTotalBabysitterPayment(babySitterContract, invoice);

			return invoice;
		}

		public void CalculateTotalBabysitterPayment(BabySitterContract babySitterContract, Invoice invoice)
		{
			bool stillWorking = false;
			foreach (Rate rate in babySitterContract.Rates)
			{
				// Set up variables
				decimal hoursWorkedAtCurrentRate;
				bool babySitterStartTimeisInRateBlock;
				bool babySitterEndTimeisInRateBlock;
				decimal ratePayment = decimal.Zero;

				babySitterStartTimeisInRateBlock = DetermineIfBabysitterStartTimeIsInRateBlock(babySitterContract, rate);
				babySitterEndTimeisInRateBlock = DetermineIfBabysitterEndTimeIsInRateBlock(babySitterContract, rate);

				//if the start and end time are both in a single rate block, update payment and return the invoice
				if (babySitterStartTimeisInRateBlock && babySitterEndTimeisInRateBlock)
				{
					invoice.totalPayment = CalculatePaymentIfBabysitterWorksDuringOnlyOneRate(invoice, babySitterContract, rate);
					return;
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
				invoice.totalPayment += ratePayment;
			}
		}

		public Invoice InitializeInvoice(BabySitterContract babySitterContract)
		{
			Invoice invoice = new Invoice()
			{
				totalPayment = 0,
				response = validation.ValidateUserInput(babySitterContract)
			};
			return invoice;
		}

		public bool DetermineIfBabysitterStartTimeIsInRateBlock(BabySitterContract babySitterContract, Rate rate)
		{
			return (babySitterContract.BabysitterStartTime >= rate.rateStartTime &&
					babySitterContract.BabysitterStartTime < rate.rateEndTime);
		}

		public bool DetermineIfBabysitterEndTimeIsInRateBlock(BabySitterContract babySitterContract, Rate rate)
		{
			return (babySitterContract.BabysitterEndTime > rate.rateStartTime &&
					babySitterContract.BabysitterEndTime <= rate.rateEndTime);
		}

		public decimal CalculatePaymentIfBabysitterWorksDuringOnlyOneRate(Invoice invoice, BabySitterContract babySitterContract, Rate rate)
		{
			invoice.totalPayment = rate.dollarsPerHour *
								   (babySitterContract.BabysitterEndTime - babySitterContract.BabysitterStartTime);
			return invoice.totalPayment;
		}
	}
}
