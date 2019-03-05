using BabysitterKata5._0.Enumerations;
using BabysitterKata5._0.Interfaces;

namespace BabysitterKata5._0
{
	public class InputValidation : IBabySitterValidation
	{
		public bool ValidateUserInput(BabySitterContract babySitterContract)
		{
			bool validateEndTime = BabysitterEndTimeIsFourAmOrEarlier(babySitterContract.BabysitterEndTime);
			bool validateStartTime = BabysitterStartTimeIsFivePmOrLater(babySitterContract.BabysitterStartTime);
			bool startAndEndAreInChronologicalOrder = BabysitterStartTimeIsBeforeBabysitterEndTime(babySitterContract.BabysitterStartTime, babySitterContract.BabysitterEndTime);
			bool allRateStartTimesAreBeforeRateEndTimes = AllRateStartTimesAreBeforeRateEndTimes(babySitterContract);

			return validateEndTime && validateStartTime 
			                       && startAndEndAreInChronologicalOrder 
			                       && allRateStartTimesAreBeforeRateEndTimes;
		}
		public bool BabysitterStartTimeIsFivePmOrLater(int babysitterStartTime)
		{
			return babysitterStartTime >= (int)Time.FivePm;
		}
		
		public bool BabysitterEndTimeIsFourAmOrEarlier(int babysitterEndTime)
		{
			return babysitterEndTime <= (int)Time.FourAm;
		}
		
		public bool BabysitterStartTimeIsBeforeBabysitterEndTime(int babysitterStartTime, int babysitterEndTime)
		{
			return babysitterStartTime < babysitterEndTime;
		}

		public bool AllRateStartTimesAreBeforeRateEndTimes(BabySitterContract babySitterContract)
		{
			bool result = true;
			foreach (Rate rate in babySitterContract.Rates)
			{
				if (rate.rateEndTime <= rate.rateStartTime)
				{
					result = false;
					break;
				}
			}
			return result;
		}
		
	}
}
