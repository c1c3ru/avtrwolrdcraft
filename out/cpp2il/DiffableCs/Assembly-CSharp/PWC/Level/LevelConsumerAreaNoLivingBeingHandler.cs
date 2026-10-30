namespace PWC.Level;

public class LevelConsumerAreaNoLivingBeingHandler : LevelConsumerAreaConditionBase
{
	[SerializeField]
	private List<SpineType> _spineTypesToAllow; //Field offset: 0x28

	public LevelConsumerAreaNoLivingBeingHandler() { }

	protected virtual void CanConsumeItem(LevelItem levelItem, ref bool canConsume) { }

	public bool CanConsumeItem(LevelItem levelItem) { }

	private bool IsAnimalAllowed(LevelAnimal animal) { }

	private bool IsAvatarAllowed(ILevelAvatar avatar) { }

	private bool IsLivingBeingAllowed(ILevelLivingBeing livingBeing) { }

	private bool IsSpineTypeAllowed(SpineType spineType) { }

}

