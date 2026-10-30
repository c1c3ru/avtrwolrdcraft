namespace PWC.Level;

public class LevelConsumerAreaAnimalsOnlyHandler : LevelConsumerAreaConditionBase
{
	[SerializeField]
	private AnimalType[] _animalTypes; //Field offset: 0x28

	public LevelConsumerAreaAnimalsOnlyHandler() { }

	protected virtual void CanConsumeItem(LevelItem levelItem, ref bool canConsume) { }

}

