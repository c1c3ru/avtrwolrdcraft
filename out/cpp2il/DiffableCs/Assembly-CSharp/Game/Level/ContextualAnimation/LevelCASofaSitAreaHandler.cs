namespace Game.Level.ContextualAnimation;

public class LevelCASofaSitAreaHandler : LevelCAParentHandlerBase
{
	private bool _isSitting; //Field offset: 0x80
	private readonly List<LevelCAConfig> _sittingConfigs; //Field offset: 0x88
	private readonly List<LevelCAConfig> _layingConfigs; //Field offset: 0x90

	public LevelCASofaSitAreaHandler() { }

	public virtual bool CanSitWhileLocked() { }

	public virtual bool CanTargetHoldItems() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual string GetLockedAnimationName() { }

	public virtual int GetPriority() { }

	public virtual SpineType GetSpineType() { }

	public virtual void OnAddedToTarget(ICATarget target) { }

	public virtual void OnAnimationEnd(ICATarget target, LevelCAConfig config) { }

	public virtual void OnRemovedFromTarget(ICATarget target) { }

	public virtual bool TryOverrideMainThumb(out Sprite sprite) { }

}

