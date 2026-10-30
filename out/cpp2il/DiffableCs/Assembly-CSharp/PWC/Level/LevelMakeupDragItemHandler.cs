namespace PWC.Level;

public class LevelMakeupDragItemHandler : LevelDragActionItemHandlerBase, ILevelDragActionCharacterAreaItemHandler, ILevelDragActionItemHandler
{
	[SerializeField]
	protected CharacterCategoryType _categoryType; //Field offset: 0xA0
	[SerializeField]
	protected string _skinName; //Field offset: 0xA8
	[SerializeField]
	protected bool _isGradient; //Field offset: 0xB0
	[SerializeField]
	protected Color _color; //Field offset: 0xB4
	[ConditionalField("_isGradient", True, True, (array) null)]
	[SerializeField]
	protected Color _secondColor; //Field offset: 0xC4
	[SerializeField]
	private string _soundName; //Field offset: 0xD8
	protected string _fullSkinName; //Field offset: 0xE0

	public LevelMakeupDragItemHandler() { }

	protected virtual void Awake() { }

	protected virtual bool FilterTarget(ILevelConsumer target) { }

	public void OnSpineEventFromCAOnSelf(LevelCharacter character) { }

	protected virtual void OnTargetEnter(ILevelConsumer target) { }

	protected override void OnTargetEnterCharacterHead(LevelCharacter character, bool shouldPlaySound = true) { }

	protected override void OnTargetEnterOtherItem(ILevelConsumer target) { }

	protected virtual void OnTargetExit(ILevelConsumer target, ExitReasonType exitReasonType) { }

	protected override void OnTargetExitCharacterHead(LevelCharacter character) { }

	protected override void OnTargetExitOtherItem(ILevelConsumer target) { }

	protected virtual bool PerformDragCondition(ILevelConsumer consumer) { }

	private override AreaType PWC.Level.ILevelDragActionCharacterAreaItemHandler.GetAreaTypeToCheck() { }

	protected override void ResetColor() { }

	protected override void SetData(LevelCharacterMakeupData characterMakeupData) { }

}

