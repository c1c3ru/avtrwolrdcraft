namespace System.Linq.Expressions;

internal sealed class CoalesceConversionBinaryExpression : BinaryExpression
{
	private readonly LambdaExpression _conversion; //Field offset: 0x20

	public virtual ExpressionType NodeType
	{
		 get { } //Length: 8
	}

	public virtual Type Type
	{
		 get { } //Length: 32
	}

	internal CoalesceConversionBinaryExpression(Expression left, Expression right, LambdaExpression conversion) { }

	public virtual ExpressionType get_NodeType() { }

	public virtual Type get_Type() { }

	internal virtual LambdaExpression GetConversion() { }

}

