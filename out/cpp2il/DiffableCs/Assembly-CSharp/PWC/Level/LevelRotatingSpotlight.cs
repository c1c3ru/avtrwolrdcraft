namespace PWC.Level;

public class LevelRotatingSpotlight : InteractableItem, IBeginDragHandler, IEventSystemHandler, IDragHandler, IEndDragHandler, IHasPersistentData, IRequirePDSceneObject
{
	[SerializeField]
	private bool _isInverted; //Field offset: 0x39
	[SerializeField]
	private float _minRotation; //Field offset: 0x3C
	[SerializeField]
	private float _maxRotation; //Field offset: 0x40
	[SerializeField]
	private Transform _rotatingObject; //Field offset: 0x48
	[SerializeField]
	private CShape _spotPlaneCShape; //Field offset: 0x50
	[SerializeField]
	private Transform _spot; //Field offset: 0x58
	[SerializeField]
	private LightSource _lightSource; //Field offset: 0x60
	private Camera _camera; //Field offset: 0x68
	private int _pointerId; //Field offset: 0x70
	private Vector3 _pressPosition; //Field offset: 0x74
	private float _pressRotation; //Field offset: 0x80

	public LevelRotatingSpotlight() { }

	protected virtual void Awake() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	private Vector2 GetPointerPosition(Vector3 screenPosition) { }

	public override void OnBeginDrag(PointerEventData eventData) { }

	public override void OnDrag(PointerEventData eventData) { }

	public override void OnEndDrag(PointerEventData eventData) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	private void SyncSpotAndLightSource() { }

}

