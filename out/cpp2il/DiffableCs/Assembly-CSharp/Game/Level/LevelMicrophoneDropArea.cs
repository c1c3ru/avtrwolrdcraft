namespace Game.Level;

public class LevelMicrophoneDropArea : LevelSingleItemDropArea
{

	public LevelMicrophoneDropArea() { }

	public virtual void OnItemBeginDrop(LevelItem levelItem) { }

	public virtual void OnItemPickUp(LevelItem levelItem) { }

	protected virtual void OnLevelPostInit() { }

}

