using BabysitterKata5._0;
using BabysitterKata5._0.Interfaces;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using BabysitterKata5._0.Enumerations;

namespace BabysitterKata_UnitTests
{
	[TestFixture]
	public class CalculationUnitTests
	{
		private ICalculator calculator;
		private BabySitterContract babySitterContract;

		private static List<Rate> FamilyA_Rates;
		private static List<Rate> FamilyB_Rates;
		private static List<Rate> FamilyC_Rates;

		private Mock<IBabySitterValidation> validator;

		[SetUp]
		public void Setup()
		{
			validator = new Mock<IBabySitterValidation>();
			calculator = new PaymentCalculator(validator.Object);
			babySitterContract = new BabySitterContract();

			// Initialize Family A Rate List
			FamilyA_Rates = new List<Rate>();
			Rate fifteenDollarRate = new Rate() { rateStartTime = (int)Time.FivePm, rateEndTime = (int)Time.ElevenPm, dollarsPerHour = 15 };
			Rate twentyDollarRate = new Rate() { rateStartTime = (int)Time.ElevenPm, rateEndTime = (int)Time.FourAm, dollarsPerHour = 20 };
			FamilyA_Rates.Add(fifteenDollarRate);
			FamilyA_Rates.Add(twentyDollarRate);

			// Initialize Family B Rate List
			FamilyB_Rates = new List<Rate>();
			Rate twelveDollarsAnHour = new Rate() { rateStartTime = (int)Time.FivePm, rateEndTime = (int)Time.TenPm, dollarsPerHour = 12 };
			Rate eightDollarsAnHour = new Rate() { rateStartTime = (int)Time.TenPm, rateEndTime = (int)Time.Midnight, dollarsPerHour = 8 };
			Rate sixteenDollarsAnHour = new Rate() { rateStartTime = (int)Time.Midnight, rateEndTime = (int)Time.FourAm, dollarsPerHour = 16 };

			FamilyB_Rates.Add(twelveDollarsAnHour);
			FamilyB_Rates.Add(eightDollarsAnHour);
			FamilyB_Rates.Add(sixteenDollarsAnHour);

			// Initialize Family C Rate List
			FamilyC_Rates = new List<Rate>();
			Rate twentyOneDollarsAnHour = new Rate() { rateStartTime = (int)Time.FivePm, rateEndTime = (int)Time.NinePm, dollarsPerHour = 21 };
			Rate fifteenDollarsAnHour = new Rate() { rateStartTime = (int)Time.NinePm, rateEndTime = (int)Time.FourAm, dollarsPerHour = 15 };

			FamilyC_Rates.Add(fifteenDollarsAnHour);
			FamilyC_Rates.Add(twentyOneDollarsAnHour);
			validator.Setup(val => val.ValidateUserInput(It.IsAny<BabySitterContract>())).Returns(true);
		}

		[Test]
		public void CheckBabysitterWorksForFamily_A_From7pmToMidnightAndEarnsFifteenDollarsAnHourFoursHoursAndTwentyDollarsAnHourForTheLastHour()
		{
			//Arrange
			decimal expectedPaymentInDollars = 80m;
			babySitterContract.BabysitterStartTime = (int)Time.SevenPm;
			babySitterContract.BabysitterEndTime = (int)Time.Midnight;
			babySitterContract.Rates = FamilyA_Rates;

			//Act
			Invoice invoice = calculator.CalculateBabysitterPaymentFromBabySitterContract(babySitterContract);
			//Assert
			NUnit.Framework.Assert.AreEqual(expectedPaymentInDollars, invoice.totalPayment);
		}

		[Test]
		public void CheckBabysitterWorksForFamily_A_From10pmTo12amAndEarns15DollarsAnHourForOneHourAndTwentyDollarsAnHourForTheSecondHour()
		{
			//Arrange
			decimal expectedPaymentInDollars = 35m;
			babySitterContract.BabysitterStartTime = (int)Time.TenPm;
			babySitterContract.BabysitterEndTime = (int)Time.Midnight;
			babySitterContract.Rates = FamilyA_Rates;

			//Act
			Invoice invoice = calculator.CalculateBabysitterPaymentFromBabySitterContract(babySitterContract);
			//Assert
			Assert.AreEqual(expectedPaymentInDollars, invoice.totalPayment);
		}

		[Test]
		public void CheckBabysitterWorksForFamily_A_FromMidnightTo3amAndEarns20DollarsAnHourForThreeHours()
		{
			//Arrange
			decimal expectedPaymentInDollars = 60m;
			babySitterContract.BabysitterStartTime = (int)Time.Midnight;
			babySitterContract.BabysitterEndTime = (int)Time.ThreeAm;
			babySitterContract.Rates = FamilyA_Rates;

			//Act
			Invoice invoice = calculator.CalculateBabysitterPaymentFromBabySitterContract(babySitterContract);
			//Assert
			Assert.AreEqual(expectedPaymentInDollars, invoice.totalPayment);
		}

		[Test]
		public void CheckBabysitterWorksForFamily_A_From5PmTo9pmAndEarns15DollarsAnHourForFourHours()
		{
			//Arrange
			decimal expectedPaymentInDollars = 60m;
			babySitterContract.BabysitterStartTime = (int)Time.FivePm;
			babySitterContract.BabysitterEndTime = (int)Time.NinePm;
			babySitterContract.Rates = FamilyA_Rates;

			//Act
			Invoice invoice = calculator.CalculateBabysitterPaymentFromBabySitterContract(babySitterContract);
			//Assert
			Assert.AreEqual(expectedPaymentInDollars, invoice.totalPayment);
		}

		[Test]
		public void CheckBabysitterWorksForFamily_A_From5pmTo11pmAndEarnsFifteenDollarsAnHourForSixHours()
		{
			//Arrange
			decimal expectedPaymentInDollars = 90m;
			babySitterContract.BabysitterStartTime = (int)Time.FivePm;
			babySitterContract.BabysitterEndTime = (int)Time.ElevenPm;
			babySitterContract.Rates = FamilyA_Rates;

			//Act
			Invoice invoice = calculator.CalculateBabysitterPaymentFromBabySitterContract(babySitterContract);
			//Assert
			Assert.AreEqual(expectedPaymentInDollars, invoice.totalPayment);
		}

		[Test]
		public void CheckBabysitterWorksForFamily_A_From11pmTo4amAndEarnsTwentyDollarsAnHourForFiveHours()
		{
			//Arrange
			decimal expectedPaymentInDollars = 100m;
			babySitterContract.BabysitterStartTime = (int)Time.ElevenPm;
			babySitterContract.BabysitterEndTime = (int)Time.FourAm;

			babySitterContract.Rates = FamilyA_Rates;

			//Act
			Invoice invoice = calculator.CalculateBabysitterPaymentFromBabySitterContract(babySitterContract);
			//Assert
			Assert.AreEqual(expectedPaymentInDollars, invoice.totalPayment);
		}

		[Test]
		public void CheckBabysitterWorksForFamily_A_From7pmTo4amAndEarns15DollarsAnHourForFourHoursAndTwentyDollarsAnHourForFiveHours()
		{
			//Arrange
			decimal expectedPaymentInDollars = 160m;
			babySitterContract.BabysitterStartTime = (int)Time.SevenPm;
			babySitterContract.BabysitterEndTime = (int)Time.FourAm;
			babySitterContract.Rates = FamilyA_Rates;
			//Act
			Invoice invoice = calculator.CalculateBabysitterPaymentFromBabySitterContract(babySitterContract);
			//Assert
			Assert.AreEqual(expectedPaymentInDollars, invoice.totalPayment);
		}

		///Family C pays $21 per hour before 9pm, then $15 the rest of the night
		[Test]
		public void CheckBabysitterWorksForFamily_C_From5pmTo9pmAndEarns21DollarsAnHourForFourHours()
		{
			//Arrange
			decimal expectedPaymentInDollars = 84;
			babySitterContract.BabysitterStartTime = (int)Time.FivePm;
			babySitterContract.BabysitterEndTime = (int)Time.NinePm;
			babySitterContract.Rates = FamilyC_Rates;
			//Act
			Invoice invoice = calculator.CalculateBabysitterPaymentFromBabySitterContract(babySitterContract);
			//Assert
			Assert.AreEqual(expectedPaymentInDollars, invoice.totalPayment);
		}

		[Test]
		public void CheckBabysitterWorksForFamily_C_From9pmTo4amAndEarns15DollarsAnHourFor7Hours()
		{
			//Arrange
			decimal expectedPaymentInDollars = 105m;
			babySitterContract.BabysitterStartTime = (int)Time.NinePm;
			babySitterContract.BabysitterEndTime = (int)Time.FourAm;
			babySitterContract.Rates = FamilyC_Rates;

			//Act
			Invoice invoice = calculator.CalculateBabysitterPaymentFromBabySitterContract(babySitterContract);
			//Assert
			Assert.AreEqual(expectedPaymentInDollars, invoice.totalPayment);
		}

		[Test]
		public void CheckBabysitterWorksForFamily_C_From8pmTo11pmAndEarns21DollarsAnHourForOneHourAnd15DollarsAnHourForTwoHours()
		{
			//Arrange
			decimal expectedPaymentInDollars = 51m;
			babySitterContract.BabysitterStartTime = (int)Time.EightPm;
			babySitterContract.BabysitterEndTime = (int)Time.ElevenPm;
			babySitterContract.Rates = FamilyC_Rates;
			//Act
			Invoice invoice = calculator.CalculateBabysitterPaymentFromBabySitterContract(babySitterContract);
			//Assert
			Assert.AreEqual(expectedPaymentInDollars, invoice.totalPayment);
		}

		//	Family B pays $12 per hour before 10pm, $8 between 10 and 12, and $16 the rest of the night

		[Test]
		public void CheckBabysitterWorksForFamily_B_From5pmTo10pmAndEarns12DollarsAnHourFor5Hours()
		{
			//Arrange
			decimal expectedPaymentInDollars = 60m;
			babySitterContract.BabysitterStartTime = (int)Time.FivePm;
			babySitterContract.BabysitterEndTime = (int)Time.TenPm;
			babySitterContract.Rates = FamilyB_Rates;

			//Act
			Invoice invoice = calculator.CalculateBabysitterPaymentFromBabySitterContract(babySitterContract);
			//Assert
			Assert.AreEqual(expectedPaymentInDollars, invoice.totalPayment);
		}

		[Test]
		public void CheckBabysitterWorksForFamily_B_From10pmTo12amAndEarns8DollarsAnHourForTwoHours()
		{
			//Arrange
			decimal expectedPaymentInDollars = 16m;
			babySitterContract.BabysitterStartTime = (int)Time.TenPm;
			babySitterContract.BabysitterEndTime = (int)Time.Midnight;
			babySitterContract.Rates = FamilyB_Rates;
			//Act
			Invoice invoice = calculator.CalculateBabysitterPaymentFromBabySitterContract(babySitterContract);
			//Assert
			Assert.AreEqual(expectedPaymentInDollars, invoice.totalPayment);
		}

		//	Family B pays $12 per hour before 10pm, $8 between 10 and 12, and $16 the rest of the night
		[Test]
		public void CheckBabysitterWorksForFamily_B_From12amTo4amAndEarns16DollarsAnHourForFourHours()
		{
			//Arrange
			decimal expectedPaymentInDollars = 64m;
			babySitterContract.BabysitterStartTime = (int)Time.Midnight;
			babySitterContract.BabysitterEndTime = (int)Time.FourAm;
			babySitterContract.Rates = FamilyB_Rates;
			//Act
			Invoice invoice = calculator.CalculateBabysitterPaymentFromBabySitterContract(babySitterContract);
			//Assert
			Assert.AreEqual(expectedPaymentInDollars, invoice.totalPayment);
		}

		[Test]
		public void CheckBabysitterWorksForFamily_B_From8pmTo11pmAndEarns12DollarsAnHourForTheFirst2HoursAnd8DollarsAnHourForTheThirdHour()
		{
			//Arrange
			decimal expectedPaymentInDollars = 32m;
			babySitterContract.BabysitterStartTime = (int)Time.EightPm;
			babySitterContract.BabysitterEndTime = (int)Time.ElevenPm;

			babySitterContract.Rates = FamilyB_Rates;
			//Act
			Invoice invoice = calculator.CalculateBabysitterPaymentFromBabySitterContract(babySitterContract);
			//Assert
			Assert.AreEqual(expectedPaymentInDollars, invoice.totalPayment);
		}

		//	Family B pays $12 per hour before 10pm, $8 between 10 and 12, and $16 the rest of the night
		[Test]
		public void CheckBabysitterWorksForFamily_B_From10pmTo3amAndEarns8DollarsAnHourForTheFirst2HoursAnd16DollarsAnHourForTheLastThreeHours()
		{
			//Arrange
			decimal expectedPaymentInDollars = 64m;
			babySitterContract.BabysitterStartTime = (int)Time.TenPm;
			babySitterContract.BabysitterEndTime = (int)Time.ThreeAm;
			babySitterContract.Rates = FamilyB_Rates;

			//Act
			Invoice invoice = calculator.CalculateBabysitterPaymentFromBabySitterContract(babySitterContract);
			//Assert
			Assert.AreEqual(expectedPaymentInDollars, invoice.totalPayment);
		}


		[Test]
		public void CheckBabysitterWorksForFamily_B_From5pmTo4amAndEarns12DollarsAnHourForTheFirst5HoursAnd8DollarsAnHourForTheNextTwoHoursAnd16DollarsAnHourForTheFinalFourHours()
		{
			//Arrange
			decimal expectedPaymentInDollars = 140m;
			babySitterContract.BabysitterStartTime = (int)Time.FivePm;
			babySitterContract.BabysitterEndTime = (int)Time.FourAm;
			babySitterContract.Rates = FamilyB_Rates;
			//Act
			Invoice invoice = calculator.CalculateBabysitterPaymentFromBabySitterContract(babySitterContract);
			//Assert
			Assert.AreEqual(expectedPaymentInDollars, invoice.totalPayment);
		}
		//	Family B pays $12 per hour before 10pm, $8 between 10 and 12, and $16 the rest of the night
		[Test]
		public void CheckBabysitterWorksForFamily_B_From6pmToMidnightAndEarns12DollarsAnHourForTheFirst4HoursAndEightDollarsAnHourForTheLastTwoHours()
		{
			//Arrange
			decimal expectedPaymentInDollars = 64m;
			babySitterContract.BabysitterStartTime = (int)Time.SixPm;
			babySitterContract.BabysitterEndTime = (int)Time.Midnight;
			babySitterContract.Rates = FamilyB_Rates;
			//Act
			Invoice invoice = calculator.CalculateBabysitterPaymentFromBabySitterContract(babySitterContract);
			//Assert
			Assert.AreEqual(expectedPaymentInDollars, invoice.totalPayment);
		}
	}
}
