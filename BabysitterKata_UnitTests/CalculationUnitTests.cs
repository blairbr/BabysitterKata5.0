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
		private BabySitterContract babySitterContract;

		private List<Rate> listOfRates_FamilyA;
		private List<Rate> listOfRates_FamilyB;
		private List<Rate> listOfRates_FamilyC;

		[TestInitialize]
		public void Setup()
		{
			calculator = new PaymentCalculator();
			babySitterContract = new BabySitterContract();

			// Initialize Family A Rate List
			listOfRates_FamilyA = new List<Rate>();
			Rate fifteenDollarRate = new Rate() { rateStartTime = TimeConversion.FivePm, rateEndTime = TimeConversion.ElevenPm, dollarsPerHour = 15 };
			Rate twentyDollarRate = new Rate() { rateStartTime = TimeConversion.ElevenPm, rateEndTime = TimeConversion.FourAm, dollarsPerHour = 20 };
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
			Rate fifteenDollarsAnHour = new Rate() { rateStartTime = TimeConversion.NinePm, rateEndTime = TimeConversion.FourAm, dollarsPerHour = 15 };

			listOfRates_FamilyC.Add(fifteenDollarsAnHour);
			listOfRates_FamilyC.Add(twentyOneDollarsAnHour);
		}
 
		[TestMethod]
		public void CheckBabysitterWorksForFamily_A_From7pmToMidnightAndEarnsFifteenDollarsAnHourFoursHoursAndTwentyDollarsAnHourForTheLastHour()
		{
			//Arrange
			int expectedPaymentInDollars = 80;
			babySitterContract.BabysitterStartTime = TimeConversion.SevenPm;
			babySitterContract.BabysitterEndTime = TimeConversion.Midnight;
			babySitterContract.ListOfRatesInBabysitterContract = listOfRates_FamilyA;

			//Act
			int calculatedPayment = calculator.CalculateBabysitterPaymentFromBabySitterContract(babySitterContract);
			//Assert
			Assert.AreEqual(expectedPaymentInDollars, calculatedPayment);
		}

		[TestMethod]
		public void CheckBabysitterWorksForFamily_A_From10pmTo12amAndEarns15DollarsAnHourForOneHourAndTwentyDollarsAnHourForTheSecondHour()
		{
			//Arrange
			int expectedPaymentInDollars = 35;

			babySitterContract.BabysitterStartTime = TimeConversion.TenPm;
			babySitterContract.BabysitterEndTime = TimeConversion.Midnight;
			babySitterContract.ListOfRatesInBabysitterContract = listOfRates_FamilyA;

			//Act
			int calculatedPayment = calculator.CalculateBabysitterPaymentFromBabySitterContract(babySitterContract);
			//Assert
			Assert.AreEqual(expectedPaymentInDollars, calculatedPayment);
		}

		[TestMethod]
		public void CheckBabysitterWorksForFamily_A_FromMidnightTo3amAndEarns20DollarsAnHourForThreeHours()
		{
			//Arrange
			int expectedPaymentInDollars = 60;

			babySitterContract.BabysitterStartTime = TimeConversion.Midnight;
			babySitterContract.BabysitterEndTime = TimeConversion.ThreeAm;
			babySitterContract.ListOfRatesInBabysitterContract = listOfRates_FamilyA;

			//Act
			int calculatedPayment = calculator.CalculateBabysitterPaymentFromBabySitterContract(babySitterContract);
			//Assert
			Assert.AreEqual(expectedPaymentInDollars, calculatedPayment);
		}

		[TestMethod]
		public void CheckBabysitterWorksForFamily_A_From5PmTo9pmAndEarns15DollarsAnHourForFourHours()
		{
			//Arrange
			int expectedPaymentInDollars = 60;

			babySitterContract.BabysitterStartTime = TimeConversion.FivePm;
			babySitterContract.BabysitterEndTime = TimeConversion.NinePm;
			babySitterContract.ListOfRatesInBabysitterContract = listOfRates_FamilyA;

			//Act
			int calculatedPayment = calculator.CalculateBabysitterPaymentFromBabySitterContract(babySitterContract);
			//Assert
			Assert.AreEqual(expectedPaymentInDollars, calculatedPayment);
		}

		[TestMethod]
		public void CheckBabysitterWorksForFamily_A_From5pmTo11pmAndEarnsFifteenDollarsAnHourForSixHours()
		{
			//Arrange
			int expectedPaymentInDollars = 90;

			babySitterContract.BabysitterStartTime = TimeConversion.FivePm;
			babySitterContract.BabysitterEndTime = TimeConversion.ElevenPm;
			babySitterContract.ListOfRatesInBabysitterContract = listOfRates_FamilyA;

			//Act
			int calculatedPayment = calculator.CalculateBabysitterPaymentFromBabySitterContract(babySitterContract);
			//Assert
			Assert.AreEqual(expectedPaymentInDollars, calculatedPayment);
		}

		[TestMethod]
		public void CheckBabysitterWorksForFamily_A_From11pmTo4amAndEarnsTwentyDollarsAnHourForFiveHours()
		{
			//Arrange
			int expectedPaymentInDollars = 100;

			babySitterContract.BabysitterStartTime = TimeConversion.ElevenPm;
			babySitterContract.BabysitterEndTime = TimeConversion.FourAm;

			babySitterContract.ListOfRatesInBabysitterContract = listOfRates_FamilyA;

			//Act
			int calculatedPayment = calculator.CalculateBabysitterPaymentFromBabySitterContract(babySitterContract);
			//Assert
			Assert.AreEqual(expectedPaymentInDollars, calculatedPayment);
		}

		[TestMethod]
		public void CheckBabysitterWorksForFamily_A_From7pmTo4amAndEarns15DollarsAnHourForFourHoursAndTwentyDollarsAnHourForFiveHours()
		{
			//Arrange
			int expectedPaymentInDollars = 160;
			babySitterContract.BabysitterStartTime = TimeConversion.SevenPm;
			babySitterContract.BabysitterEndTime = TimeConversion.FourAm;

			babySitterContract.ListOfRatesInBabysitterContract = listOfRates_FamilyA;
			//Act
			int calculatedPayment = calculator.CalculateBabysitterPaymentFromBabySitterContract(babySitterContract);
			//Assert
			Assert.AreEqual(expectedPaymentInDollars, calculatedPayment);
		}

		///Family C pays $21 per hour before 9pm, then $15 the rest of the night
		[TestMethod]
		public void CheckBabysitterWorksForFamily_C_From5pmTo9pmAndEarns21DollarsAnHourForFourHours()
		{
			//Arrange
			int expectedPaymentInDollars = 84;
			babySitterContract.BabysitterStartTime = TimeConversion.FivePm;
			babySitterContract.BabysitterEndTime = TimeConversion.NinePm;

			babySitterContract.ListOfRatesInBabysitterContract = listOfRates_FamilyC;
			//Act
			int calculatedPayment = calculator.CalculateBabysitterPaymentFromBabySitterContract(babySitterContract);
			//Assert
			Assert.AreEqual(expectedPaymentInDollars, calculatedPayment);
		}

		[TestMethod]
		public void CheckBabysitterWorksForFamily_C_From9pmTo4amAndEarns15DollarsAnHourFor7Hours()
		{
			//Arrange
			int expectedPaymentInDollars = 105;
			babySitterContract.BabysitterStartTime = TimeConversion.NinePm;
			babySitterContract.BabysitterEndTime = TimeConversion.FourAm;

			babySitterContract.ListOfRatesInBabysitterContract = listOfRates_FamilyC;

			//Act
			int calculatedPayment = calculator.CalculateBabysitterPaymentFromBabySitterContract(babySitterContract);
			//Assert
			Assert.AreEqual(expectedPaymentInDollars, calculatedPayment);
		}

		[TestMethod]
		public void CheckBabysitterWorksForFamily_C_From8pmTo11pmAndEarns21DollarsAnHourForOneHourAnd15DollarsAnHourForTwoHours()
		{
			//Arrange
			int expectedPaymentInDollars = 51;
			babySitterContract.BabysitterStartTime = TimeConversion.EightPm;
			babySitterContract.BabysitterEndTime = TimeConversion.ElevenPm;

			babySitterContract.ListOfRatesInBabysitterContract = listOfRates_FamilyC;
			//Act
			int calculatedPayment = calculator.CalculateBabysitterPaymentFromBabySitterContract(babySitterContract);
			//Assert
			Assert.AreEqual(expectedPaymentInDollars, calculatedPayment);
		}

		//	Family B pays $12 per hour before 10pm, $8 between 10 and 12, and $16 the rest of the night

		[TestMethod]
		public void CheckBabysitterWorksForFamily_B_From5pmTo10pmAndEarns12DollarsAnHourFor5Hours()
		{
			//Arrange
			int expectedPaymentInDollars = 60;
			babySitterContract.BabysitterStartTime = TimeConversion.FivePm;
			babySitterContract.BabysitterEndTime = TimeConversion.TenPm;

			babySitterContract.ListOfRatesInBabysitterContract = listOfRates_FamilyB;

			//Act
			int calculatedPayment = calculator.CalculateBabysitterPaymentFromBabySitterContract(babySitterContract);
			//Assert
			Assert.AreEqual(expectedPaymentInDollars, calculatedPayment);
		}

		[TestMethod]
		public void CheckBabysitterWorksForFamily_B_From10pmTo12amAndEarns8DollarsAnHourForTwoHours()
		{
			//Arrange
			int expectedPaymentInDollars = 16;
			babySitterContract.BabysitterStartTime = TimeConversion.TenPm;
			babySitterContract.BabysitterEndTime = TimeConversion.Midnight;

			babySitterContract.ListOfRatesInBabysitterContract = listOfRates_FamilyB;
			//Act
			int calculatedPayment = calculator.CalculateBabysitterPaymentFromBabySitterContract(babySitterContract);
			//Assert
			Assert.AreEqual(expectedPaymentInDollars, calculatedPayment);
		}

		//	Family B pays $12 per hour before 10pm, $8 between 10 and 12, and $16 the rest of the night
		[TestMethod]
		public void CheckBabysitterWorksForFamily_B_From12amTo4amAndEarns16DollarsAnHourForFourHours()
		{
			//Arrange
			int expectedPaymentInDollars = 64;
			babySitterContract.BabysitterStartTime = TimeConversion.Midnight;
			babySitterContract.BabysitterEndTime = TimeConversion.FourAm;

			babySitterContract.ListOfRatesInBabysitterContract = listOfRates_FamilyB;
			//Act
			int calculatedPayment = calculator.CalculateBabysitterPaymentFromBabySitterContract(babySitterContract);
			//Assert
			Assert.AreEqual(expectedPaymentInDollars, calculatedPayment);
		}

		[TestMethod]
		public void CheckBabysitterWorksForFamily_B_From8pmTo11pmAndEarns12DollarsAnHourForTheFirst2HoursAnd8DollarsAnHourForTheThirdHour()
		{
			//Arrange
			int expectedPaymentInDollars = 32;

			babySitterContract.BabysitterStartTime = TimeConversion.EightPm;
			babySitterContract.BabysitterEndTime = TimeConversion.ElevenPm;

			babySitterContract.ListOfRatesInBabysitterContract = listOfRates_FamilyB;
			//Act
			int calculatedPayment = calculator.CalculateBabysitterPaymentFromBabySitterContract(babySitterContract);
			//Assert
			Assert.AreEqual(expectedPaymentInDollars, calculatedPayment);
		}

		//	Family B pays $12 per hour before 10pm, $8 between 10 and 12, and $16 the rest of the night
		[TestMethod]
		public void CheckBabysitterWorksForFamily_B_From10pmTo3amAndEarns8DollarsAnHourForTheFirst2HoursAnd16DollarsAnHourForTheLastThreeHours()
		{
			//Arrange
			int expectedPaymentInDollars = 64;
			babySitterContract.BabysitterStartTime = TimeConversion.TenPm;
			babySitterContract.BabysitterEndTime = TimeConversion.ThreeAm;

			babySitterContract.ListOfRatesInBabysitterContract = listOfRates_FamilyB;

			//Act
			int calculatedPayment = calculator.CalculateBabysitterPaymentFromBabySitterContract(babySitterContract);
			//Assert
			Assert.AreEqual(expectedPaymentInDollars, calculatedPayment);
		}


		[TestMethod]
		public void CheckBabysitterWorksForFamily_B_From5pmTo4amAndEarns12DollarsAnHourForTheFirst5HoursAnd8DollarsAnHourForTheNextTwoHoursAnd16DollarsAnHourForTheFinalFourHours()
		{
			//Arrange
			int expectedPaymentInDollars = 140;
			babySitterContract.BabysitterStartTime = TimeConversion.FivePm;
			babySitterContract.BabysitterEndTime = TimeConversion.FourAm;

			babySitterContract.ListOfRatesInBabysitterContract = listOfRates_FamilyB;
			//Act
			int calculatedPayment = calculator.CalculateBabysitterPaymentFromBabySitterContract(babySitterContract);
			//Assert
			Assert.AreEqual(expectedPaymentInDollars, calculatedPayment);
		}
		//•	Family B pays $12 per hour before 10pm, $8 between 10 and 12, and $16 the rest of the night
		[TestMethod]
		public void CheckBabysitterWorksForFamily_B_From6pmToMidnightAndEarns12DollarsAnHourForTheFirst4HoursAndEightDollarsAnHourForTheLastTwoHours()
		{
			//Arrange
			int expectedPaymentInDollars = 64;
			babySitterContract.BabysitterStartTime = TimeConversion.SixPm;
			babySitterContract.BabysitterEndTime = TimeConversion.Midnight;

			babySitterContract.ListOfRatesInBabysitterContract = listOfRates_FamilyB;
			//Act
			int calculatedPayment = calculator.CalculateBabysitterPaymentFromBabySitterContract(babySitterContract);
			//Assert
			Assert.AreEqual(expectedPaymentInDollars, calculatedPayment);
		}
	}
}
