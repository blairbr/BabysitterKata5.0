namespace BabysitterKata5._0
{
	public interface IValidationService
	{
		void ValidateUserInput(int rateStartTime, int rateEndTime);

		bool rateStartTimeIsFivePmOrLater(int rateStartTime);

		bool rateEndTimeIsFourAmOrEarlier(int rateEndTime);

		bool rateStartTimeIsBeforerateEndTime(int rateStartTime, int rateEndTime);
	}
}