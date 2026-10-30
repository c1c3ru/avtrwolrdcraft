namespace PWC.Level.ContextualAnimation;

public abstract class LevelCADropAreaWithSkinHandlerBase : LevelCADropAreaHandlerBase
{
	private Skin _skin; //Field offset: 0x80
	private bool _isSkinOn; //Field offset: 0x88
	private LevelCAWithSkinHelper _caWithSkinHelper; //Field offset: 0x90
	protected ILevelAvatar _currentHolder; //Field offset: 0x98

	protected LevelCADropAreaWithSkinHandlerBase() { }

	protected virtual void Awake() { }

	protected abstract List<Renderer> GetRenderersToHide() { }

	protected abstract string GetSkinName() { }

	public virtual void OnAddedToTarget(ICATarget target) { }

	public virtual void OnRemovedFromTarget(ICATarget target) { }

}

