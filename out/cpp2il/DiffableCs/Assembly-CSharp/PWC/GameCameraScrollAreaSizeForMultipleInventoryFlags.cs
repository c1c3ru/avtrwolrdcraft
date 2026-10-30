namespace PWC;

public class GameCameraScrollAreaSizeForMultipleInventoryFlags : InventoryFlagDependedElement
{
	[SerializeField]
	private LevelCamera _levelCamera; //Field offset: 0x20
	[SerializeField]
	private List<CameraAreaData> _cameraAreaData; //Field offset: 0x28

	public GameCameraScrollAreaSizeForMultipleInventoryFlags() { }

	protected virtual void Awake() { }

	public virtual bool ContainFlagType(InventoryFlagType type) { }

	private void OnBeforeSetBoundsCall(RectTransform area) { }

	protected virtual void OnDestroy() { }

}

