namespace Unity.Services.Wire.Internal;

public class ChannelChangedException : RequestFailedException
{

	public ChannelChangedException(string newAlias, string oldAlias) { }

}

