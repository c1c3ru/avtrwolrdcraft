namespace Unity.Services.Wire.Internal;

public class AlreadySubscribedException : RequestFailedException
{

	public AlreadySubscribedException(string alias) { }

}

