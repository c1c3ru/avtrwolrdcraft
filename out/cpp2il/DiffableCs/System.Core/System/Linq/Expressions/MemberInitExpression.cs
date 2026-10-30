namespace System.Linq.Expressions;

[DebuggerTypeProxy(typeof(MemberInitExpressionProxy))]
public sealed class MemberInitExpression : Expression
{
	[CompilerGenerated]
	private readonly NewExpression <NewExpression>k__BackingField; //Field offset: 0x10
	[CompilerGenerated]
	private readonly ReadOnlyCollection<MemberBinding> <Bindings>k__BackingField; //Field offset: 0x18

	public ReadOnlyCollection<MemberBinding> Bindings
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	public NewExpression NewExpression
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	[CompilerGenerated]
	public ReadOnlyCollection<MemberBinding> get_Bindings() { }

	[CompilerGenerated]
	public NewExpression get_NewExpression() { }

}

