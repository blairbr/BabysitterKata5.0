namespace BabysitterKata5._0
{
	public interface IValidationService
	{
		void ValidateUserInput(int startTime, int endTime);

		bool StartTimeIsFivePmOrLater(int startTime);

		bool EndTimeIsFourAmOrEarlier(int endTime);

		bool StartTimeIsBeforeEndTime(int startTime, int endTime);
	}
}