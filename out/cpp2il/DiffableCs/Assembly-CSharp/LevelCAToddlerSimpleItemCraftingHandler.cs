//Type is in global namespace

public class LevelCAToddlerSimpleItemCraftingHandler : LevelCAToddlerItemCraftingHandlerBase
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass9_0
	{
		public LevelCAToddlerSimpleItemCraftingHandler <>4__this; //Field offset: 0x10
		public LevelToddler toddler; //Field offset: 0x18
		public LevelCAConfig config; //Field offset: 0x20

		public <>c__DisplayClass9_0() { }

		internal void <OnAnimationBegin>b__0() { }

	}

	[SerializeField]
	private string _standingAnimationName; //Field offset: 0xD8
	[SerializeField]
	private string _sittingAnimationName; //Field offset: 0xE0
	[Header("Events")]
	[Space]
	public UnityEvent<LevelToddler, LevelCAConfig> _onStartingCraftingAnimation; //Field offset: 0xE8
	public UnityEvent<LevelToddler, LevelCAConfig> _onFinishedCraftingAnimation; //Field offset: 0xF0
	private bool _hasSittingAnimation; //Field offset: 0xF8
	private bool _hasStandingAnimation; //Field offset: 0xF9
	private LevelToddler _toddler; //Field offset: 0x100

	public LevelCAToddlerSimpleItemCraftingHandler() { }

	protected virtual void Awake() { }

	protected virtual string GetAnimationNameForAllConfigItems() { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

	public virtual void OnItemAddedToTarget(ICATarget target, LevelItem levelItem) { }

	public virtual void OnRemovedFromTarget(ICATarget target) { }

}

