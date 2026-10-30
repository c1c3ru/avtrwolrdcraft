namespace PazuCore.Analytics;

public class SceneMap
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass3_0
	{
		public string gameSceneName; //Field offset: 0x10

		public <>c__DisplayClass3_0() { }

		internal bool <GetSceneName>b__0(Item x) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass4_0
	{
		public SceneName sceneName; //Field offset: 0x10

		public <>c__DisplayClass4_0() { }

		internal bool <GetFirstGameSceneName>b__0(Item x) { }

	}

	internal class Item
	{
		public SceneName sceneName; //Field offset: 0x10
		public List<String> gameSceneNames; //Field offset: 0x18

		public Item() { }

	}

	[SerializeField]
	private List<Item> _items; //Field offset: 0x10

	public SceneMap() { }

	public string GetFirstGameSceneName(SceneName sceneName) { }

	public Nullable<SceneName> GetSceneName(string gameSceneName) { }

}

