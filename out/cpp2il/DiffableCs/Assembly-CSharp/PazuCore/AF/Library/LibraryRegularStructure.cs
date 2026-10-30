namespace PazuCore.AF.Library;

public class LibraryRegularStructure : LibraryStructureBase
{
	internal class Featured
	{
		public List<Int32> games; //Field offset: 0x10
		public string buttonTextKey; //Field offset: 0x18
		public List<String> sortBy; //Field offset: 0x20
		public long rotationInterval; //Field offset: 0x28
		private List<SortType> _sortTypes; //Field offset: 0x30

		public Featured() { }

		public List<SortType> GetSortTypes() { }

	}

	internal class GameBundleWindow
	{
		public string buttonTextKey; //Field offset: 0x10
		public string buttonPlayTextKey; //Field offset: 0x18

		public GameBundleWindow() { }

	}

	internal class GameWindow
	{
		public string buttonTextKey; //Field offset: 0x10
		public string buttonPlayTextKey; //Field offset: 0x18
		public bool openAppStoreInApp; //Field offset: 0x20

		public GameWindow() { }

	}

	public Featured featured; //Field offset: 0x28
	public GameWindow gameWindow; //Field offset: 0x30
	public GameBundleWindow gameBundleWindow; //Field offset: 0x38

	public LibraryRegularStructure() { }

}

