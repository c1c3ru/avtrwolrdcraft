namespace PWC.Level;

[AddComponentMenu(null)]
public class LevelCharactersOnlyDropArea : LevelDropArea
{
	[SerializeField]
	private bool _isMasked; //Field offset: 0xD8
	[SerializeField]
	private bool _isVisibleInsideMask; //Field offset: 0xD9

	public LevelCharactersOnlyDropArea() { }

	public virtual bool CanConsumeCharacters() { }

	public virtual bool CanConsumeItem(LevelItem levelItem) { }

	public virtual void OnItemBeginDrop(LevelItem levelItem) { }

	public virtual void OnItemDropInterrupt(LevelItem levelItem) { }

	public virtual void OnItemPickUp(LevelItem levelItem) { }

	protected virtual void OnLevelPostInit() { }

	public void SetCharacterMasked(LevelCharacter character, bool value) { }

}

