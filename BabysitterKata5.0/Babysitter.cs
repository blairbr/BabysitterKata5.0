using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabysitterKata5._0
{
    public class Babysitter
    {
		public int CalculateHoursWorked(int StartTime, int EndTime)
		{
			return EndTime - StartTime;
		}
    }
}
