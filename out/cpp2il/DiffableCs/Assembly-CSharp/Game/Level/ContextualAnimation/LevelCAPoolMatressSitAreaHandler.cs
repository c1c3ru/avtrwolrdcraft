namespace Game.Level.ContextualAnimation;

public class LevelCAPoolMatressSitAreaHandler : LevelCAParentHandlerBase
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass4_0
	{
		public LevelCAPoolMatressSitAreaHandler <>4__this; //Field offset: 0x10
		public ICATarget target; //Field offset: 0x18

		public <>c__DisplayClass4_0() { }

		internal void <OnAnimationBegin>b__0() { }

	}

	[SerializeField]
	private Sprite _overrideThumb; //Field offset: 0x80
	private string _currentAnimation; //Field offset: 0x88
	private readonly List<LevelCAConfig> _configs; //Field offset: 0x90

	public LevelCAPoolMatressSitAreaHandler() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual string GetLockedAnimationName() { }

	public virtual SpineType GetSpineType() { }

	protected virtual bool IsAllowedInWaterArea() { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

	public virtual void OnAnimationEnd(ICATarget target, LevelCAConfig config) { }

	public virtual bool TryOverrideMainThumb(out Sprite sprite) { }

}

