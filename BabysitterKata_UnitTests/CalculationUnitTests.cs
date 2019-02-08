using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BabysitterKata5._0;

namespace BabysitterKata_UnitTests
{
	[TestClass]
	public class CalculationUnitTests
	{
		private ICalculationService calculationService;

		[TestInitialize]
		public void Setup()
		{
			//Arrange
			calculationService = new CalculationService();

		}

		[TestMethod]
		public void CheckIfCalculateHoursWorkedReturnsEndTimeMinusStartTime()
		{
			//Arrange
			int expectedValue = 1;
			//Act
			int hoursWorked = calculationService.CalculateHoursWorked(0, 1);
			//Assert
			Assert.AreEqual(expectedValue, hoursWorked);
		}

		[TestMethod]
		public void CheckBabysitterWorksForFamily_A_From5pmTo11pmAndEarnsFifteenDollarsAnHourForSixHours()
		{
			//Arrange
			int expectedPaymentInDollars = 90;
			//Act
			int calculatedPayment = calculationService.CalculateBabysitterPayment(0, 6, Family.A);
			//Assert
			Assert.AreEqual(expectedPaymentInDollars, calculatedPayment);
		}

		[TestMethod]
		public void CheckBabysitterWorksForFamily_A_From11pmTo4amAndEarnsTwentyDollarsAnHourForFiveHours()
		{
			//Arrange
			int expectedPaymentInDollars = 100;
			//Act
			int calculatedPayment = calculationService.CalculateBabysitterPayment(6, 11, Family.A);
			//Assert
			Assert.AreEqual(expectedPaymentInDollars, calculatedPayment);
		}

		[TestMethod]
		public void CheckBabysitterWorksForFamily_A_From10pmTo12amAndEarns15DollarsAnHourForOneHourAndTwentyDollarsAnHourForTheSecondHour()
		{
			//Arrange
			int expectedPaymentInDollars = 35;
			//Act
			int calculatedPayment = calculationService.CalculateBabysitterPayment(5, 7, Family.A);
			//Assert
			Assert.AreEqual(expectedPaymentInDollars, calculatedPayment);
		}

		[TestMethod]
		public void CheckBabysitterWorksForFamily_A_From7pmTo4amAndEarns15DollarsAnHourForFourHoursAndTwentyDollarsAnHourForFiveHours()
		{
			//Arrange
			int expectedPaymentInDollars = 160;
			//Act
			int calculatedPayment = calculationService.CalculateBabysitterPayment(2, 11, Family.A);
			//Assert
			Assert.AreEqual(expectedPaymentInDollars, calculatedPayment);
		}

		[TestMethod]
		public void CheckBabysitterWorksForFamily_C_From5pmTo9pmAndEarns21DollarsAnHourForFourHours()
		{
			//Arrange
			int expectedPaymentInDollars = 84;
			//Act
			int calculatedPayment = calculationService.CalculateBabysitterPayment(0, 4, Family.C);
			//Assert
			Assert.AreEqual(expectedPaymentInDollars, calculatedPayment);
		}

		[TestMethod]
		public void CheckBabysitterWorksForFamily_C_From9pmTo4amAndEarns15DollarsAnHourFor7Hours()
		{
			//Arrange
			int expectedPaymentInDollars = 105;
			//Act
			int calculatedPayment = calculationService.CalculateBabysitterPayment(4, 11, Family.C);
			//Assert
			Assert.AreEqual(expectedPaymentInDollars, calculatedPayment);
		}

		[TestMethod]
		public void CheckBabysitterWorksForFamily_C_From8pmTo11pmAndEarns21DollarsAnHourForOneHourAnd15DollarsAnHourForTwoHours()
		{
			//Arrange
			int expectedPaymentInDollars = 51;
			//Act
			int calculatedPayment = calculationService.CalculateBabysitterPayment(3, 6, Family.C);
			//Assert
			Assert.AreEqual(expectedPaymentInDollars, calculatedPayment);
		}

		[TestMethod]
		public void CheckBabysitterWorksForFamily_B_From5pmTo10pmAndEarns12DollarsAnHourFor5Hours()
		{
			//Arrange
			int expectedPaymentInDollars = 60;
			//Act
			int calculatedPayment = calculationService.CalculateBabysitterPayment(0, 5, Family.B);
			//Assert
			Assert.AreEqual(expectedPaymentInDollars, calculatedPayment);
		}

		[TestMethod]
		public void CheckBabysitterWorksForFamily_B_From10pmTo12amAndEarns8DollarsAnHourForTwoHours()
		{
			//Arrange
			int expectedPaymentInDollars = 16;
			//Act
			int calculatedPayment = calculationService.CalculateBabysitterPayment(5, 7, Family.B);
			//Assert
			Assert.AreEqual(expectedPaymentInDollars, calculatedPayment);
		}

		[TestMethod]
		public void CheckBabysitterWorksForFamily_B_From12amTo4amAndEarns16DollarsAnHourForFourHours()
		{
			//Arrange
			int expectedPaymentInDollars = 64;
			//Act
			int calculatedPayment = calculationService.CalculateBabysitterPayment(7, 11, Family.B);
			//Assert
			Assert.AreEqual(expectedPaymentInDollars, calculatedPayment);
		}

		[TestMethod]
		public void CheckBabysitterWorksForFamily_B_From8pmTo11pmAndEarns12DollarsAnHourForTheFirst2HoursAnd8DollarsAnHourForTheThirdHour()
		{
			//Arrange
			int expectedPaymentInDollars = 32;
			//Act
			int calculatedPayment = calculationService.CalculateBabysitterPayment(3, 6, Family.B);
			//Assert
			Assert.AreEqual(expectedPaymentInDollars, calculatedPayment);
		}

		[TestMethod]
		public void CheckBabysitterWorksForFamily_B_From10pmTo3amAndEarns8DollarsAnHourForTheFirst2HoursAnd16DollarsAnHourForTheLastThreeHours()
		{
			//Arrange
			int expectedPaymentInDollars = 64;
			//Act
			int calculatedPayment = calculationService.CalculateBabysitterPayment(5, 10, Family.B);
			//Assert
			Assert.AreEqual(expectedPaymentInDollars, calculatedPayment);
		}

		[TestMethod]
		public void CheckBabysitterWorksForFamily_B_From5pmTo4amAndEarns8DollarsAnHourForTheFirst5HoursAnd8DollarsAnHourForTheNextTwoHoursAnd16DollarsAnHourForTheFinalFourHours()
		{
			//Arrange
			int expectedPaymentInDollars = 140;
			//Act
			int calculatedPayment = calculationService.CalculateBabysitterPayment(0, 11, Family.B);
			//Assert
			Assert.AreEqual(expectedPaymentInDollars, calculatedPayment);
		}
	}
}
