namespace Unity.Services.Authentication.PlayerAccounts;

internal interface IDateTimeWrapper
{

	public DateTime UtcNow
	{
		 get { } //Length: 0
	}

	public DateTime get_UtcNow() { }

	public double SecondsSinceUnixEpoch() { }

}

