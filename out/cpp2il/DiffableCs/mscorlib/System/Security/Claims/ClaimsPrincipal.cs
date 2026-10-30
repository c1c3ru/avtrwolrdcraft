namespace System.Security.Claims;

[ComVisible(True)]
public class ClaimsPrincipal : IPrincipal
{
	private static Func<IEnumerable`1<ClaimsIdentity>, ClaimsIdentity> s_identitySelector; //Field offset: 0x0
	private static Func<ClaimsPrincipal> s_principalSelector; //Field offset: 0x8
	[OptionalField(VersionAdded = 2)]
	private string m_version; //Field offset: 0x10
	[OptionalField(VersionAdded = 2)]
	private string m_serializedClaimsIdentities; //Field offset: 0x18
	private List<ClaimsIdentity> m_identities; //Field offset: 0x20

	public static Func<ClaimsPrincipal> ClaimsPrincipalSelector
	{
		 get { } //Length: 88
	}

	public override IIdentity Identity
	{
		 get { } //Length: 176
	}

	private static ClaimsPrincipal() { }

	public ClaimsPrincipal() { }

	protected ClaimsPrincipal(SerializationInfo info, StreamingContext context) { }

	private void Deserialize(SerializationInfo info, StreamingContext context) { }

	private void DeserializeIdentities(string identities) { }

	public static Func<ClaimsPrincipal> get_ClaimsPrincipalSelector() { }

	public override IIdentity get_Identity() { }

	[OnDeserialized]
	private void OnDeserializedMethod(StreamingContext context) { }

	[OnSerializing]
	private void OnSerializingMethod(StreamingContext context) { }

	private static ClaimsIdentity SelectPrimaryIdentity(IEnumerable<ClaimsIdentity> identities) { }

	private string SerializeIdentities() { }

}

