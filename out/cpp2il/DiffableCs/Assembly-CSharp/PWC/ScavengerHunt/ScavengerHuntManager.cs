namespace PWC.ScavengerHunt;

public class ScavengerHuntManager : MonoBehaviour
{
	[CompilerGenerated]
	private static ScavengerHuntManager <Instance>k__BackingField; //Field offset: 0x0
	private readonly Dictionary<ScavengerHuntType, ScavengerHuntTypeHandler> _handlers; //Field offset: 0x20

	public private static ScavengerHuntManager Instance
	{
		[CompilerGenerated]
		 get { } //Length: 72
		[CompilerGenerated]
		private set { } //Length: 88
	}

	public ScavengerHuntManager() { }

	private void Awake() { }

	public void ClearAllData() { }

	[CompilerGenerated]
	public static ScavengerHuntManager get_Instance() { }

	public static ScavengerHuntTypeData[] GetAllTypeDataItems() { }

	private void Init() { }

	private void OnActiveSceneChanged(Scene fromScene, Scene toScene) { }

	private void OnBeforeDestroyLevelItem(LevelItem levelItem) { }

	private void OnDestroy() { }

	private void OnResetWorldData() { }

	private void SaveProgress(Scene scene) { }

	[CompilerGenerated]
	private static void set_Instance(ScavengerHuntManager value) { }

	private void Start() { }

	public bool TryGetHandler(ScavengerHuntType type, out ScavengerHuntTypeHandler handler) { }

}

