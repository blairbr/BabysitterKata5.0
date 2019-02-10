using System.Collections.Generic;

namespace BabysitterKata5._0
{
	public class BabySitterContract
	{
		public int BabysitterStartTime { get; set; }
		public int BabysitterEndTime { get; set; }

		public List<Rate> ListOfRatesInBabysitterContract { get; set; }
	}
}