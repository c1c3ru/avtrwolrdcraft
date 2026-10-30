namespace UnityEngine.Networking;

public class MultipartFormFileSection : IMultipartFormSection
{
	private string name; //Field offset: 0x10
	private Byte[] data; //Field offset: 0x18
	private string file; //Field offset: 0x20
	private string content; //Field offset: 0x28

	public override string contentType
	{
		 get { } //Length: 8
	}

	public override string fileName
	{
		 get { } //Length: 8
	}

	public override Byte[] sectionData
	{
		 get { } //Length: 8
	}

	public override string sectionName
	{
		 get { } //Length: 8
	}

	public MultipartFormFileSection(string name, Byte[] data, string fileName, string contentType) { }

	public override string get_contentType() { }

	public override string get_fileName() { }

	public override Byte[] get_sectionData() { }

	public override string get_sectionName() { }

	private void Init(string name, Byte[] data, string fileName, string contentType) { }

}

