using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BabysitterKata5._0;

namespace BabysitterKata_UnitTests
{
	[TestClass]
	public class BabysitterUnitTests
	{
		[TestMethod]
		public void CheckIfCalculateHoursWorkedReturnsEndTimeMinusStartTime()
		{
			//Arrange
			Babysitter babysitter = new Babysitter();
			int expectedValue = 1;
			//Act
			int hoursWorked = babysitter.CalculateHoursWorked(0, 1);
			//Assert
			Assert.AreEqual(expectedValue, hoursWorked);
		}
	}
}
