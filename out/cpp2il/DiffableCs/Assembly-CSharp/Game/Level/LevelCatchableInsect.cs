namespace Game.Level;

public class LevelCatchableInsect : LevelItem, ILevelConsumer
{
	[CompilerGenerated]
	private bool <IsInNet>k__BackingField; //Field offset: 0x342
	[SerializeField]
	private float _flightYPosition; //Field offset: 0x344
	private Vector3[] _movePoints; //Field offset: 0x348
	private int _moveIndex; //Field offset: 0x350

	public private bool IsInNet
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 12
	}

	public LevelCatchableInsect() { }

	[CompilerGenerated]
	private void <AnimateToFlightHeight>b__18_0() { }

	private void AnimateToFlightHeight() { }

	public void AnimateToNet(Transform catchPoint) { }

	protected virtual void Awake() { }

	[CompilerGenerated]
	public bool get_IsInNet() { }

	public override ILevelEntity GetEntity() { }

	public override GameShape GetGameShape() { }

	public virtual Dictionary<String, Object> GetPersistentData() { }

	public override int GetSortPriority() { }

	public override Transform GetTransform() { }

	protected virtual void OnBeginDragInternal(PointerEventData eventData) { }

	protected virtual void OnDisable() { }

	protected virtual void OnEnable() { }

	protected virtual void OnLevelPostInit() { }

	public virtual bool OverrideBasicDropBehavior() { }

	[CompilerGenerated]
	private void set_IsInNet(bool value) { }

	public virtual void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

}

