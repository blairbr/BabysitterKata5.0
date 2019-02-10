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

		[TestInitialize]
		public void Setup()
		{
			//Arrange
			validationService = new InputValidation();
			babySitterContract = new BabySitterContract();

			listOfRates = new List<Rate>();
			Rate fifteenDollarRate = new Rate() { rateStartTime = TimeConversion.FivePm, rateEndTime = TimeConversion.ElevenPm, dollarsPerHour = 15 };
			Rate twentyDollarRate = new Rate() { rateStartTime = TimeConversion.ElevenPm, rateEndTime = TimeConversion.FourAm, dollarsPerHour = 20 };
			listOfRates.Add(fifteenDollarRate);
			listOfRates.Add(twentyDollarRate);
			babySitterContract.ListOfRatesInBabysitterContract = listOfRates;
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
		[ExpectedException(typeof(ArgumentOutOfRangeException), "Start and/or end time is invalid.")]
		public void CheckThatExceptionIsThrownIfValidateUserInputParametersAreNotValid()
		{
			//arrange with out of range variables
			babySitterContract.BabysitterStartTime = TimeConversion.ThreePm;
			babySitterContract.BabysitterEndTime = TimeConversion.FiveAm;

			//act
			validationService.ValidateUserInput(babySitterContract);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentOutOfRangeException), "Start and/or end time is invalid.")]
		public void CheckThatExceptionIsThrownIfBabysitterStartTimeAfterBabysitterEndTime()
		{
			//arrange with out of range variables
			babySitterContract.BabysitterStartTime = TimeConversion.ThreePm;
			babySitterContract.BabysitterEndTime = TimeConversion.FiveAm;

			//act
			validationService.ValidateUserInput(babySitterContract);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentOutOfRangeException), "Start and/or end time is invalid.")]
		public void CheckThatExceptionIsThrownIfBabysitterStartTimeBefore5pm()
		{
			//arrange with out of range variables
			babySitterContract.BabysitterStartTime = TimeConversion.TwoPm;
			babySitterContract.BabysitterEndTime = TimeConversion.TwoAm;

			//act
			validationService.ValidateUserInput(babySitterContract);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentOutOfRangeException), "Start and/or end time is invalid.")]
		public void CheckThatExceptionIsThrownIfBabysitterEndTimeAfter4am()
		{
			//arrange with out of range variables
			babySitterContract.BabysitterStartTime = TimeConversion.SixPm;
			babySitterContract.BabysitterEndTime = TimeConversion.FiveAm;

			//act
			validationService.ValidateUserInput(babySitterContract);
		}
	}
}