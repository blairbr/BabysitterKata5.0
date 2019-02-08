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

					int numberOfHoursAt12DollarRate = 0;

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

			else if (family.Equals(Family.C))
			{
				calculatedPayment = CalculateFamily_C_Rate(startTime, endTime, hoursWorked);
			}

			else calculatedPayment = CalculateFamily_B_Rate(startTime, endTime, hoursWorked);

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

			if (endTime <= elevenPM)
			{
				numberOfHoursAtFifteenDollarRate = hoursWorked;
			}

			else if (startTime >= elevenPM)
			{
				numberOfHoursAtTwentyDollarRate = hoursWorked;
			}

			//if start time is before 11pm and end time after 11pm
			else
			{
				numberOfHoursAtFifteenDollarRate = elevenPM - startTime;
				numberOfHoursAtTwentyDollarRate = endTime - elevenPM;
			}

			paymentForFamilyA = numberOfHoursAtFifteenDollarRate*15 + numberOfHoursAtTwentyDollarRate*20;

			return paymentForFamilyA;
		}

		//FAMILY "B" RATE
		public int CalculateFamily_B_Rate(int startTime, int endTime, int hoursWorked)
		{

			// Family B pays $12 per hour before 10pm, $8 between 10 and 12, and $16 the rest of the night
			//int numberOfHoursAt12DollarRate = 0;
			int numberOfHoursAt8DollarRate = 0;
			int numberOfHoursAt16DollarRate = 0;
			const int tenPM = 5;
			const int midnight = 7;

			if (endTime <= tenPM)
			{
				numberOfHoursAt12DollarRate = endTime - startTime;
			}

			else if (startTime >= tenPM && endTime <= midnight)
			{
				numberOfHoursAt8DollarRate = endTime - startTime;
			}

			else if (startTime >= midnight)
			{
				numberOfHoursAt16DollarRate = hoursWorked;
			}

			else
			{
				numberOfHoursAt12DollarRate = tenPM - startTime;
				numberOfHoursAt8DollarRate = midnight - endTime;
			}

			int paymentForFamilyB = numberOfHoursAt12DollarRate * 12 + numberOfHoursAt8DollarRate * 8 + numberOfHoursAt16DollarRate * 16;
			return paymentForFamilyB;
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

			if (startTime >= ninePM)
			{
				numberOfHoursAt_15_DollarRate = hoursWorked;
			}

			else
			{
				numberOfHoursAt_21_DollarRate = ninePM - startTime;
				numberOfHoursAt_15_DollarRate = endTime - ninePM;
			}

			paymentForFamilyC = numberOfHoursAt_21_DollarRate * 21 + numberOfHoursAt_15_DollarRate * 15;

			return paymentForFamilyC;
		}
	}
}
