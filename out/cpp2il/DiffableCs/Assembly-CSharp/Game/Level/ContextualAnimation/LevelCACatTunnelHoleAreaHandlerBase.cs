namespace Game.Level.ContextualAnimation;

[RequireComponent(typeof(LevelDropArea))]
public abstract class LevelCACatTunnelHoleAreaHandlerBase : LevelCADropAreaHandlerBase
{
	private LevelDropArea _dropArea; //Field offset: 0x80
	[CompilerGenerated]
	private Action<LevelCat, Boolean> OnBeginEnterTunnelHole; //Field offset: 0x88
	[CompilerGenerated]
	private Action<LevelCat, LevelDropArea, Boolean> OnEndEnterTunnelHole; //Field offset: 0x90
	[CompilerGenerated]
	private bool <CanDoCatFight>k__BackingField; //Field offset: 0x98

	public event Action<LevelCat, Boolean> OnBeginEnterTunnelHole
	{
		[CompilerGenerated]
		 add { } //Length: 176
		[CompilerGenerated]
		 remove { } //Length: 176
	}

	public event Action<LevelCat, LevelDropArea, Boolean> OnEndEnterTunnelHole
	{
		[CompilerGenerated]
		 add { } //Length: 176
		[CompilerGenerated]
		 remove { } //Length: 176
	}

	internal bool CanDoCatFight
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		internal set { } //Length: 12
	}

	protected LevelCACatTunnelHoleAreaHandlerBase() { }

	[CompilerGenerated]
	public void add_OnBeginEnterTunnelHole(Action<LevelCat, Boolean> value) { }

	[CompilerGenerated]
	public void add_OnEndEnterTunnelHole(Action<LevelCat, LevelDropArea, Boolean> value) { }

	protected virtual void Awake() { }

	[CompilerGenerated]
	 bool get_CanDoCatFight() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	protected abstract List<LevelCAConfig> GetConfigs() { }

	protected abstract List<LevelCAConfig> GetConfigsWithCatFight() { }

	public virtual SpineType GetSpineType() { }

	public virtual bool IsSingleCAInMenu() { }

	public virtual bool IsValidForTarget(ICATarget target) { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

	public virtual void OnAnimationEnd(ICATarget target, LevelCAConfig config) { }

	[CompilerGenerated]
	public void remove_OnBeginEnterTunnelHole(Action<LevelCat, Boolean> value) { }

	[CompilerGenerated]
	public void remove_OnEndEnterTunnelHole(Action<LevelCat, LevelDropArea, Boolean> value) { }

	[CompilerGenerated]
	internal void set_CanDoCatFight(bool value) { }

	public virtual bool TryOverrideConfigThumb(int configIndex, out Sprite sprite) { }

	public virtual bool TryOverrideMainThumb(out Sprite sprite) { }

}

