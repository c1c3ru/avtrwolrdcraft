namespace PWC.Level.ContextualAnimation;

public abstract class LevelCAItemSpineNoSkinHandlerBase : LevelCAItemHandlerBase
{
	private LevelCharacter _currentHolder; //Field offset: 0x88
	private Renderer[] _myRenderers; //Field offset: 0x90

	protected LevelCAItemSpineNoSkinHandlerBase() { }

	protected virtual void Awake() { }

	public void HideItemAndRefreshSpineLitComponent() { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

	public virtual void OnAnimationEnd(ICATarget target, LevelCAConfig config) { }

	public void ShowItem() { }

}

