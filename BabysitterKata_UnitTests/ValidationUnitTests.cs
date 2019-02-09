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
			bool result = validationService.StartTimeIsFivePmOrLater(0);
			//Assert
			Assert.AreEqual(expectedValue, result);
		}

		[TestMethod]
		public void CheckThatBabysitterShiftEndsAtFourAmOrEarlier()
		{
			//Arrange
			bool expectedValue = true;
			//Act
			bool result = validationService.EndTimeIsFourAmOrEarlier(11);
			//Assert
			Assert.AreEqual(expectedValue, result);
		}

		[TestMethod]
		public void CheckThatBabysitterStartTimeIsBeforeEndTime()
		{
			//Arrange
			bool expectedValue = true;
			//Act
			bool result = validationService.StartTimeIsBeforeEndTime(2, 7);
			//Assert
			Assert.AreEqual(expectedValue, result);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentOutOfRangeException), "Start and/or end time is invalid.")]
		public void CheckThatExceptionIsThrownIfValidateUserInputParametersAreNotValid()
		{
			//arrange with out of range variables
			int startTime = -1;
			int endTime = 77;
			
			//act
			validationService.ValidateUserInput(startTime, endTime);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentOutOfRangeException), "Start and/or end time is invalid.")]
		public void CheckThatExceptionIsThrownIfStartTimeAfterEndTime()
		{
			//arrange with out of range variables
			int startTime = 10;
			int endTime = 4;

			//act
			validationService.ValidateUserInput(startTime, endTime);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentOutOfRangeException), "Start and/or end time is invalid.")]
		public void CheckThatExceptionIsThrownIfStartTimeBefore5pm()
		{
			//arrange with out of range variables
			int startTime = -4;
			int endTime = 4;

			//act
			validationService.ValidateUserInput(startTime, endTime);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentOutOfRangeException), "Start and/or end time is invalid.")]
		public void CheckThatExceptionIsThrownIfEndTimeAfter4am()
		{
			//arrange with out of range variables
			int startTime = 1;
			int endTime = 20;

			//act
			validationService.ValidateUserInput(startTime, endTime);
		}

	}
}