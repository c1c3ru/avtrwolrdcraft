namespace Unity.Networking.QoS;

internal struct UcgQosServer
{
	internal string regionid; //Field offset: 0x0
	internal string ipv4; //Field offset: 0x8
	internal string ipv6; //Field offset: 0x10
	internal ushort port; //Field offset: 0x18
	[HideInInspector]
	internal DateTime BackoffUntilUtc; //Field offset: 0x20

	public virtual string ToString() { }

}

