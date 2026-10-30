namespace Unity.Services.Authentication;

internal interface IAuthenticationSettings
{

	public int AccessTokenExpiryBuffer
	{
		 get { } //Length: 0
	}

	public int AccessTokenRefreshBuffer
	{
		 get { } //Length: 0
	}

	public int CodeConfirmationAttempts
	{
		 get { } //Length: 0
	}

	public int CodeConfirmationDelay
	{
		 get { } //Length: 0
	}

	public int RefreshAttemptFrequency
	{
		 get { } //Length: 0
	}

	public int get_AccessTokenExpiryBuffer() { }

	public int get_AccessTokenRefreshBuffer() { }

	public int get_CodeConfirmationAttempts() { }

	public int get_CodeConfirmationDelay() { }

	public int get_RefreshAttemptFrequency() { }

}

