namespace Game.Level;

public abstract class LevelItemOnAvatarMouthHandlerBase : MonoBehaviour, ILevelSpawnDuringGameplay, IHasPersistentData, IRequirePDSceneObject
{
	[SerializeField]
	protected List<SpineType> _spineTypes; //Field offset: 0x20
	private bool _didOnReadyPostLoad; //Field offset: 0x28
	protected bool _isOnMouth; //Field offset: 0x29
	protected SpineType _currentHolderSpineType; //Field offset: 0x2C
	[CompilerGenerated]
	private LevelItem <LevelItem>k__BackingField; //Field offset: 0x30

	public LevelItem LevelItem
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 8
	}

	protected LevelItemOnAvatarMouthHandlerBase() { }

	protected override void Awake() { }

	private void EnsureOnReadyPostLoad() { }

	[CompilerGenerated]
	public LevelItem get_LevelItem() { }

	public override string GetOnMouthAnimationName(out bool isLoop) { }

	public override Dictionary<String, Object> GetPersistentData() { }

	public bool IsCompatibleWithMouthDropArea(SpineType spineType) { }

	private void OnBeginDrag(DragDropItemBase _, PointerEventData __) { }

	protected override void OnDestroy() { }

	private void OnLevelPostInit() { }

	protected abstract void OnReadyPostLoad() { }

	public override void OnSpawnDuringGameplay() { }

	[CompilerGenerated]
	protected void set_LevelItem(LevelItem value) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	public override void SetState(bool isOnMouth) { }

}

