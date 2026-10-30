namespace Game.Level;

public class LevelSecretItemByScreenCaptureListener : MonoBehaviour
{
	[SerializeField]
	private List<String> _requiredItemLabels; //Field offset: 0x20
	[SerializeField]
	private List<PDPrefabReference> _requiredItemPrefabs; //Field offset: 0x28
	[SerializeField]
	private List<GameObject> _requiredSceneObjects; //Field offset: 0x30
	[SerializeField]
	private bool _requireAll; //Field offset: 0x38
	[SerializeField]
	private bool _isOneTime; //Field offset: 0x39
	[SerializeField]
	private float _horizontalMargin; //Field offset: 0x3C
	[SerializeField]
	private bool _useRendererBoundsForSceneObjects; //Field offset: 0x40
	[SerializeField]
	private UnityEvent _onCaptureEvent; //Field offset: 0x48
	private bool _wasSolved; //Field offset: 0x50

	public LevelSecretItemByScreenCaptureListener() { }

	private void Awake() { }

	private bool IsItemInCapture(LevelItem levelItem, Bounds captureBounds) { }

	private bool IsLabelInCapture(string label, Bounds captureBounds) { }

	private bool IsPrefabGuidInCapture(PDPrefabReference prefabReference, Bounds captureBounds) { }

	private bool IsSceneObjectInCapture(GameObject sceneObject, Bounds captureBounds) { }

	private void OnDestroy() { }

	private void OnScreenCapture(LevelScreenCaptureCameraItemHandler levelScreenCaptureCameraItemHandler) { }

}

