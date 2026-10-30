namespace System.Reflection;

public class ParameterInfo : ICustomAttributeProvider, IObjectReference, _ParameterInfo
{
	private const int MetadataToken_ParamDef = 134217728; //Field offset: 0x0
	protected ParameterAttributes AttrsImpl; //Field offset: 0x10
	protected Type ClassImpl; //Field offset: 0x18
	protected object DefaultValueImpl; //Field offset: 0x20
	protected MemberInfo MemberImpl; //Field offset: 0x28
	protected string NameImpl; //Field offset: 0x30
	protected int PositionImpl; //Field offset: 0x38

	public override ParameterAttributes Attributes
	{
		 get { } //Length: 8
	}

	public override object DefaultValue
	{
		 get { } //Length: 40
	}

	public bool IsIn
	{
		 get { } //Length: 28
	}

	public bool IsOptional
	{
		 get { } //Length: 28
	}

	public bool IsOut
	{
		 get { } //Length: 28
	}

	public override MemberInfo Member
	{
		 get { } //Length: 8
	}

	public override string Name
	{
		 get { } //Length: 8
	}

	public override Type ParameterType
	{
		 get { } //Length: 8
	}

	public override int Position
	{
		 get { } //Length: 8
	}

	protected ParameterInfo() { }

	public override ParameterAttributes get_Attributes() { }

	public override object get_DefaultValue() { }

	public bool get_IsIn() { }

	public bool get_IsOptional() { }

	public bool get_IsOut() { }

	public override MemberInfo get_Member() { }

	public override string get_Name() { }

	public override Type get_ParameterType() { }

	public override int get_Position() { }

	public override Object[] GetCustomAttributes(bool inherit) { }

	public override Object[] GetCustomAttributes(Type attributeType, bool inherit) { }

	public override object GetRealObject(StreamingContext context) { }

	public override bool IsDefined(Type attributeType, bool inherit) { }

	public virtual string ToString() { }

}

