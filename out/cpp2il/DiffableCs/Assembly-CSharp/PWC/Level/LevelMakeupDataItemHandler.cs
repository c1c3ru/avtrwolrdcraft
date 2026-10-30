namespace PWC.Level;

public class LevelMakeupDataItemHandler : LevelConsumerAreaBase
{
	[SerializeField]
	private LevelCharacterMakeupData _characterMakeupData; //Field offset: 0x58
	[SerializeField]
	private CharacterCategoryType _categoryType; //Field offset: 0x60
	[SerializeField]
	private string _skinName; //Field offset: 0x68
	[SerializeField]
	private bool _shouldKeepExistingColor; //Field offset: 0x70
	[ConditionalField("_shouldKeepExistingColor", False, True, (array) null)]
	[SerializeField]
	private Color _color; //Field offset: 0x74
	[ConditionalField("_shouldKeepExistingColor", False, True, (array) null)]
	[SerializeField]
	private bool _isGradient; //Field offset: 0x84
	[ConditionalField("_isGradient", True, True, (array) null)]
	[SerializeField]
	private Color _secondColor; //Field offset: 0x88
	protected string _fullSkinName; //Field offset: 0x98

	public LevelMakeupDataItemHandler() { }

	protected virtual void Awake() { }

	public LevelCharacterMakeupData GetData() { }

	public void OnSpineEventFromCAOnSelf(LevelCharacter character) { }

}

