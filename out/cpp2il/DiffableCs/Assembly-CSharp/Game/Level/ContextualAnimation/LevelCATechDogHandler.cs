namespace Game.Level.ContextualAnimation;

public class LevelCATechDogHandler : LevelCAHandlerBase
{
	[SerializeField]
	private GameSoundPlayer _soundPlayer; //Field offset: 0x80
	[SerializeField]
	private LevelTechDog _techDog; //Field offset: 0x88
	private int _turnOffTweenId; //Field offset: 0x90
	private readonly List<LevelCAConfig> _configs; //Field offset: 0x98

	public LevelCATechDogHandler() { }

	[CompilerGenerated]
	private void <StartTurnOff>b__10_0() { }

	protected virtual void Awake() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual SpineType GetSpineType() { }

	public virtual bool IsValidForTarget(ICATarget target) { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

	public virtual void OnAnimationEnd(ICATarget target, LevelCAConfig config) { }

	public virtual void OnAnimationEvent(ICATarget target, TrackEntry trackEntry, Event spineEvent) { }

	public virtual void OnAnimationPostBegin(ICATarget target, LevelCAConfig config, TrackEntry trackEntry) { }

	protected virtual void OnDestroy() { }

	public virtual void OnRemovedFromTarget(ICATarget target) { }

	private void OnTurnOn() { }

	private void StartTurnOff() { }

	public void TurnOff() { }

}

