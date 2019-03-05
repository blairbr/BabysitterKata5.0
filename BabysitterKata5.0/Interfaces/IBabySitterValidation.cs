namespace BabysitterKata5._0.Interfaces
{
	public interface IBabySitterValidation
	{
		bool ValidateUserInput(BabySitterContract babySitterContract);

		bool BabysitterStartTimeIsFivePmOrLater(int babysitterStartTime);

		bool BabysitterStartTimeIsBeforeBabysitterEndTime(int babysitterStartTime, int babysitterEndTime);

		bool BabysitterEndTimeIsFourAmOrEarlier(int endTime);
	}
}