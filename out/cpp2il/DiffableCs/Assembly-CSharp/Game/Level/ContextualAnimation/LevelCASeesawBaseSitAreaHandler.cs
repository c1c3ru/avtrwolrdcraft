namespace Game.Level.ContextualAnimation;

public abstract class LevelCASeesawBaseSitAreaHandler : LevelCAParentHandlerBase
{
	private readonly List<LevelCAConfig> _configs; //Field offset: 0x80
	[CompilerGenerated]
	private Action OnBeginSwingAction; //Field offset: 0x88

	public event Action OnBeginSwingAction
	{
		[CompilerGenerated]
		 add { } //Length: 156
		[CompilerGenerated]
		 remove { } //Length: 156
	}

	protected LevelCASeesawBaseSitAreaHandler() { }

	[CompilerGenerated]
	public void add_OnBeginSwingAction(Action value) { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

	[CompilerGenerated]
	public void remove_OnBeginSwingAction(Action value) { }

	public virtual bool TryOverrideMainThumb(out Sprite sprite) { }

}

