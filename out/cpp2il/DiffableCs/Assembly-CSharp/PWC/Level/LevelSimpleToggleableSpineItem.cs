namespace PWC.Level;

public class LevelSimpleToggleableSpineItem : LevelItem
{
	[SerializeField]
	protected GameSoundPlayer _soundPlayer; //Field offset: 0x348
	[SerializeField]
	protected string _soundName; //Field offset: 0x350
	[SerializeField]
	protected float _volume; //Field offset: 0x358
	[SerializeField]
	private bool _isRandom; //Field offset: 0x35C
	[SerializeField]
	private SkeletonAnimation _skeletonAnimation; //Field offset: 0x360
	[SerializeField]
	[SpineAnimation(null, "_skeletonAnimation", True, False, False)]
	private String[] _idleAnimationsNames; //Field offset: 0x368
	[SerializeField]
	[SpineAnimation(null, "_skeletonAnimation", True, False, False)]
	private String[] _transitionAnimationsNames; //Field offset: 0x370
	[SerializeField]
	private GameObject[] _gameObjects; //Field offset: 0x378
	protected int _currentIndex; //Field offset: 0x380

	public LevelSimpleToggleableSpineItem() { }

	protected virtual void Awake() { }

	public virtual Dictionary<String, Object> GetPersistentData() { }

	protected virtual void OnPointerClickInternal(PointerEventData eventData) { }

	protected override void PlaySound() { }

	private void SetAnimation(int animationIndex, bool snap) { }

	public virtual void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

}

