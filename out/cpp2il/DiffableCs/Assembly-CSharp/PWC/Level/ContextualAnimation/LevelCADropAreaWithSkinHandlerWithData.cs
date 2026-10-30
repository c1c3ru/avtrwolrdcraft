namespace PWC.Level.ContextualAnimation;

public class LevelCADropAreaWithSkinHandlerWithData : LevelCADropAreaWithSkinHandlerBase, IHasCAData
{
	[SerializeField]
	private LevelCAItemHandlerData _caData; //Field offset: 0xA0
	[SerializeField]
	private List<Renderer> _renderersToHide; //Field offset: 0xA8
	[SerializeField]
	private string _skinName; //Field offset: 0xB0
	private int _index; //Field offset: 0xB8

	public LevelCADropAreaWithSkinHandlerWithData() { }

	[CompilerGenerated]
	private bool <IsForceToSitWhenPossible>b__15_0(int i) { }

	public virtual bool CanTargetHoldItems() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public override LevelCAItemHandlerData GetData() { }

	public virtual string GetFolderName() { }

	public virtual string GetLockedAnimationName() { }

	protected virtual List<Renderer> GetRenderersToHide() { }

	protected virtual string GetSkinName() { }

	public virtual SpineType GetSpineType() { }

	public virtual bool IsForceToSitWhenPossible() { }

	public virtual bool IsSingleCAInMenu() { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

	public virtual bool TryOverrideMainThumb(out Sprite sprite) { }

}

