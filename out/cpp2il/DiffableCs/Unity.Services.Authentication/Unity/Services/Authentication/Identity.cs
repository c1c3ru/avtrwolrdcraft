namespace Unity.Services.Authentication;

public sealed class Identity
{
	public string TypeId; //Field offset: 0x10
	public string UserId; //Field offset: 0x18

	internal Identity(ExternalIdentity externalIdentity) { }

}

