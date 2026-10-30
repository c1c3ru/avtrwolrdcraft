namespace Game.Level;

public abstract class GenericConditionBase
{

	protected GenericConditionBase() { }

	public abstract bool IsMet(GenericConditionData genericConditionData) { }

}

