namespace Game.Level.ContextualAnimation;

public class LevelCAHandDrumItemHandler : LevelCAItemHandlerBase
{
	[SerializeField]
	private LevelEnsurePickupItemHandler _ensurePickupItemHandler; //Field offset: 0x88
	[SerializeField]
	private string _soundName; //Field offset: 0x90
	[SerializeField]
	private GameSoundPlayer _soundPlayer; //Field offset: 0x98
	private readonly List<LevelCAConfig> _configs; //Field offset: 0xA0

	public LevelCAHandDrumItemHandler() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual SpineType GetSpineType() { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

	public virtual void OnAnimationEnd(ICATarget target, LevelCAConfig config) { }

	public virtual bool ShouldPlayPreAnimation(LevelCAConfig config) { }

	private void SoundPlayerSetActive(bool value) { }

}

