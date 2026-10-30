namespace System.Runtime.Serialization;

public sealed class SafeSerializationEventArgs : EventArgs
{
	private StreamingContext m_streamingContext; //Field offset: 0x10
	private List<Object> m_serializedStates; //Field offset: 0x20

	internal IList<Object> SerializedStates
	{
		internal get { } //Length: 8
	}

	internal SafeSerializationEventArgs(StreamingContext streamingContext) { }

	internal SafeSerializationEventArgs() { }

	internal IList<Object> get_SerializedStates() { }

}

