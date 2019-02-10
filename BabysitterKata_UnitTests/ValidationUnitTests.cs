using System;
using BabysitterKata5._0;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BabysitterKata_UnitTests
{
	[TestClass]
	public class ValidationUnitTests
	{
		private IValidationService validationService;

		[TestInitialize]
		public void Setup()
		{
			//Arrange
			validationService = new ValidationService();
		}

		[TestMethod]
		public void CheckThatBabysitterStartsAtFivePmOrLater()
		{
			//Arrange
			bool expectedValue = true;
			//Act
			bool result = validationService.rateStartTimeIsFivePmOrLater(0);
			//Assert
			Assert.AreEqual(expectedValue, result);
		}

		[TestMethod]
		public void CheckThatBabysitterShiftEndsAtFourAmOrEarlier()
		{
			//Arrange
			bool expectedValue = true;
			//Act
			bool result = validationService.rateEndTimeIsFourAmOrEarlier(11);
			//Assert
			Assert.AreEqual(expectedValue, result);
		}

		[TestMethod]
		public void CheckThatBabysitterrateStartTimeIsBeforerateEndTime()
		{
			//Arrange
			bool expectedValue = true;
			//Act
			bool result = validationService.rateStartTimeIsBeforerateEndTime(2, 7);
			//Assert
			Assert.AreEqual(expectedValue, result);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentOutOfRangeException), "Start and/or end time is invalid.")]
		public void CheckThatExceptionIsThrownIfValidateUserInputParametersAreNotValid()
		{
			//arrange with out of range variables
			int rateStartTime = -1;
			int rateEndTime = 77;
			
			//act
			validationService.ValidateUserInput(rateStartTime, rateEndTime);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentOutOfRangeException), "Start and/or end time is invalid.")]
		public void CheckThatExceptionIsThrownIfrateStartTimeAfterrateEndTime()
		{
			//arrange with out of range variables
			int rateStartTime = 10;
			int rateEndTime = 4;

			//act
			validationService.ValidateUserInput(rateStartTime, rateEndTime);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentOutOfRangeException), "Start and/or end time is invalid.")]
		public void CheckThatExceptionIsThrownIfrateStartTimeBefore5pm()
		{
			//arrange with out of range variables
			int rateStartTime = -4;
			int rateEndTime = 4;

			//act
			validationService.ValidateUserInput(rateStartTime, rateEndTime);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentOutOfRangeException), "Start and/or end time is invalid.")]
		public void CheckThatExceptionIsThrownIfrateEndTimeAfter4am()
		{
			//arrange with out of range variables
			int rateStartTime = 1;
			int rateEndTime = 20;

			//act
			validationService.ValidateUserInput(rateStartTime, rateEndTime);
		}

	}
}