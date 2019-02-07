using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BabysitterKata5._0;

namespace BabysitterKata_UnitTests
{
	[TestClass]
	public class BabysitterUnitTests
	{
		private Babysitter babysitter;

		[TestInitialize]
		public void Setup()
		{
			//Arrange
			babysitter = new Babysitter();
		}

		[TestMethod]
		public void CheckIfCalculateHoursWorkedReturnsEndTimeMinusStartTime()
		{
			Setup();
			int expectedValue = 1;
			//Act
			int hoursWorked = babysitter.CalculateHoursWorked(0, 1);
			//Assert
			Assert.AreEqual(expectedValue, hoursWorked);
		}

		[TestMethod]
		public void CheckThatBabysitterStartsAtFivePmOrLater()
		{
			//Arrange
			bool expectedValue = true;
			//Act
			bool result = babysitter.StartTimeIsFivePmOrLater(0);
			//Assert
			Assert.AreEqual(expectedValue, result);
		}

		[TestMethod]
		public void CheckThatBabysitterShiftEndsAtFourAmOrEarlier()
		{
			//Arrange
			bool expectedValue = true;
			//Act
			bool result = babysitter.EndTimeIsFourAmOrEarlier(11);
			//Assert
			Assert.AreEqual(expectedValue, result);
		}

		[TestMethod]
		public void CheckThatBabysitterStartTimeIsBeforeEndTime()
		{
			//Arrange
			bool expectedValue = true;
			//Act
			bool result = babysitter.StartTimeIsBeforeEndTime(2, 7);
			//Assert
			Assert.AreEqual(expectedValue, result);
		}

		[TestMethod]
		public void NightlyChargeEqualsTotalHoursTimesTwo()
		{
			//Arrange
			int expectedPaymentInDollars = 10;
			//Act
			int calculatedPayment = babysitter.CalculateBabysitterPayment(0, 5);
			//Assert
			Assert.AreEqual(expectedPaymentInDollars, calculatedPayment);
		}
	}
}
