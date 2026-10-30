namespace PWC.Level;

[DisallowMultipleComponent]
public class LevelItemOrientationHandler : MonoBehaviour, IHasPersistentData, IRequirePDSceneObject, IMultiplayer_PrepareForDrag
{
	[SerializeField]
	private GameObject _gameObject; //Field offset: 0x20
	[SerializeField]
	private SpriteRenderer _spriteRenderer; //Field offset: 0x28
	[SerializeField]
	private float _layAngle; //Field offset: 0x30
	[SerializeField]
	private float _standAngle; //Field offset: 0x34
	[SerializeField]
	private ItemOrientationType _orientationWhileDragging; //Field offset: 0x38
	[SerializeField]
	private bool _useCharacterHandAngle; //Field offset: 0x3C
	[SerializeField]
	private float _characterHandAngle; //Field offset: 0x40
	[SerializeField]
	private bool _useHangAreaAngle; //Field offset: 0x44
	[SerializeField]
	private float _hangAreaAngle; //Field offset: 0x48
	[SerializeField]
	private LevelDropArea _standDropArea; //Field offset: 0x50
	[SerializeField]
	private LevelDropArea _layDropArea; //Field offset: 0x58
	[SerializeField]
	private float _standBottomWidth; //Field offset: 0x60
	[SerializeField]
	private float _layBottomWidth; //Field offset: 0x64
	[SerializeField]
	private bool _shouldForceDropAreaOrientationOnLand; //Field offset: 0x68
	[SerializeField]
	private ItemOrientationType _orientationWhileOnDropArea; //Field offset: 0x6C
	[SerializeField]
	private bool _allowRotationWithItemsOnSelf; //Field offset: 0x70
	[SerializeField]
	private bool _enableMatchingDropAreaInHand; //Field offset: 0x71
	private ItemOrientationType _currentOrientationType; //Field offset: 0x74
	private Vector2 _standExtent; //Field offset: 0x78
	private Vector2 _layExtent; //Field offset: 0x80
	private LevelItem _levelItem; //Field offset: 0x88

	public bool AllowRotationWithItemsOnSelf
	{
		 get { } //Length: 8
	}

	public ItemOrientationType CurrentOrientationType
	{
		 get { } //Length: 8
	}

	public ItemOrientationType OrientationWhileDragging
	{
		 get { } //Length: 8
	}

	public ItemOrientationType OrientationWhileOnDropArea
	{
		 get { } //Length: 8
	}

	public GameObject OrientedObject
	{
		 get { } //Length: 8
	}

	public bool ShouldForceDropAreaOrientationOnLand
	{
		 get { } //Length: 8
	}

	public LevelItemOrientationHandler() { }

	[CompilerGenerated]
	private void <SetPersistentData>g__Set|53_0(float yPosition, float angle) { }

	private void Awake() { }

	public void ForceLay(bool snap = false) { }

	public void ForceStand(bool snap = false) { }

	public bool get_AllowRotationWithItemsOnSelf() { }

	public ItemOrientationType get_CurrentOrientationType() { }

	public ItemOrientationType get_OrientationWhileDragging() { }

	public ItemOrientationType get_OrientationWhileOnDropArea() { }

	public GameObject get_OrientedObject() { }

	public bool get_ShouldForceDropAreaOrientationOnLand() { }

	public float GetBottomWidthForOrientation(ItemOrientationType itemOrientationType) { }

	public override Dictionary<String, Object> GetPersistentData() { }

	public Vector2 GetSizeForOrientation(ItemOrientationType itemOrientationType) { }

	private void Init() { }

	public void OnBeginDrag() { }

	public void OnHangOnArea() { }

	public void OnPutInCharacterHand() { }

	private void PlayLayTween() { }

	private void PlayStandTween() { }

	private void PrepareForDrag() { }

	private override void PWC.Multiplayer.IMultiplayer_PrepareForDrag.Multiplayer_PrepareForDrag() { }

	public void SetCustomPosition(Vector2 position, float duration = 0) { }

	public void SetCustomRotation(float angle, float duration = 0) { }

	public void SetExtents(Vector2 standExtent, Vector2 layExtent) { }

	public void SetOrientation(ItemOrientationType itemOrientationType, bool snap = false, bool force = false) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	private void SnapTo(float yPosition, float angle) { }

	private void SnapToLay() { }

	private void SnapToStand() { }

}

