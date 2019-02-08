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
		public void BabysitterWorksForFamily_A_From5pmTo11pmAndEarnsFifteenDollarsAnHourForSixHours()
		{
			//Arrange
			int expectedPaymentInDollars = 90;
			//Act
			int calculatedPayment = babysitter.CalculateBabysitterPayment(0, 6, Babysitter.Family.A);
			//Assert
			Assert.AreEqual(expectedPaymentInDollars, calculatedPayment);
		}

		[TestMethod]
		public void BabysitterWorksForFamily_A_From11pmTo4amAndEarnsTwentyDollarsAnHourForFiveHours()
		{
			//Arrange
			int expectedPaymentInDollars = 100;
			//Act
			int calculatedPayment = babysitter.CalculateBabysitterPayment(6, 11, Babysitter.Family.A);
			//Assert
			Assert.AreEqual(expectedPaymentInDollars, calculatedPayment);
		}

		[TestMethod]
		public void BabysitterWorksForFamily_A_From10pmTo12amAndEarns15DollarsAnHourForOneHourAndTwentyDollarsAnHourForTheSecondHour()
		{
			//Arrange
			int expectedPaymentInDollars = 35;
			//Act
			int calculatedPayment = babysitter.CalculateBabysitterPayment(5, 7, Babysitter.Family.A);
			//Assert
			Assert.AreEqual(expectedPaymentInDollars, calculatedPayment);
		}

		[TestMethod]
		public void BabysitterWorksForFamily_A_From7pmTo4amAndEarns15DollarsAnHourForFourHoursAndTwentyDollarsAnHourForFiveHours()
		{
			//Arrange
			int expectedPaymentInDollars = 160;
			//Act
			int calculatedPayment = babysitter.CalculateBabysitterPayment(2, 11, Babysitter.Family.A);
			//Assert
			Assert.AreEqual(expectedPaymentInDollars, calculatedPayment);
		}

		[TestMethod]
		public void BabysitterWorksForFamily_C_From5pmTo9pmAndEarns21DollarsAnHourForFourHours()
		{
			//Arrange
			int expectedPaymentInDollars = 84;
			//Act
			int calculatedPayment = babysitter.CalculateBabysitterPayment(0, 4, Babysitter.Family.C);
			//Assert
			Assert.AreEqual(expectedPaymentInDollars, calculatedPayment);
		}
	}
}
