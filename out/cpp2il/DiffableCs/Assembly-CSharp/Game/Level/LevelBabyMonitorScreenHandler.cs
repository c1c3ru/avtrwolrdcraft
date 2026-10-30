namespace Game.Level;

public class LevelBabyMonitorScreenHandler : MonoBehaviour, IHasPersistentData, IRequirePDSceneObject, ILevelSpawnDuringGameplay
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Func<LevelBabyMonitorCameraHandler, Boolean> <>9__22_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal bool <OnReadyPostLoad>b__22_0(LevelBabyMonitorCameraHandler bmc) { }

	}

	public static HashSet<LevelBabyMonitorScreenHandler> BabyMonitorScreens; //Field offset: 0x0
	[SerializeField]
	private MeshRenderer _preview; //Field offset: 0x20
	private LevelBabyMonitorCameraHandler _babyMonitorCameraHandler; //Field offset: 0x28
	private PDSceneObject _sceneObject; //Field offset: 0x30
	private string _texturePath; //Field offset: 0x38
	private bool _didOnReadyPostLoad; //Field offset: 0x40
	private LevelItem _levelItem; //Field offset: 0x48
	private bool _isOnFlipedCharacter; //Field offset: 0x50

	public LevelBabyMonitorCameraHandler BabyMonitorCameraHandler
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	private static LevelBabyMonitorScreenHandler() { }

	public LevelBabyMonitorScreenHandler() { }

	private void Awake() { }

	private void EnsureFolder() { }

	private void EnsureOnReadyPostLoad() { }

	public LevelBabyMonitorCameraHandler get_BabyMonitorCameraHandler() { }

	private string GetImagesDirectory() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	public MeshRenderer GetPreview() { }

	private string GetTexturePath() { }

	private void OnDestroy() { }

	private void OnEnable() { }

	protected void OnLevelPostInit() { }

	private void OnPlacedOnCharacter(ILevelAvatar avatar, ItemOnAvatarType type) { }

	private void OnReadyPostLoad() { }

	private void OnRemovedFromCharacter(ILevelAvatar avatar) { }

	public override void OnSpawnDuringGameplay() { }

	private void OnSyncCharacterIsFlippedState(LevelItem levelItem, bool isFlipped) { }

	private void OnSyncIsFlippedState(LevelItem levelItem, bool isFlipped) { }

	public void SaveTextureToDiskIfNeeded() { }

	public void set_BabyMonitorCameraHandler(LevelBabyMonitorCameraHandler value) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	public void SetTexture(Texture2D texture, string spritePath) { }

}

