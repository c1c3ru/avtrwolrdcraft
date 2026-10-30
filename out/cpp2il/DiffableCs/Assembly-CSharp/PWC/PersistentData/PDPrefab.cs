namespace PWC.PersistentData;

[DisallowMultipleComponent]
public class PDPrefab : MonoBehaviour
{
	internal class SceneData
	{
		public List<String> sceneObjects; //Field offset: 0x10

		public SceneData() { }

	}

	[CompilerGenerated]
	private static Action<PDPrefab, Boolean> OnPrefabRuntimeSpawnAction; //Field offset: 0x0
	[SerializeField]
	private string _prefabGuid; //Field offset: 0x20
	[SerializeField]
	private PDSceneObject[] _sceneObjects; //Field offset: 0x28
	public bool isRuntimeSpawn; //Field offset: 0x30
	[CompilerGenerated]
	private Action<Boolean> OnRuntimeSpawnAction; //Field offset: 0x38
	[CompilerGenerated]
	private Action OnBeforeDestroyOnSceneLoadAction; //Field offset: 0x40

	public event Action OnBeforeDestroyOnSceneLoadAction
	{
		[CompilerGenerated]
		 add { } //Length: 156
		[CompilerGenerated]
		 remove { } //Length: 156
	}

	public static event Action<PDPrefab, Boolean> OnPrefabRuntimeSpawnAction
	{
		[CompilerGenerated]
		 add { } //Length: 204
		[CompilerGenerated]
		 remove { } //Length: 204
	}

	public event Action<Boolean> OnRuntimeSpawnAction
	{
		[CompilerGenerated]
		 add { } //Length: 176
		[CompilerGenerated]
		 remove { } //Length: 176
	}

	public string PrefabGuid
	{
		 get { } //Length: 8
	}

	public PDSceneObject[] SceneObjects
	{
		 get { } //Length: 8
	}

	public PDPrefab() { }

	[CompilerGenerated]
	public void add_OnBeforeDestroyOnSceneLoadAction(Action value) { }

	[CompilerGenerated]
	public static void add_OnPrefabRuntimeSpawnAction(Action<PDPrefab, Boolean> value) { }

	[CompilerGenerated]
	public void add_OnRuntimeSpawnAction(Action<Boolean> value) { }

	public void AddSceneObject(PDSceneObject sceneObject) { }

	public void ClearGuid() { }

	public void ClearSceneObjectGuids() { }

	private void EnsureAwake() { }

	public void EnsureSceneObjectGuids(bool considerMultiplayer = true) { }

	public string get_PrefabGuid() { }

	public PDSceneObject[] get_SceneObjects() { }

	public string GetMainSceneGuid() { }

	public PDSceneObject GetMainSceneObject() { }

	public string GetSceneObjectsData() { }

	public bool IsAboutToBeDestroyed() { }

	public void OnBeforeDestroyOnSceneLoad() { }

	public void OnRuntimeSpawn(bool multiplayer_ensureGuids) { }

	[CompilerGenerated]
	public void remove_OnBeforeDestroyOnSceneLoadAction(Action value) { }

	[CompilerGenerated]
	public static void remove_OnPrefabRuntimeSpawnAction(Action<PDPrefab, Boolean> value) { }

	[CompilerGenerated]
	public void remove_OnRuntimeSpawnAction(Action<Boolean> value) { }

	public void SetMainSceneGuid(string sceneGuid) { }

	public void SetSceneObjectsData(SceneData sceneData) { }

}

