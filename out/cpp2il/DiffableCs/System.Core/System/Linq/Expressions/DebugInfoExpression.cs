namespace System.Linq.Expressions;

[DebuggerTypeProxy(typeof(DebugInfoExpressionProxy))]
public class DebugInfoExpression : Expression
{
	[CompilerGenerated]
	private readonly SymbolDocumentInfo <Document>k__BackingField; //Field offset: 0x10

	public SymbolDocumentInfo Document
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	[ExcludeFromCodeCoverage]
	public override int EndLine
	{
		 get { } //Length: 40
	}

	[ExcludeFromCodeCoverage]
	public override bool IsClear
	{
		 get { } //Length: 40
	}

	[ExcludeFromCodeCoverage]
	public override int StartLine
	{
		 get { } //Length: 40
	}

	[CompilerGenerated]
	public SymbolDocumentInfo get_Document() { }

	public override int get_EndLine() { }

	public override bool get_IsClear() { }

	public override int get_StartLine() { }

}

