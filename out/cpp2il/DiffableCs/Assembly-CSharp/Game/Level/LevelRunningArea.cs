namespace Game.Level;

public class LevelRunningArea : LevelDropArea
{
	[SerializeField]
	private bool _allowCharacterRunning; //Field offset: 0xD8

	public LevelRunningArea() { }

	private void EnsureRunningItemHandler(LevelItem levelItem) { }

	private void InitIfNeeded() { }

	public virtual void OnItemEndDrop(LevelItem levelItem) { }

	protected virtual void OnLevelPostInit() { }

}

