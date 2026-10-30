namespace Game.Level;

public class CurrentLevelCondition : GenericConditionBase
{
	public LevelType expectedLevelType; //Field offset: 0x10

	public CurrentLevelCondition() { }

	public virtual bool IsMet(GenericConditionData genericConditionData) { }

}

