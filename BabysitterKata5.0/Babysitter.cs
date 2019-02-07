using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabysitterKata5._0
{
    public class Babysitter
    {
		public bool StartTimeIsFivePmOrLater(int startTime)
		{
			return startTime > 0;
		}


		public int CalculateHoursWorked(int startTime, int endTime)
		{
			return endTime - startTime;
		}
    }
}
