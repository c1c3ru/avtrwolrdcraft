namespace UnityEngine;

public class WWWForm
{
	private static Byte[] dDash; //Field offset: 0x0
	private static Byte[] crlf; //Field offset: 0x8
	private static Byte[] contentTypeHeader; //Field offset: 0x10
	private static Byte[] dispositionHeader; //Field offset: 0x18
	private static Byte[] endQuote; //Field offset: 0x20
	private static Byte[] fileNameField; //Field offset: 0x28
	private static Byte[] ampersand; //Field offset: 0x30
	private static Byte[] equal; //Field offset: 0x38
	private List<Byte[]> formData; //Field offset: 0x10
	private List<String> fieldNames; //Field offset: 0x18
	private List<String> fileNames; //Field offset: 0x20
	private List<String> types; //Field offset: 0x28
	private Byte[] boundary; //Field offset: 0x30
	private bool containsFiles; //Field offset: 0x38

	public Byte[] data
	{
		 get { } //Length: 3564
	}

	internal static Encoding DefaultEncoding
	{
		internal get { } //Length: 8
	}

	public Dictionary<String, String> headers
	{
		 get { } //Length: 332
	}

	private static WWWForm() { }

	public WWWForm() { }

	public void AddField(string fieldName, string value) { }

	public void AddField(string fieldName, string value, Encoding e) { }

	public Byte[] get_data() { }

	internal static Encoding get_DefaultEncoding() { }

	public Dictionary<String, String> get_headers() { }

}

