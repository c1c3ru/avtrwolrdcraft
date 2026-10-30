namespace System.Text;

[IsByRefLike]
[Obsolete("Types with embedded references are not supported in this version of your compiler.", True)]
internal struct ValueUtf8Converter
{
	private Byte[] _arrayToReturnToPool; //Field offset: 0x0
	private Span<Byte> _bytes; //Field offset: 0x8

	public ValueUtf8Converter(Span<Byte> initialBuffer) { }

	public Span<Byte> ConvertAndTerminateString(ReadOnlySpan<Char> value) { }

	public void Dispose() { }

}

