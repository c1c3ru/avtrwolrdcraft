namespace PWC.Level;

public class LevelScreenCapturePDPrefabCameraItemHandler : MonoBehaviour
{
	[SerializeField]
	private PDPrefabReference _levelScreenCaptureHandlerReference; //Field offset: 0x20
	[SerializeField]
	private MeshRenderer _preview; //Field offset: 0x28
	private string _cameraGUID; //Field offset: 0x30
	private bool _isCasting; //Field offset: 0x38

	public LevelScreenCapturePDPrefabCameraItemHandler() { }

	[CompilerGenerated]
	private void <SyncView>b__10_0() { }

	private void Awake() { }

	private void LogError(string message) { }

	private void OnBeforeDestroyLevelItemHandler(LevelItem levelItem) { }

	private void OnDestroy() { }

	private void OnLevelPostInit() { }

	private void OnSpawnLevelItemDuringGameplayActionHandler(LevelItem levelItem) { }

	public void SyncView() { }

	private bool TryFindCameraInScene() { }

}

