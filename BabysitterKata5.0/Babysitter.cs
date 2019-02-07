using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace BabysitterKata5._0
{
    public class Babysitter
    {
		public enum Family {A, B, C }
		
		public bool StartTimeIsFivePmOrLater(int startTime)
		{
			return startTime >= 0;
		}

		public bool EndTimeIsFourAmOrEarlier(int endTime)
		{
			return endTime <= 11;
		}

		public bool StartTimeIsBeforeEndTime(int startTime, int endTime)
		{
			return endTime > startTime;
		}

		public int CalculateHoursWorked(int startTime, int endTime)
		{
			return endTime - startTime;
		}


		public int CalculateBabysitterPayment(int startTime, int endTime, Family family)
		{
			int calculatedPayment = 0;
			int hoursWorked = CalculateHoursWorked(startTime, endTime);

			if (family.Equals(Family.A))
			{
				calculatedPayment = CalculateFamily_A_Rate(startTime, endTime, hoursWorked);
			}

			return calculatedPayment;

		}

		//FAMILY "A" RATE
		public int CalculateFamily_A_Rate(int startTime, int endTime, int hoursWorked)
		{
			//initialize variables
			int numberOfHoursAtFifteenDollarRate = 0;
			int numberOfHoursAtTwentyDollarRate = 0;
			int paymentForFamilyA = 0;

			// Family A pays $15 per hour before 11pm, and $20 per hour the rest of the night

			if (startTime >= 6) //if start time is at or after 11pm
			{
				numberOfHoursAtTwentyDollarRate = endTime - startTime;
			}

			if (startTime < 6 && endTime <= 6) //if start time is before 11pm and end time before or at 11pm
			{
				numberOfHoursAtFifteenDollarRate = endTime - startTime;
			}

			if (startTime < 6 && endTime > 6) //if start time is before 11pm and end time after 11pm
			{
				numberOfHoursAtFifteenDollarRate = 6 - startTime;
				numberOfHoursAtTwentyDollarRate = endTime - 6;
			}

			paymentForFamilyA = ((numberOfHoursAtFifteenDollarRate*15) + (numberOfHoursAtTwentyDollarRate*20));

			return paymentForFamilyA;
		}
    }
}
