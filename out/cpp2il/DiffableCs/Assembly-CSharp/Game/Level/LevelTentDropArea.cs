namespace Game.Level;

public class LevelTentDropArea : LevelCharactersAllowedDropArea
{

	public LevelTentDropArea() { }

	public virtual void OnItemBeginDrop(LevelItem levelItem) { }

	public virtual void OnItemDropInterrupt(LevelItem levelItem) { }

	public virtual void OnItemPickUp(LevelItem levelItem) { }

	public virtual void ReleaseItems(Predicate<LevelItem> predicate = null) { }

	private void SetCharacterMasked(LevelCharacter character, bool value) { }

}

