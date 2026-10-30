namespace System.Linq.Expressions;

[DebuggerTypeProxy(typeof(ParameterExpressionProxy))]
public class ParameterExpression : Expression
{
	[CompilerGenerated]
	private readonly string <Name>k__BackingField; //Field offset: 0x10

	public bool IsByRef
	{
		 get { } //Length: 12
	}

	public string Name
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	public virtual ExpressionType NodeType
	{
		 get { } //Length: 8
	}

	public virtual Type Type
	{
		 get { } //Length: 108
	}

	internal ParameterExpression(string name) { }

	protected private virtual Expression Accept(ExpressionVisitor visitor) { }

	public bool get_IsByRef() { }

	[CompilerGenerated]
	public string get_Name() { }

	public virtual ExpressionType get_NodeType() { }

	public virtual Type get_Type() { }

	internal override bool GetIsByRef() { }

	internal static ParameterExpression Make(Type type, string name, bool isByRef) { }

}

