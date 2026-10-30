namespace Game.Level;

public class LevelNailBottleItemHandler : LevelConsumerAreaBase
{
	[SerializeField]
	private LevelSingleItemDropArea _singleItemDropArea; //Field offset: 0x58
	[SerializeField]
	private LevelCharacterMakeupData _characterLeftNailData; //Field offset: 0x60
	[SerializeField]
	private LevelCharacterMakeupData _characterRightNailData; //Field offset: 0x68
	[SerializeField]
	private SpriteRenderer _bottleColorTop; //Field offset: 0x70
	[SerializeField]
	private SpriteRenderer _bottleColorBottom; //Field offset: 0x78

	public LevelNailBottleItemHandler() { }

	protected virtual void Awake() { }

	public LevelCharacterMakeupData GetLeftNailData() { }

	public LevelCharacterMakeupData GetRightNailData() { }

	protected virtual void OnDestroy() { }

	private void OnItemEndDrop(LevelItem levelItem) { }

	private void OnPostInit() { }

}

