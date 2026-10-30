namespace Unity.Services.Authentication.PlayerAccounts;

internal class DateTimeWrapper : IDateTimeWrapper
{
	private static readonly DateTime k_UnixEpoch; //Field offset: 0x0

	public override DateTime UtcNow
	{
		 get { } //Length: 80
	}

	private static DateTimeWrapper() { }

	public DateTimeWrapper() { }

	public override DateTime get_UtcNow() { }

	public override double SecondsSinceUnixEpoch() { }

}

