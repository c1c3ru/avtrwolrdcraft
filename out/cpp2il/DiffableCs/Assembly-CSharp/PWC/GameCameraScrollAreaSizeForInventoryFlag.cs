namespace PWC;

public class GameCameraScrollAreaSizeForInventoryFlag : InventoryFlagDependedElement
{
	[SerializeField]
	private LevelCamera _levelCamera; //Field offset: 0x20
	[SerializeField]
	private InventoryFlagType _requiredFlagType; //Field offset: 0x28
	[SerializeField]
	private float _noFlagWidth; //Field offset: 0x2C

	public GameCameraScrollAreaSizeForInventoryFlag() { }

	protected virtual void Awake() { }

	public virtual bool ContainFlagType(InventoryFlagType type) { }

	private void OnBeforeSetBoundsCall(RectTransform area) { }

	protected virtual void OnDestroy() { }

}

