namespace Game.Level.ContextualAnimation;

public class LevelCAToddlerBicycleItemHandler : LevelCAParentHandlerBase
{
	[SerializeField]
	private LevelCAWithSkinHelper _caWithSkinHelper; //Field offset: 0x80
	[SerializeField]
	private LevelBicycleAnimationItemHandler _bicycleItemHandler; //Field offset: 0x88
	[SerializeField]
	private List<Renderer> _renderersToHide; //Field offset: 0x90
	[SerializeField]
	private LevelDropArea _trainingWheelsDropArea; //Field offset: 0x98
	[SerializeField]
	private GameObject _lightGameObject; //Field offset: 0xA0
	[SerializeField]
	private int _skinIndex; //Field offset: 0xA8
	private LevelItem _levelItem; //Field offset: 0xB0
	private LevelDropArea _dropArea; //Field offset: 0xB8
	private BoneFollower _lightBoneFollower; //Field offset: 0xC0
	private Vector2 _frontLightLocalPosition; //Field offset: 0xC8
	private float _lastPointerXPosition; //Field offset: 0xD0
	private bool _isMovingBackward; //Field offset: 0xD4
	private HashSet<String> _excludedSkins; //Field offset: 0xD8
	private readonly List<LevelCAConfig> _configs; //Field offset: 0xE0

	public LevelCAToddlerBicycleItemHandler() { }

	protected virtual void Awake() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual string GetLockedAnimationName() { }

	public virtual SpineType GetSpineType() { }

	public virtual bool IsSingleCAInMenu() { }

	public virtual void OnAddedToTarget(ICATarget target) { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

	public virtual void OnAnimationEnd(ICATarget target, LevelCAConfig config) { }

	protected virtual void OnDestroy() { }

	private void OnItemPickUp(LevelItem _) { }

	public virtual void OnRemovedFromTarget(ICATarget target) { }

	private void OnSyncPosition(DragDropItemBase arg1, Vector2 arg2) { }

	private void OnTrainingWheelsDrop(LevelItem wheels) { }

	private void OnTrainingWheelsPickUp(LevelItem wheels) { }

	public virtual bool TryOverrideMainThumb(out Sprite sprite) { }

}

