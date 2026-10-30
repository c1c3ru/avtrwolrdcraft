namespace Game.Level.ContextualAnimation;

public class LevelCAAquariumDropAreaHandler : LevelCADropAreaHandlerBase
{
	[SerializeField]
	private LevelDropArea _fishDropArea; //Field offset: 0x80
	[SerializeField]
	private LevelDropArea _characterDropArea; //Field offset: 0x88
	private List<LevelFish> _fishList; //Field offset: 0x90
	private ICATarget _target; //Field offset: 0x98
	private readonly List<LevelCAConfig> _configs; //Field offset: 0xA0

	public LevelCAAquariumDropAreaHandler() { }

	protected virtual void Awake() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual SpineType GetSpineType() { }

	public virtual bool IsValidForTarget(ICATarget target) { }

	private void OnAddFishFromAquarium(LevelItem levelItem) { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

	private void OnAnimationEvent(TrackEntry trackEntry, Event spineEvent) { }

	private void OnCompletePairItemAnimation(TrackEntry trackEntry) { }

	protected virtual void OnDestroy() { }

	private void OnPostInitAction() { }

	public virtual void OnRemovedFromTarget(ICATarget target) { }

	private void OnRemoveFishFromAquarium(LevelItem dropAreaItem) { }

	private void PlayPetAnimation(LevelCAConfig config) { }

	public virtual bool TryOverrideConfigThumb(int configIndex, out Sprite sprite) { }

	public virtual bool TryOverrideMainThumb(out Sprite sprite) { }

}

