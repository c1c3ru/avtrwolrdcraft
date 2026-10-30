namespace PWC.CarsMaker;

public class CarPartsIndex : ScriptableObject
{
	internal class CarPartEntry
	{
		public string SkinPath; //Field offset: 0x10
		public string ResourcePath; //Field offset: 0x18

		public CarPartEntry() { }

	}

	public const string RESOURCES_PATH = "CarsMaker/PartsIndex"; //Field offset: 0x0
	[SerializeField]
	private List<CarPartEntry> _entries; //Field offset: 0x18
	private Dictionary<String, String> _resourcePathsBySkinPath; //Field offset: 0x20

	public CarPartsIndex() { }

	public void GetSkinNamesInFolder(string folderPath, List<String> skinNames) { }

	public bool TryGetResourcePath(string skinPath, out string resourcePath) { }

}

