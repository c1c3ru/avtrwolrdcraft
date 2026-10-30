namespace Game.Level.WaterSlide;

public class LevelSlideSpineHandler : MonoBehaviour
{
	[SerializeField]
	private SkeletonAnimation _skeletonAnimation; //Field offset: 0x20
	[SerializeField]
	private SortingGroup _sortingGroup; //Field offset: 0x28
	[SerializeField]
	private LevelDropArea _dropArea; //Field offset: 0x30
	[SerializeField]
	private bool _isSecret; //Field offset: 0x38
	[ConditionalField("_isSecret", True, True, (array) null)]
	[SerializeField]
	private PDPrefabReference _prizePDPrefabRefecrence; //Field offset: 0x40
	[ConditionalField("_isSecret", True, True, (array) null)]
	[SerializeField]
	private SkeletonAnimation _mainPlayerPath; //Field offset: 0x48
	[ConditionalField("_isSecret", True, True, (array) null)]
	[SerializeField]
	private ParticleSystem _poofParticles; //Field offset: 0x50
	[ConditionalField("_isSecret", True, True, (array) null)]
	[SerializeField]
	private float _distanceFromAvatar; //Field offset: 0x58
	[ConditionalField("_isSecret", True, True, (array) null)]
	[SerializeField]
	private UnityEvent _onItemSpawnAction; //Field offset: 0x60
	[SerializeField]
	private bool _isSceneEnding; //Field offset: 0x68
	[ConditionalField("_isSceneEnding", True, True, (array) null)]
	[SerializeField]
	private UnityEvent _onLevelLoadAction; //Field offset: 0x70
	[SerializeField]
	private GameSoundPlayer _gameSoundPlayer; //Field offset: 0x78
	private LevelItem _slideItem; //Field offset: 0x80

	public LevelSlideSpineHandler() { }

	[CompilerGenerated]
	private void <OnAnimationBegin>b__17_0() { }

	[CompilerGenerated]
	private void <SpawnItemOnSlide>b__19_0() { }

	private void Awake() { }

	protected LevelSpawn GetPrefabToSpawn() { }

	public SkeletonAnimation GetSkeletonAnimation() { }

	private void HandleSlideEvent(TrackEntry trackEntry, Event spineEvent) { }

	public void InitLevelItemOnSlide(LevelItem levelItem, out TrackEntry trackEntry) { }

	private void OnAnimationBegin(TrackEntry trackEntry) { }

	private void OnDestroy() { }

	private void ResetTransform() { }

	public void SpawnItemOnSlide(bool addPoof) { }

	private void SwitchSceneOnPathEnd(TrackEntry trackEntry) { }

}

