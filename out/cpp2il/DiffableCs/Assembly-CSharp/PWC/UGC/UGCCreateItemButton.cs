namespace PWC.UGC;

public class UGCCreateItemButton : LevelMakerCreateItemButtonBase
{

	public UGCCreateItemButton() { }

	protected virtual bool DidReachMaxLevelMakerItems() { }

	protected virtual bool IsItemUnavaliable() { }

	protected virtual void TrySpawnInternal() { }

}

