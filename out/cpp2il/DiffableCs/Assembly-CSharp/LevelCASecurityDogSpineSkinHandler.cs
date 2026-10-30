//Type is in global namespace

public class LevelCASecurityDogSpineSkinHandler : LevelCASpineSkinHandlerBase
{
	[SerializeField]
	private GameSoundPlayer _soundPlayer; //Field offset: 0x98
	[SerializeField]
	private Transform _poopPoistion; //Field offset: 0xA0
	private readonly List<LevelCAConfig> _configs; //Field offset: 0xA8

	public LevelCASecurityDogSpineSkinHandler() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual SpineType GetSpineType() { }

	public virtual bool IsValidForTarget(ICATarget target) { }

	public virtual void OnAnimationEvent(ICATarget target, TrackEntry trackEntry, Event spineEvent) { }

	private void TakeOffShirt(LevelDog dog) { }

	public virtual bool TryOverrideMainThumb(out Sprite sprite) { }

}

