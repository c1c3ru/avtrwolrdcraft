namespace Game.Level;

public class LevelRunningAreaSingleItemCharactersOnlyDropArea : LevelSingleItemCharactersOnlyDropArea
{
	[SerializeField]
	private bool _allowCharacterRunning; //Field offset: 0xDA
	[SerializeField]
	private bool _hasCharacter; //Field offset: 0xDB

	public bool HasCharacter
	{
		 get { } //Length: 8
		 set { } //Length: 12
	}

	public LevelRunningAreaSingleItemCharactersOnlyDropArea() { }

	private void EnsureRunningItemHandler(LevelItem levelItem) { }

	public bool get_HasCharacter() { }

	public virtual void OnItemEndDrop(LevelItem levelItem) { }

	public virtual void OnItemPickUp(LevelItem levelItem) { }

	protected virtual void OnLevelPostInit() { }

	public void set_HasCharacter(bool value) { }

}

