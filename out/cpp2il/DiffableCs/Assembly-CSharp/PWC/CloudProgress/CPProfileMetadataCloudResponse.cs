namespace PWC.CloudProgress;

public class CPProfileMetadataCloudResponse : Response
{
	internal class ProfileData
	{
		public bool hasData; //Field offset: 0x10
		public long lastSaveDate; //Field offset: 0x18
		public Dictionary<String, String> lastSaveState; //Field offset: 0x20

		public ProfileData() { }

	}

	public readonly ProfileData profileData; //Field offset: 0x58

	public CPProfileMetadataCloudResponse(string responseText) { }

}

