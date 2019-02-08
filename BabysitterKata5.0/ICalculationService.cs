using System;

namespace BabysitterKata5._0
{
	public interface ICalculationService
	{
		int CalculateHoursWorked(int startTime, int endTime);

		int CalculateBabysitterPayment(int startTime, int endTime, Family family);
	}
}