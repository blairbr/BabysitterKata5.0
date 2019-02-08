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

	}
}