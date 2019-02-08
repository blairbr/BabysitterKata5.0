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

			if (family.Equals(Family.C))
			{
				calculatedPayment = CalculateFamily_C_Rate(startTime, endTime, hoursWorked);
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
			const int elevenPM = 6;

			// Family A pays $15 per hour before 11pm, and $20 per hour the rest of the night

			if (startTime >= elevenPM) //if start time is at or after 11pm
			{
				numberOfHoursAtTwentyDollarRate = hoursWorked;
			}

			if (startTime < elevenPM && endTime <= elevenPM) //if start time is before 11pm and end time before or at 11pm
			{
				numberOfHoursAtFifteenDollarRate = hoursWorked;
			}

			if (startTime < elevenPM && endTime > elevenPM) //if start time is before 11pm and end time after 11pm
			{
				numberOfHoursAtFifteenDollarRate = elevenPM - startTime;
				numberOfHoursAtTwentyDollarRate = endTime - elevenPM;
			}

			paymentForFamilyA = numberOfHoursAtFifteenDollarRate*15 + numberOfHoursAtTwentyDollarRate*20;

			return paymentForFamilyA;
		}

		//FAMILY "C" RATE
		public int CalculateFamily_C_Rate(int startTime, int endTime, int hoursWorked)
		{
			//initialize variables
			int numberOfHoursAt_21_DollarRate = 0;
			int numberOfHoursAt_15_DollarRate = 0;
			int paymentForFamilyC = 0;
			const int ninePM = 4;

			// Family C pays $21 per hour before 9pm, then $15 the rest of the night

			if (endTime <= ninePM)
			{
				numberOfHoursAt_21_DollarRate = hoursWorked;
			}

			paymentForFamilyC = numberOfHoursAt_21_DollarRate * 21 + numberOfHoursAt_15_DollarRate * 15;

			return paymentForFamilyC;
		}
	}
}
