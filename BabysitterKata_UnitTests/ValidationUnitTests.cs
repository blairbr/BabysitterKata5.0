using BabysitterKata5._0;
using BabysitterKata5._0.Interfaces;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using BabysitterKata5._0.Enumerations;

namespace BabysitterKata_UnitTests
{
	[TestFixture]
	public class ValidationUnitTests
	{
		private BabySitterContract babySitterContract;
		private List<Rate> listOfRates;
		private List<Rate> FamilyA_Rates;
		private List<Rate> FamilyB_Rates;
		private List<Rate> FamilyC_Rates;
		private IBabySitterValidation validationService;
		private ICalculator calculator;

		[SetUp]
		public void Setup()
		{
			//Arrange
			validationService = new InputValidation();
			babySitterContract = new BabySitterContract();
			calculator = new PaymentCalculator(validationService);

			listOfRates = new List<Rate>();
			Rate fifteenDollarRate = new Rate() { rateStartTime = (int)Time.FivePm, rateEndTime = (int)Time.ElevenPm, dollarsPerHour = 15 };
			Rate twentyDollarRate = new Rate() { rateStartTime = (int)Time.ElevenPm, rateEndTime = (int)Time.FourAm, dollarsPerHour = 20 };
			listOfRates.Add(fifteenDollarRate);
			listOfRates.Add(twentyDollarRate);
			babySitterContract.Rates = listOfRates;

			// Initialize Family A Rate List
			FamilyA_Rates = new List<Rate>();
			FamilyA_Rates.Add(fifteenDollarRate);
			FamilyA_Rates.Add(twentyDollarRate);

			// Initialize Family B Rate List
			FamilyB_Rates = new List<Rate>();
			Rate twelveDollarsAnHour = new Rate() { rateStartTime = (int)Time.FivePm, rateEndTime = (int)Time.TenPm, dollarsPerHour = 12 };
			Rate eightDollarsAnHour = new Rate() { rateStartTime = (int)Time.TenPm, rateEndTime = (int)Time.Midnight, dollarsPerHour = 8 };
			Rate sixteenDollarsAnHour = new Rate() { rateStartTime = (int)Time.Midnight, rateEndTime = (int)Time.FourAm, dollarsPerHour = 16 };

			FamilyB_Rates.Add(twelveDollarsAnHour);
			FamilyB_Rates.Add(eightDollarsAnHour);
			FamilyB_Rates.Add(sixteenDollarsAnHour);

			// Initialize Family C Rate List
			FamilyC_Rates = new List<Rate>();
			Rate twentyOneDollarsAnHour = new Rate() { rateStartTime = (int)Time.FivePm, rateEndTime = (int)Time.NinePm, dollarsPerHour = 21 };
			FamilyC_Rates.Add(fifteenDollarRate);
			FamilyC_Rates.Add(twentyOneDollarsAnHour);
		}

		[Test]
		public void CheckThatBabysitterStartsAtFivePmOrLater()
		{
			//Act
			bool result = validationService.BabysitterStartTimeIsFivePmOrLater((int)Time.SixPm);
			//Assert
			Assert.IsTrue(result);
		}

		[Test]
		public void CheckThatBabysitterShiftEndsAtFourAmOrEarlier()
		{
			//Act
			bool result = validationService.BabysitterEndTimeIsFourAmOrEarlier((int)Time.FourAm);
			//Assert
			Assert.IsTrue(result);
		}

		[Test]
		public void CheckThatTestReturnsFalseIfBabysitterShiftEndsAfterFourAm()
		{
			//Act
			bool result = validationService.BabysitterEndTimeIsFourAmOrEarlier((int)Time.FiveAm);
			//Assert
			Assert.IsFalse(result);
		}

		[Test]
		public void CheckThatBabysitterStartTimeIsBeforeBabysitterEndTime()
		{
			//Act
			bool result = validationService.BabysitterStartTimeIsBeforeBabysitterEndTime((int)Time.SevenPm, (int)Time.OneAm);
			//Assert
			Assert.IsTrue(result);
		}

		[Test]
		public void CheckThatValidationReturnsFalseIfValidateUserInputParametersAreNotValid()
		{
			//arrange with out of range variables
			babySitterContract.BabysitterStartTime = (int)Time.ThreePm;
			babySitterContract.BabysitterEndTime = (int)Time.FiveAm;

			//act
			bool result = validationService.ValidateUserInput(babySitterContract);
			//Assert
			Assert.IsFalse(result);

		}

		[Test]
		public void CheckThatValidationReturnsFalseIfBabysitterStartTimeAfterBabysitterEndTime()
		{
			//arrange with out of range variables
			babySitterContract.BabysitterStartTime = (int)Time.ThreePm;
			babySitterContract.BabysitterEndTime = (int)Time.FiveAm;

			//act
			bool result = validationService.ValidateUserInput(babySitterContract);

			//Assert
			Assert.IsFalse(result);
		}

		[Test]
		public void CheckThatValidationReturnsFalseIfBabysitterStartTimeBefore5pm()
		{
			//arrange with out of range variables
			babySitterContract.BabysitterStartTime = (int)Time.TwoPm;
			babySitterContract.BabysitterEndTime = (int)Time.TwoAm;

			//act
			bool result = validationService.ValidateUserInput(babySitterContract);

			//Assert
			Assert.IsFalse(result);
		}

		[Test]
		public void CheckThatValidationReturnsFalseIfBabysitterEndTimeAfter4am()
		{
			//arrange with out of range variables
			babySitterContract.BabysitterStartTime = (int)Time.SixPm;
			babySitterContract.BabysitterEndTime = (int)Time.FiveAm;

			//act
			var result = validationService.ValidateUserInput(babySitterContract);

			//Assert
			Assert.IsFalse(result);
		}

		[Test]
		public void CheckBabysitterWorksForFamily_C_From5pmTo9pmAndInvoiceValidationResponseIsTrue()
		{
			//Arrange
			babySitterContract.BabysitterStartTime = (int)Time.FivePm;
			babySitterContract.BabysitterEndTime = (int)Time.NinePm;

			babySitterContract.Rates = FamilyC_Rates;
			//Act
			Invoice invoice = calculator.CalculateBabysitterPaymentFromBabySitterContract(babySitterContract);
			//Assert
			Assert.IsTrue(invoice.response);
		}

		[Test]
		public void CheckBabysitterWorksForFamily_B_From5pmTo4amAndInvoiceValidationResponseIsTrue()
		{
			//Arrange
			babySitterContract.BabysitterStartTime = (int)Time.FivePm;
			babySitterContract.BabysitterEndTime = (int)Time.FourAm;
			babySitterContract.Rates = FamilyB_Rates;

			//Act
			Invoice invoice = calculator.CalculateBabysitterPaymentFromBabySitterContract(babySitterContract);

			//Assert
			Assert.IsTrue(invoice.response);
		}

		[Test]
		public void CheckBabysitterWorksForFamily_A_From7pmToMidnightAndInvoiceValidationResponseIsTrue()
		{
			//Arrange
			babySitterContract.BabysitterStartTime = (int)Time.SevenPm;
			babySitterContract.BabysitterEndTime = (int)Time.Midnight;
			babySitterContract.Rates = FamilyA_Rates;

			//Act
			Invoice invoice = calculator.CalculateBabysitterPaymentFromBabySitterContract(babySitterContract);

			//Assert
			Assert.IsTrue(invoice.response);
		}

	}
}