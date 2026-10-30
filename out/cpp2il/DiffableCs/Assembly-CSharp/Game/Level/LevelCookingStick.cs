namespace Game.Level;

public class LevelCookingStick : LevelSimpleDragActionItemBase
{
	[SerializeField]
	private LevelCookingStickArea _cookingStickArea; //Field offset: 0x358
	[SerializeField]
	private ParticleSystem _particleSystem; //Field offset: 0x360
	[CompilerGenerated]
	private LevelStickCookable <CurrentCookableItem>k__BackingField; //Field offset: 0x368

	public LevelStickCookable CurrentCookableItem
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 16
	}

	public LevelCookingStick() { }

	protected virtual void Awake() { }

	protected virtual bool FilterTarget(ILevelConsumer target) { }

	[CompilerGenerated]
	public LevelStickCookable get_CurrentCookableItem() { }

	protected virtual void OnDestroy() { }

	protected virtual void OnLevelPostInit() { }

	protected virtual void OnTargetEnter(ILevelConsumer consumer) { }

	protected virtual void OnTargetExit(ILevelConsumer consumer) { }

	private void ParticleSystemSetActive(bool value) { }

	[CompilerGenerated]
	public void set_CurrentCookableItem(LevelStickCookable value) { }

	private void TryDropInteractionWithCharacter(LevelCharacter character, ref bool didInteract, ref MPEventIdentifierData mpData) { }

}

