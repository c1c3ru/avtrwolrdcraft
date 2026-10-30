namespace PWC.CarsMaker;

public static class CarDefaultCategoryColors
{
	private class TextAssetData
	{
		public Dictionary<String, List`1<String>> colors; //Field offset: 0x10

		public TextAssetData() { }

	}

	private const string FOLDER_PATH = "CarsMaker/DefaultCategoryColors"; //Field offset: 0x0
	private static Dictionary<CarCategoryType, Color[]> _colorsByCategory; //Field offset: 0x0

	private static void EnsureData() { }

	public static bool TryGetColors(CarCategoryType category, out Color[] colors) { }

}

