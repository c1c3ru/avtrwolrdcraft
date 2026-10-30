namespace System.Linq.Expressions;

internal class AssignBinaryExpression : BinaryExpression
{

	public virtual ExpressionType NodeType
	{
		 get { } //Length: 8
	}

	public virtual Type Type
	{
		 get { } //Length: 32
	}

	internal AssignBinaryExpression(Expression left, Expression right) { }

	public virtual ExpressionType get_NodeType() { }

	public virtual Type get_Type() { }

}

