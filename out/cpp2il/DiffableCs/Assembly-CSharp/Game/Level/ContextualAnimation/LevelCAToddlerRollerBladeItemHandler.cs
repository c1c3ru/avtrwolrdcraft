namespace Game.Level.ContextualAnimation;

public class LevelCAToddlerRollerBladeItemHandler : LevelCAToddlerShoesSpineSkinHandler
{
	private const string LOSE_BALANCE_ANIMATION_NAME = "Lose_Balance_Not_Fall"; //Field offset: 0x0
	private bool isAddedBaseAnimations; //Field offset: 0xA8
	private LevelCARollerBladeItemHelper _helper; //Field offset: 0xB0
	private readonly List<LevelCAConfig> _configs; //Field offset: 0xB8

	public LevelCAToddlerRollerBladeItemHandler() { }

	protected virtual void Awake() { }

	public virtual bool CanTargetHoldItems() { }

	public virtual bool CanTargetHoldSpecificItem(LevelItem levelItem) { }

	protected virtual void EnsureOnReadyPostLoad() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetLockedAnimationName() { }

	public virtual void OnAddedToTarget(ICATarget target) { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

	private void OnApplicationPause(bool pause) { }

	protected virtual void OnDestroy() { }

	public virtual void OnRemovedFromTarget(ICATarget target) { }

	public virtual bool TryOverrideMainThumb(out Sprite sprite) { }

}

