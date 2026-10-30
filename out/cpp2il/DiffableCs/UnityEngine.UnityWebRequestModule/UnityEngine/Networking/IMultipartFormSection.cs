namespace UnityEngine.Networking;

public interface IMultipartFormSection
{

	public string contentType
	{
		 get { } //Length: 0
	}

	public string fileName
	{
		 get { } //Length: 0
	}

	public Byte[] sectionData
	{
		 get { } //Length: 0
	}

	public string sectionName
	{
		 get { } //Length: 0
	}

	public string get_contentType() { }

	public string get_fileName() { }

	public Byte[] get_sectionData() { }

	public string get_sectionName() { }

}

