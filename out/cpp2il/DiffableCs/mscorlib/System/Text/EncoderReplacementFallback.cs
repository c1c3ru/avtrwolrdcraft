namespace System.Text;

public sealed class EncoderReplacementFallback : EncoderFallback, ISerializable
{
	private string _strDefault; //Field offset: 0x10

	public string DefaultString
	{
		 get { } //Length: 8
	}

	public virtual int MaxCharCount
	{
		 get { } //Length: 28
	}

	public EncoderReplacementFallback() { }

	internal EncoderReplacementFallback(SerializationInfo info, StreamingContext context) { }

	public EncoderReplacementFallback(string replacement) { }

	public virtual EncoderFallbackBuffer CreateFallbackBuffer() { }

	public virtual bool Equals(object value) { }

	public string get_DefaultString() { }

	public virtual int get_MaxCharCount() { }

	public virtual int GetHashCode() { }

	private override void System.Runtime.Serialization.ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) { }

}

