namespace Unity.Services.Authentication;

internal interface IJwtDecoder
{

	public T Decode(string token) { }

}

