namespace Game.Level.ContextualAnimation;

public class LevelCAAppliancesHairDryerItemHandler : LevelCAHairDryerItemHandler
{
	private int _tweenId; //Field offset: 0xA0
	private readonly List<LevelCAConfig> _configs; //Field offset: 0xA8

	public LevelCAAppliancesHairDryerItemHandler() { }

	[CompilerGenerated]
	private void <OnAnimationBegin>b__2_0() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

}

