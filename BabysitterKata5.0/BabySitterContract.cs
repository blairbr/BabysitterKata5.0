using System.Collections.Generic;

namespace BabysitterKata5._0
{
	public class BabySitterContract //there would be one of these defined by each family each time a babysitter gets a job. or would there be an end time and start time outside of the rates.
	{
		public int BabysitterStartTime { get; set; }
		public int BabysitterEndTime { get; set; }

		public List<Rate> ListOfRatesInBabysitterContract { get; set; }
	}
}

//loop over each rate, for each rate if the start time /end time is in that range, figure out a new list of rates. 