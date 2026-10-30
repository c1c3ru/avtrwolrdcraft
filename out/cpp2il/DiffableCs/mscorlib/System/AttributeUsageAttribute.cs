namespace System;

[AttributeUsage(AttributeTargets::Class (4), Inherited = True)]
public sealed class AttributeUsageAttribute : Attribute
{
	internal static AttributeUsageAttribute Default; //Field offset: 0x0
	private AttributeTargets _attributeTarget; //Field offset: 0x10
	private bool _allowMultiple; //Field offset: 0x14
	private bool _inherited; //Field offset: 0x15

	public bool AllowMultiple
	{
		 get { } //Length: 8
		 set { } //Length: 12
	}

	public bool Inherited
	{
		 get { } //Length: 8
		 set { } //Length: 12
	}

	private static AttributeUsageAttribute() { }

	public AttributeUsageAttribute(AttributeTargets validOn) { }

	public bool get_AllowMultiple() { }

	public bool get_Inherited() { }

	public void set_AllowMultiple(bool value) { }

	public void set_Inherited(bool value) { }

}

