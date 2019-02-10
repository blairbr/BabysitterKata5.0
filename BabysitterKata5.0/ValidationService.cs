using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabysitterKata5._0
{
	public class ValidationService : IValidationService
	{
		public const int fourAM = 11;
		public const int fivePM = 0;

		public void ValidateUserInput(int rateStartTime, int rateEndTime)
		{
			bool validrateEndTime = rateEndTimeIsFourAmOrEarlier(rateEndTime);
			bool validrateStartTime = rateStartTimeIsFivePmOrLater(rateStartTime);
			bool startAndEndAreInChronologicalOrder = rateStartTimeIsBeforerateEndTime(rateStartTime, rateEndTime);

			if (!(validrateEndTime && validrateStartTime && startAndEndAreInChronologicalOrder))
			{
				ArgumentOutOfRangeException ex = new ArgumentOutOfRangeException();
				throw ex; 
			}
		}
		public bool rateStartTimeIsFivePmOrLater(int rateStartTime)
		{
			return rateStartTime >= fivePM;
		}

		public bool rateEndTimeIsFourAmOrEarlier(int rateEndTime)
		{
			return rateEndTime <= fourAM;
		}

		public bool rateStartTimeIsBeforerateEndTime(int rateStartTime, int rateEndTime)
		{
			return rateEndTime > rateStartTime; 
		}
	}
}
