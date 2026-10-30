namespace System.Runtime.Serialization;

[AttributeUsage(AttributeTargets::Field (256), Inherited = False, AllowMultiple = False)]
public sealed class EnumMemberAttribute : Attribute
{
	private string value; //Field offset: 0x10
	private bool isValueSetExplicitly; //Field offset: 0x18

	public string Value
	{
		 get { } //Length: 8
		 set { } //Length: 36
	}

	public EnumMemberAttribute() { }

	public string get_Value() { }

	public void set_Value(string value) { }

}

