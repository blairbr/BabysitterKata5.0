using System;
using System.Collections.Generic;
using BabysitterKata5._0;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BabysitterKata_UnitTests
{
	[TestClass]
	public class ValidationUnitTests
	{
		private InputValidation validationService;
		private BabySitterContract babySitterContract;
		private List<Rate> listOfRates;
		private PaymentCalculator calculator;
		private List<Rate> listOfRates_FamilyA;
		private List<Rate> listOfRates_FamilyB;
		private List<Rate> listOfRates_FamilyC;
		private string successMessage = Invoice.validationSucceeded;

		[TestInitialize]
		public void Setup()
		{
			//Arrange
			validationService = new InputValidation();
			babySitterContract = new BabySitterContract();
			calculator = new PaymentCalculator();

			listOfRates = new List<Rate>();
			Rate fifteenDollarRate = new Rate() { rateStartTime = TimeConversion.FivePm, rateEndTime = TimeConversion.ElevenPm, dollarsPerHour = 15 };
			Rate twentyDollarRate = new Rate() { rateStartTime = TimeConversion.ElevenPm, rateEndTime = TimeConversion.FourAm, dollarsPerHour = 20 };
			listOfRates.Add(fifteenDollarRate);
			listOfRates.Add(twentyDollarRate);
			babySitterContract.ListOfRatesInBabysitterContract = listOfRates;

			// Initialize Family A Rate List
			listOfRates_FamilyA = new List<Rate>();
			listOfRates_FamilyA.Add(fifteenDollarRate);
			listOfRates_FamilyA.Add(twentyDollarRate);

			// Initialize Family B Rate List
			listOfRates_FamilyB = new List<Rate>();
			Rate twelveDollarsAnHour = new Rate() { rateStartTime = TimeConversion.FivePm, rateEndTime = TimeConversion.TenPm, dollarsPerHour = 12 };
			Rate eightDollarsAnHour = new Rate() { rateStartTime = TimeConversion.TenPm, rateEndTime = TimeConversion.Midnight, dollarsPerHour = 8 };
			Rate sixteenDollarsAnHour = new Rate() { rateStartTime = TimeConversion.Midnight, rateEndTime = TimeConversion.FourAm, dollarsPerHour = 16 };

			listOfRates_FamilyB.Add(twelveDollarsAnHour);
			listOfRates_FamilyB.Add(eightDollarsAnHour);
			listOfRates_FamilyB.Add(sixteenDollarsAnHour);

			// Initialize Family C Rate List
			listOfRates_FamilyC = new List<Rate>();
			Rate twentyOneDollarsAnHour = new Rate() { rateStartTime = TimeConversion.FivePm, rateEndTime = TimeConversion.NinePm, dollarsPerHour = 21 };
			listOfRates_FamilyC.Add(fifteenDollarRate);
			listOfRates_FamilyC.Add(twentyOneDollarsAnHour);
		}

		[TestMethod]
		public void CheckThatBabysitterStartsAtFivePmOrLater()
		{
			//Arrange
			bool expectedValue = true;
			//Act
			bool result = validationService.BabysitterStartTimeIsFivePmOrLater(TimeConversion.SixPm);
			//Assert
			Assert.AreEqual(expectedValue, result);
		}

		[TestMethod]
		public void CheckThatBabysitterShiftEndsAtFourAmOrEarlier()
		{
			//Arrange
			bool expectedValue = true;
			//Act
			bool result = validationService.BabysitterEndTimeIsFourAmOrEarlier(TimeConversion.FourAm);
			//Assert
			Assert.AreEqual(expectedValue, result);
		}

		[TestMethod]
		public void CheckThatTestReturnsFalseIfBabysitterShiftEndsAfterFourAm()
		{
			//Arrange
			bool expectedValue = false;
			//Act
			bool result = validationService.BabysitterEndTimeIsFourAmOrEarlier(TimeConversion.FiveAm);
			//Assert
			Assert.AreEqual(expectedValue, result);
		}  //this should throw an exception

		[TestMethod]
		public void CheckThatBabysitterStartTimeIsBeforeBabysitterEndTime()
		{
			//Arrange
			bool expectedValue = true;
			//Act
			bool result = validationService.BabysitterStartTimeIsBeforeBabysitterEndTime(TimeConversion.SevenPm, TimeConversion.OneAm);
			//Assert
			Assert.AreEqual(expectedValue, result);
		}

		[TestMethod]
		public void CheckThatAnErrorMessageIsReturnedIfValidateUserInputParametersAreNotValid()
		{
			//arrange with out of range variables
			babySitterContract.BabysitterStartTime = TimeConversion.ThreePm;
			babySitterContract.BabysitterEndTime = TimeConversion.FiveAm;

			//act
			string result = validationService.ValidateUserInput(babySitterContract);
			//Assert
			Assert.AreEqual(result, Invoice.validationFailed);

		}

		[TestMethod]
		public void CheckThatAnErrorMessageIsReturnedIfBabysitterStartTimeAfterBabysitterEndTime()
		{
			//arrange with out of range variables
			babySitterContract.BabysitterStartTime = TimeConversion.ThreePm;
			babySitterContract.BabysitterEndTime = TimeConversion.FiveAm;

			//act
			string result = validationService.ValidateUserInput(babySitterContract);

			//Assert
			Assert.AreEqual(result, Invoice.validationFailed);
		}

		[TestMethod]
		public void CheckThatAnErrorMessageIsReturnedIfBabysitterStartTimeBefore5pm()
		{
			//arrange with out of range variables
			babySitterContract.BabysitterStartTime = TimeConversion.TwoPm;
			babySitterContract.BabysitterEndTime = TimeConversion.TwoAm;

			//act
			string result = validationService.ValidateUserInput(babySitterContract);

			//Assert
			Assert.AreEqual(result, Invoice.validationFailed);
		}

		[TestMethod]
		public void CheckThatAnErrorMessageIsReturnedIfBabysitterEndTimeAfter4am()
		{
			//arrange with out of range variables
			babySitterContract.BabysitterStartTime = TimeConversion.SixPm;
			babySitterContract.BabysitterEndTime = TimeConversion.FiveAm;

			//act
			string result = validationService.ValidateUserInput(babySitterContract);

			//Assert
			Assert.AreEqual(result, Invoice.validationFailed);
		}

		[TestMethod]
		public void CheckBabysitterWorksForFamily_C_From5pmTo9pmAndInvoiceContainsValidationSuccessMessage()
		{
			//Arrange
			int expectedPaymentInDollars = 84;
			babySitterContract.BabysitterStartTime = TimeConversion.FivePm;
			babySitterContract.BabysitterEndTime = TimeConversion.NinePm;

			babySitterContract.ListOfRatesInBabysitterContract = listOfRates_FamilyC;
			//Act
			Invoice invoice = calculator.CalculateBabysitterPaymentFromBabySitterContract(babySitterContract);
			//Assert
			Assert.AreEqual(successMessage, invoice.response);
		}

		[TestMethod]
		public void CheckBabysitterWorksForFamily_B_From5pmTo4amAndInvoiceContainsValidationSuccessMessage()
		{
			//Arrange
			int expectedPaymentInDollars = 140;
			babySitterContract.BabysitterStartTime = TimeConversion.FivePm;
			babySitterContract.BabysitterEndTime = TimeConversion.FourAm;
			babySitterContract.ListOfRatesInBabysitterContract = listOfRates_FamilyB;

			//Act
			Invoice invoice = calculator.CalculateBabysitterPaymentFromBabySitterContract(babySitterContract);

			//Assert
			Assert.AreEqual(successMessage, invoice.response);
		}

		[TestMethod]
		public void CheckBabysitterWorksForFamily_A_From7pmToMidnightAndInvoiceContainsValidationSuccessMessage()
		{
			//Arrange
			int expectedPaymentInDollars = 80;
			babySitterContract.BabysitterStartTime = TimeConversion.SevenPm;
			babySitterContract.BabysitterEndTime = TimeConversion.Midnight;
			babySitterContract.ListOfRatesInBabysitterContract = listOfRates_FamilyA;

			//Act
			Invoice invoice = calculator.CalculateBabysitterPaymentFromBabySitterContract(babySitterContract);

			//Assert
			Assert.AreEqual(successMessage, invoice.response);
		}

	}
}