using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace BabysitterKata5._0
{
	public class InputValidation
	{
		public string ValidateUserInput(BabySitterContract babySitterContract)
		{
			string response = Invoice.validationSucceeded;
			bool validateEndTime = BabysitterEndTimeIsFourAmOrEarlier(babySitterContract.BabysitterEndTime);
			bool validateStartTime = BabysitterStartTimeIsFivePmOrLater(babySitterContract.BabysitterStartTime);
			bool startAndEndAreInChronologicalOrder = BabysitterStartTimeIsBeforeBabysitterEndTime(babySitterContract.BabysitterStartTime, babySitterContract.BabysitterEndTime);
			bool allRateStartTimesAreBeforeRateEndTimes = AllRateStartTimesAreBeforeRateEndTimes(babySitterContract);

			if (!(validateEndTime && validateStartTime && startAndEndAreInChronologicalOrder && allRateStartTimesAreBeforeRateEndTimes))
			{
				response = Invoice.validationFailed;
				//ArgumentOutOfRangeException ex = new ArgumentOutOfRangeException();
				//throw ex;
				//debug this and see if 'validation failed' response ever gets returned.
			}

			return response;
		}
		public bool BabysitterStartTimeIsFivePmOrLater(int babysitterStartTime)
		{
			return babysitterStartTime >= TimeConversion.FivePm;
		}

		public bool BabysitterEndTimeIsFourAmOrEarlier(int babysitterEndTime)
		{
			return babysitterEndTime <= TimeConversion.FourAm;
		}

		public bool BabysitterStartTimeIsBeforeBabysitterEndTime(int babysitterStartTime, int babysitterEndTime)
		{
			return babysitterStartTime < babysitterEndTime;
		}

		public bool AllRateStartTimesAreBeforeRateEndTimes(BabySitterContract babySitterContract)
		{
			bool result = true;
			foreach (Rate rate in babySitterContract.ListOfRatesInBabysitterContract)
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
