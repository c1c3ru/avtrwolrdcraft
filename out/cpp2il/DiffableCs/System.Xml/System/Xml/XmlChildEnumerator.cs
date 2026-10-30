namespace System.Xml;

internal sealed class XmlChildEnumerator : IEnumerator
{
	internal XmlNode container; //Field offset: 0x10
	internal XmlNode child; //Field offset: 0x18
	internal bool isFirst; //Field offset: 0x20

	internal XmlNode Current
	{
		internal get { } //Length: 116
	}

	private override object System.Collections.IEnumerator.Current
	{
		private get { } //Length: 4
	}

	internal XmlChildEnumerator(XmlNode container) { }

	internal XmlNode get_Current() { }

	internal bool MoveNext() { }

	private override object System.Collections.IEnumerator.get_Current() { }

	private override bool System.Collections.IEnumerator.MoveNext() { }

	private override void System.Collections.IEnumerator.Reset() { }

}

