namespace LipingShare.LCLib.Asn1Processor;

internal class Oid
{
	private static StringDictionary oidDictionary; //Field offset: 0x0

	public Oid() { }

	public string Decode(Byte[] data) { }

	public override string Decode(Stream bt) { }

	protected int DecodeValue(Stream bt, ref ulong v) { }

	public Byte[] Encode(string oidStr) { }

	public override void Encode(Stream bt, string oidStr) { }

	protected void EncodeValue(Stream bt, ulong v) { }

	public string GetOidName(string inOidStr) { }

}

