using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BabysitterKata5._0;
using System.Linq;


namespace BabysitterKata_UnitTests
{
	[TestClass]
	public class CalculationUnitTests
	{
		private PaymentCalculator calculator;

		private List<Rate> listOfRates;

		private const int sevenPM = 2;
		private const int midnight = 7;


		[TestInitialize]
		public void Setup()
		{
			calculator = new PaymentCalculator();
			listOfRates = new List<Rate>();
		}


		//start new test using the new babysitter contract object.
		//I didnt like the way it was set up before where the rate was defined only for the hours worked during that rate period,
		//so I plan to refactor the rest and c hagne the code so that a familiy can define a
		//Rate start and end time, $/hr, and  babysitter's start and end time. for poc adding in a 'family x' w/ a flat rate of 15 an hour
		[TestMethod]
		public void NewCheckBabysitterWorksForFamily_X_From7pmToMidnightAndEarnsFifteenDollarsAnHourForFiveHours()
		{

			//Arrange

			int expectedPaymentInDollars = 75;

			BabySitterContract babySitterContract = new BabySitterContract();
			babySitterContract.BabysitterStartTime = sevenPM;
			babySitterContract.BabysitterEndTime = midnight;
			babySitterContract.ListOfRatesInBabysitterContract = new List<Rate>();
			Rate fifteenDollarRate = new Rate() { rateStartTime = 0, rateEndTime = 11, dollarsPerHour = 15 };

			babySitterContract.ListOfRatesInBabysitterContract.Add(fifteenDollarRate);
			//Act
			int calculatedPayment = calculator.CalculateBabysitterPaymentFromBabySitterContract(babySitterContract);
			//Assert
			Assert.AreEqual(expectedPaymentInDollars, calculatedPayment);
		}

		// end new test


		[TestMethod]
		public void CheckBabysitterWorksForFamily_A_From5pmTo11pmAndEarnsFifteenDollarsAnHourForSixHours()
		{
			//Arrange
			Rate fifteenDollarRate = new Rate() { rateStartTime = 0, rateEndTime = 6, dollarsPerHour = 15 };

			listOfRates.Add(fifteenDollarRate);

			int expectedPaymentInDollars = 90;
			//Act
			int calculatedPayment = calculator.CalculateBabysitterPayment(listOfRates);
			//Assert
			Assert.AreEqual(expectedPaymentInDollars, calculatedPayment);
		}

		[TestMethod]
		public void CheckBabysitterWorksForFamily_A_From11pmTo4amAndEarnsTwentyDollarsAnHourForFiveHours()
		{
			//Arrange
			int expectedPaymentInDollars = 100;
			Rate twentyDollarRate = new Rate() { rateStartTime = 6, rateEndTime = 11, dollarsPerHour = 20 };

			listOfRates.Add(twentyDollarRate);

			//Act
			int calculatedPayment = calculator.CalculateBabysitterPayment(listOfRates);
			//Assert
			Assert.AreEqual(expectedPaymentInDollars, calculatedPayment);
		}

		[TestMethod]
		public void CheckBabysitterWorksForFamily_A_From10pmTo12amAndEarns15DollarsAnHourForOneHourAndTwentyDollarsAnHourForTheSecondHour()
		{
			//Arrange
			int expectedPaymentInDollars = 35;
			Rate fifteenDollarsAnHour = new Rate() { rateStartTime = 5, rateEndTime = 6, dollarsPerHour = 15 };
			Rate twentyDollarRate = new Rate() { rateStartTime = 6, rateEndTime = 7, dollarsPerHour = 20 };

			listOfRates.Add(fifteenDollarsAnHour);
			listOfRates.Add(twentyDollarRate);
			
			//Act
			int calculatedPayment = calculator.CalculateBabysitterPayment(listOfRates);
			//Assert
			Assert.AreEqual(expectedPaymentInDollars, calculatedPayment);
		}

		[TestMethod]
		public void CheckBabysitterWorksForFamily_A_From7pmTo4amAndEarns15DollarsAnHourForFourHoursAndTwentyDollarsAnHourForFiveHours()
		{
			//Arrange
			int expectedPaymentInDollars = 160;

			Rate fifteenDollarsAnHour = new Rate() { rateStartTime = 2, rateEndTime = 6, dollarsPerHour = 15 };
			Rate twentyDollarRate = new Rate() { rateStartTime = 6, rateEndTime = 11, dollarsPerHour = 20 };

			listOfRates.Add(fifteenDollarsAnHour);
			listOfRates.Add(twentyDollarRate);
			//Act
			int calculatedPayment = calculator.CalculateBabysitterPayment(listOfRates);
			//Assert
			Assert.AreEqual(expectedPaymentInDollars, calculatedPayment);
		}


		///Family C pays $21 per hour before 9pm, then $15 the rest of the night
		[TestMethod]
		public void CheckBabysitterWorksForFamily_C_From5pmTo9pmAndEarns21DollarsAnHourForFourHours()
		{
			//Arrange
			int expectedPaymentInDollars = 84;
			Rate twentyOneDollarsAnHour = new Rate() { rateStartTime = 0, rateEndTime = 4, dollarsPerHour = 21 };

			listOfRates.Add(twentyOneDollarsAnHour);
			//Act
			int calculatedPayment = calculator.CalculateBabysitterPayment(listOfRates);
			//Assert
			Assert.AreEqual(expectedPaymentInDollars, calculatedPayment);
		}

		[TestMethod]
		public void CheckBabysitterWorksForFamily_C_From9pmTo4amAndEarns15DollarsAnHourFor7Hours()
		{
			//Arrange
			int expectedPaymentInDollars = 105;
			Rate fifteenDollarsAnHour = new Rate() { rateStartTime = 4, rateEndTime = 11, dollarsPerHour = 15 };
			listOfRates.Add(fifteenDollarsAnHour);

			//Act
			int calculatedPayment = calculator.CalculateBabysitterPayment(listOfRates);
			//Assert
			Assert.AreEqual(expectedPaymentInDollars, calculatedPayment);
		}

		[TestMethod]
		public void CheckBabysitterWorksForFamily_C_From8pmTo11pmAndEarns21DollarsAnHourForOneHourAnd15DollarsAnHourForTwoHours()
		{
			//Arrange
			int expectedPaymentInDollars = 51;
			Rate twentyOneDollarsAnHour = new Rate() { rateStartTime = 3, rateEndTime = 4, dollarsPerHour = 21 };
			Rate fifteenDollarsAnHour = new Rate() { rateStartTime = 4, rateEndTime = 6, dollarsPerHour = 15 };
			listOfRates.Add(fifteenDollarsAnHour);
			listOfRates.Add(twentyOneDollarsAnHour);
			//Act
			int calculatedPayment = calculator.CalculateBabysitterPayment(listOfRates);
			//Assert
			Assert.AreEqual(expectedPaymentInDollars, calculatedPayment);
		}

		//	Family B pays $12 per hour before 10pm, $8 between 10 and 12, and $16 the rest of the night

		[TestMethod]
		public void CheckBabysitterWorksForFamily_B_From5pmTo10pmAndEarns12DollarsAnHourFor5Hours()
		{
			//Arrange
			int expectedPaymentInDollars = 60;
			Rate twelveDollarsAnHour = new Rate() { rateStartTime = 0, rateEndTime = 5, dollarsPerHour = 12 };
			listOfRates.Add(twelveDollarsAnHour);

			//Act
			int calculatedPayment = calculator.CalculateBabysitterPayment(listOfRates);
			//Assert
			Assert.AreEqual(expectedPaymentInDollars, calculatedPayment);
		}

		[TestMethod]
		public void CheckBabysitterWorksForFamily_B_From10pmTo12amAndEarns8DollarsAnHourForTwoHours()
		{
			//Arrange
			int expectedPaymentInDollars = 16;
			Rate eightDollarsAnHour = new Rate() { rateStartTime = 5, rateEndTime = 7, dollarsPerHour = 8 };
			listOfRates.Add(eightDollarsAnHour);
			//Act
			int calculatedPayment = calculator.CalculateBabysitterPayment(listOfRates);
			//Assert
			Assert.AreEqual(expectedPaymentInDollars, calculatedPayment);
		}

		[TestMethod]
		public void CheckBabysitterWorksForFamily_B_From12amTo4amAndEarns16DollarsAnHourForFourHours()
		{
			//Arrange
			int expectedPaymentInDollars = 64;
			Rate sixteenDollarsAnHour = new Rate() { rateStartTime = 7, rateEndTime = 11, dollarsPerHour = 16 };
			listOfRates.Add(sixteenDollarsAnHour);
			//Act
			int calculatedPayment = calculator.CalculateBabysitterPayment(listOfRates);
			//Assert
			Assert.AreEqual(expectedPaymentInDollars, calculatedPayment);
		}

		[TestMethod]
		public void CheckBabysitterWorksForFamily_B_From8pmTo11pmAndEarns12DollarsAnHourForTheFirst2HoursAnd8DollarsAnHourForTheThirdHour()
		{
			//Arrange
			int expectedPaymentInDollars = 32;

			Rate twelveDollarsAnHour = new Rate() { rateStartTime = 3, rateEndTime = 5, dollarsPerHour = 12 };
			Rate eightDollarsAnHour = new Rate() { rateStartTime = 5, rateEndTime = 6, dollarsPerHour = 8 };
			listOfRates.Add(twelveDollarsAnHour);
			listOfRates.Add(eightDollarsAnHour);
			//Act
			int calculatedPayment = calculator.CalculateBabysitterPayment(listOfRates);
			//Assert
			Assert.AreEqual(expectedPaymentInDollars, calculatedPayment);
		}

		[TestMethod]
		public void CheckBabysitterWorksForFamily_B_From10pmTo3amAndEarns8DollarsAnHourForTheFirst2HoursAnd16DollarsAnHourForTheLastThreeHours()
		{
			//Arrange
			int expectedPaymentInDollars = 64;
			Rate eightDollarsAnHour = new Rate() { rateStartTime = 5, rateEndTime = 7, dollarsPerHour = 8 };
			Rate sixteenDollarsAnHour = new Rate() { rateStartTime = 7, rateEndTime = 10, dollarsPerHour = 16 };
			listOfRates.Add(eightDollarsAnHour);
			listOfRates.Add(sixteenDollarsAnHour);

			//Act
			int calculatedPayment = calculator.CalculateBabysitterPayment(listOfRates);
			//Assert
			Assert.AreEqual(expectedPaymentInDollars, calculatedPayment);
		}


		[TestMethod]
		public void CheckBabysitterWorksForFamily_B_From5pmTo4amAndEarns12DollarsAnHourForTheFirst5HoursAnd8DollarsAnHourForTheNextTwoHoursAnd16DollarsAnHourForTheFinalFourHours()
		{
			//Arrange
			int expectedPaymentInDollars = 140;
			Rate twelveDollarsAnHour = new Rate() { rateStartTime = 0, rateEndTime = 5, dollarsPerHour = 12 };
			Rate eightDollarsAnHour = new Rate() { rateStartTime = 5, rateEndTime = 7, dollarsPerHour = 8 };
			Rate sixteenDollarsAnHour = new Rate() { rateStartTime = 7, rateEndTime = 11, dollarsPerHour = 16 };

			listOfRates.Add(twelveDollarsAnHour);
			listOfRates.Add(eightDollarsAnHour);
			listOfRates.Add(sixteenDollarsAnHour);
			//Act
			int calculatedPayment = calculator.CalculateBabysitterPayment(listOfRates);
			//Assert
			Assert.AreEqual(expectedPaymentInDollars, calculatedPayment);
		}
	}
}
