//Type is in global namespace

public class LevelCASkinRemoverByCategory : LevelCAItemHandlerWithData
{
	[SerializeField]
	private string _containedEventName; //Field offset: 0x90
	[SerializeField]
	private bool _invokeOnSpecificAnimationOnly; //Field offset: 0x98
	[ConditionalField("_invokeOnSpecificAnimationOnly", True, True, (array) null)]
	[SerializeField]
	private string _containedSpecificAnimationName; //Field offset: 0xA0
	[SerializeField]
	private CharacterCategoryType[] _categoryTypes; //Field offset: 0xA8

	public LevelCASkinRemoverByCategory() { }

	public virtual void OnAnimationEvent(ICATarget target, TrackEntry trackEntry, Event spineEvent) { }

	private void RemoveSkin(LevelCharacter character) { }

}

