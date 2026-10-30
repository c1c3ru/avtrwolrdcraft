namespace Game.Level.ContextualAnimation;

public class LevelCARampSkiDropAreaHandler : LevelCARampSnowboardDropAreaHandler
{

	public LevelCARampSkiDropAreaHandler() { }

	public virtual bool CanTargetHoldItems() { }

	public virtual bool CanTargetHoldSpecificItem(LevelItem levelItem) { }

	public virtual string GetFolderName() { }

}

