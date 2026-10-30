namespace PWC.Level;

public class LevelScreenshotManager : MonoBehaviour
{
	public const string TEXTURE_SUFFIX = "_screenshot"; //Field offset: 0x0
	[SerializeField]
	private Camera _camera; //Field offset: 0x20
	[SerializeField]
	private RectTransform _screenshotArea; //Field offset: 0x28

	public LevelScreenshotManager() { }

	private void Awake() { }

	private void OnBeforeSceneLoad() { }

	private void OnDestroy() { }

	private void TakeScreenshot() { }

	[ContextMenu("Take Screenshot")]
	private void WaitForTakeScreenshot() { }

}

