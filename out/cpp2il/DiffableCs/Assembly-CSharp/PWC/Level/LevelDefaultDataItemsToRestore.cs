namespace PWC.Level;

public static class LevelDefaultDataItemsToRestore
{
	internal class State
	{
		public string sceneName; //Field offset: 0x10
		public List<String> sceneGuids; //Field offset: 0x18
		[CompilerGenerated]
		private bool <IsDirty>k__BackingField; //Field offset: 0x20

		public bool IsDirty
		{
			[CompilerGenerated]
			 get { } //Length: 8
			[CompilerGenerated]
			 set { } //Length: 12
		}

		public State() { }

		[CompilerGenerated]
		public bool get_IsDirty() { }

		[CompilerGenerated]
		public void set_IsDirty(bool value) { }

	}

	private static readonly Dictionary<String, State> _states; //Field offset: 0x0

	private static LevelDefaultDataItemsToRestore() { }

	public static void AddItem(string sceneName, string sceneGuid) { }

	public static void ClearState(string sceneName) { }

	public static void DeleteAllData() { }

	private static string GetFolderName() { }

	private static string GetStateFilePath(State state) { }

	public static void SaveDirtyData() { }

	private static void SaveToDisk(State state) { }

	public static bool TryGetSceneGuids(string sceneName, out HashSet<String>& sceneGuids) { }

}

