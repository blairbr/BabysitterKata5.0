using System;
using BabysitterKata5._0;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BabysitterKata_UnitTests
{
	[TestClass]
	public class ValidationUnitTests
	{
		private InputValidation validationService;

		[TestInitialize]
		public void Setup()
		{
			//Arrange
			validationService = new InputValidation();
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
			int babysitterStartTime = TimeConversion.ThreePm;
			int babysitterEndTime = TimeConversion.FiveAm;

			//act
			validationService.ValidateUserInput(babysitterStartTime, babysitterEndTime);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentOutOfRangeException), "Start and/or end time is invalid.")]
		public void CheckThatExceptionIsThrownIfBabysitterStartTimeAfterBabysitterEndTime()
		{
			//arrange with out of range variables
			int babysitterStartTime = TimeConversion.ThreePm;
			int babysitterEndTime = TimeConversion.FiveAm;

			//act
			validationService.ValidateUserInput(babysitterStartTime, babysitterEndTime);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentOutOfRangeException), "Start and/or end time is invalid.")]
		public void CheckThatExceptionIsThrownIfBabysitterStartTimeBefore5pm()
		{
			//arrange with out of range variables
			int babysitterStartTime = TimeConversion.TwoPm;
			int babysitterEndTime = TimeConversion.TwoAm;

			//act
			validationService.ValidateUserInput(babysitterStartTime, babysitterEndTime);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentOutOfRangeException), "Start and/or end time is invalid.")]
		public void CheckThatExceptionIsThrownIfBabysitterEndTimeAfter4am()
		{
			//arrange with out of range variables
			int babysitterStartTime = TimeConversion.SixPm;
			int babysitterEndTime = TimeConversion.FiveAm;

			//act
			validationService.ValidateUserInput(babysitterStartTime, babysitterEndTime);
		}
	}
}