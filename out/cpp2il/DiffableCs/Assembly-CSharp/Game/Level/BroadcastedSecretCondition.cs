namespace Game.Level;

public class BroadcastedSecretCondition : GenericConditionBase
{
	public int secretId; //Field offset: 0x10
	public LevelType secretLevelType; //Field offset: 0x14

	public BroadcastedSecretCondition() { }

	public virtual bool IsMet(GenericConditionData genericConditionData) { }

}

