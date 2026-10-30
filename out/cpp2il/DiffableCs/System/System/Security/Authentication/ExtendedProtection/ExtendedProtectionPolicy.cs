namespace System.Security.Authentication.ExtendedProtection;

[MonoTODO]
[TypeConverter(typeof(ExtendedProtectionPolicyTypeConverter))]
public class ExtendedProtectionPolicy : ISerializable
{

	[MonoTODO("Not implemented.")]
	public ExtendedProtectionPolicy(PolicyEnforcement policyEnforcement) { }

	protected ExtendedProtectionPolicy(SerializationInfo info, StreamingContext context) { }

	private override void System.Runtime.Serialization.ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) { }

	[MonoTODO]
	public virtual string ToString() { }

}

