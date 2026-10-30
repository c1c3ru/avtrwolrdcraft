namespace PWC.Level;

public class LevelMakeupRemoverItemHandler : LevelDragActionCharacterAreaItemHandlerBase
{
	[SerializeField]
	private CharacterCategoryType[] _categoryTypes; //Field offset: 0xA0
	[SerializeField]
	private AreaType _areaTypeToCheck; //Field offset: 0xA8

	public LevelMakeupRemoverItemHandler() { }

	public virtual AreaType GetAreaTypeToCheck() { }

	public void OnSpineEventFromCAOnSelf(LevelCharacter character) { }

	protected virtual void OnTargetEnter(ILevelConsumer consumer) { }

	protected virtual void OnTargetExit(ILevelConsumer consumer, ExitReasonType exitReasonType) { }

}

