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

		public void ValidateUserInput(int startTime, int endTime)
		{
			bool validEndTime = EndTimeIsFourAmOrEarlier(endTime);
			bool validStartTime = StartTimeIsFivePmOrLater(startTime);
			bool startAndEndAreInChronologicalOrder = StartTimeIsBeforeEndTime(startTime, endTime);

			if (!(validEndTime && validStartTime && startAndEndAreInChronologicalOrder))
			{
				ArgumentOutOfRangeException ex = new ArgumentOutOfRangeException();
				throw ex; 
			}
		}
		public bool StartTimeIsFivePmOrLater(int startTime)
		{
			return startTime >= fivePM;
		}

		public bool EndTimeIsFourAmOrEarlier(int endTime)
		{
			return endTime <= fourAM;
		}

		public bool StartTimeIsBeforeEndTime(int startTime, int endTime)
		{
			return endTime > startTime; 
		}
	}
}
