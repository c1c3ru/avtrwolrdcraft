namespace PWC.Level.Maker;

public class LevelMakerCreateItemButton : LevelMakerCreateItemButtonBase
{
	private const int MAX_LEVEL_ITEMS_COUNT = 1000; //Field offset: 0x0
	private bool _isItemBlocked; //Field offset: 0x5C

	public LevelMakerCreateItemButton() { }

	protected virtual bool DidReachMaxLevelMakerItems() { }

	protected virtual bool IsItemUnavaliable() { }

	private PDPrefab SpawnImplement(Vector2 position) { }

	protected virtual bool TrySetIsItemUnavaliable(GameObject target) { }

	private bool TrySpawn(Nullable<Vector2> position, out PDPrefab instance) { }

	protected virtual void TrySpawnInternal() { }

}

