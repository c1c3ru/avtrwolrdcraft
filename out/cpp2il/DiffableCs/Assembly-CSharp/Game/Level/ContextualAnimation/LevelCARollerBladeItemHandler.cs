namespace Game.Level.ContextualAnimation;

public class LevelCARollerBladeItemHandler : LevelCAShoesSpineSkinHandler
{
	private const string TRICK_JUMP_ANIMATION_NAME = "Trick_Jump"; //Field offset: 0x0
	private const string LEG_STAND_ANIMATION_NAME = "Trick_Leg_Stand"; //Field offset: 0x0
	private const string LOSE_BALANCE_ANIMATION_NAME = "Lose_Balance_Not_Fall"; //Field offset: 0x0
	private const string DANCE_ANIMATION_NAME = "Dance_1"; //Field offset: 0x0
	private bool isAddedBaseAnimations; //Field offset: 0xA0
	private LevelCARollerBladeItemHelper _helper; //Field offset: 0xA8
	private readonly List<LevelCAConfig> _configs; //Field offset: 0xB0

	public LevelCARollerBladeItemHandler() { }

	protected virtual void Awake() { }

	public virtual bool CanTargetHoldItems() { }

	public virtual bool CanTargetHoldSpecificItem(LevelItem levelItem) { }

	protected virtual void EnsureOnReadyPostLoad() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual string GetLockedAnimationName() { }

	public virtual bool IsRelevantForTarget(ICATarget target) { }

	public virtual void OnAddedToTarget(ICATarget target) { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

	private void OnApplicationPause(bool pause) { }

	protected virtual void OnDestroy() { }

	public virtual void OnRemovedFromTarget(ICATarget target) { }

}

