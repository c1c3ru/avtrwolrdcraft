namespace Game.Level.ContextualAnimation;

public class LevelCANewspaperBagClothingSpineSkinHandler : LevelCABagSpineSkinHandler
{
	private const float SPEED = 10; //Field offset: 0x0
	private readonly List<LevelCAConfig> _configs; //Field offset: 0xA0
	private bool _isAddedBaseAnimations; //Field offset: 0xA8
	private LevelItem _newpaperInstance; //Field offset: 0xB0
	private int _throwTweenID; //Field offset: 0xB8

	public LevelCANewspaperBagClothingSpineSkinHandler() { }

	[CompilerGenerated]
	private void <Throw>b__9_0() { }

	protected virtual void Awake() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual SpineType GetSpineType() { }

	public virtual void OnAnimationEvent(ICATarget target, TrackEntry trackEntry, Event spineEvent) { }

	protected virtual void OnDestroy() { }

	private void OnPreSaveProgress(Scene scene) { }

	private void Throw(LevelCharacter character) { }

}

