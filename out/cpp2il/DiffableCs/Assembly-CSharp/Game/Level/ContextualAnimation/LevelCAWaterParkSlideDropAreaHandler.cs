namespace Game.Level.ContextualAnimation;

public class LevelCAWaterParkSlideDropAreaHandler : LevelCADropAreaHandlerBase
{
	[SerializeField]
	private SkeletonAnimation _skeletonAnimation; //Field offset: 0x80
	private bool _isSitting; //Field offset: 0x88
	private readonly List<LevelCAConfig> _sittingConfigs; //Field offset: 0x90
	private readonly List<LevelCAConfig> _layingConfigs; //Field offset: 0x98

	public private bool IsSitting
	{
		 get { } //Length: 8
		private set { } //Length: 12
	}

	public LevelCAWaterParkSlideDropAreaHandler() { }

	public virtual bool CanTargetHoldItems() { }

	public bool get_IsSitting() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual string GetLockedAnimationName() { }

	public virtual SpineType GetSpineType() { }

	public virtual bool IsSingleCAInMenu() { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

	public virtual void OnAnimationEnd(ICATarget target, LevelCAConfig config) { }

	private void set_IsSitting(bool value) { }

	public virtual bool TryOverrideMainThumb(out Sprite sprite) { }

}

