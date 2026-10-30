namespace Unity.Services.Authentication.Shared;

internal interface IApiAccessor
{

	public IApiConfiguration Configuration
	{
		 get { } //Length: 0
	}

	public IApiConfiguration get_Configuration() { }

	public string GetBasePath() { }

}

