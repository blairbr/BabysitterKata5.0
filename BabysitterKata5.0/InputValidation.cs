using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabysitterKata5._0
{
	public class InputValidation
	{
		public void ValidateUserInput(int babysitterStartTime, int babysitterEndTime)
		{
			bool validateEndTime = BabysitterEndTimeIsFourAmOrEarlier(babysitterEndTime);
			bool validateStartTime = BabysitterStartTimeIsFivePmOrLater(babysitterStartTime);
			bool startAndEndAreInChronologicalOrder = BabysitterStartTimeIsBeforeBabysitterEndTime(babysitterStartTime, babysitterEndTime);

			if (!(validateEndTime && validateStartTime && startAndEndAreInChronologicalOrder))
			{
				ArgumentOutOfRangeException ex = new ArgumentOutOfRangeException();
				throw ex;
			}
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
	}
}
