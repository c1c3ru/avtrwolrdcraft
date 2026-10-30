namespace Unity.Properties;

[IsReadOnly]
internal struct PropertyMember : IMemberInfo
{
	internal readonly PropertyInfo m_PropertyInfo; //Field offset: 0x0
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private readonly string <Name>k__BackingField; //Field offset: 0x8

	public override bool IsReadOnly
	{
		 get { } //Length: 48
	}

	public override string Name
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	public override Type ValueType
	{
		 get { } //Length: 36
	}

	public PropertyMember(PropertyInfo propertyInfo) { }

	public override bool get_IsReadOnly() { }

	[CompilerGenerated]
	public override string get_Name() { }

	public override Type get_ValueType() { }

	public override IEnumerable<Attribute> GetCustomAttributes() { }

}

