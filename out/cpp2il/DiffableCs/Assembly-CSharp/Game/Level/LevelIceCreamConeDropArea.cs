namespace Game.Level;

public class LevelIceCreamConeDropArea : LevelSingleItemFoodOnlyDropArea, ILevelSpawnDuringGameplay
{
	[SerializeField]
	private GameObject _front; //Field offset: 0xE0

	public LevelIceCreamConeDropArea() { }

	public virtual bool CanConsumeItem(LevelItem levelItem) { }

	public virtual Vector2 GetProperPositionToDropOnFromPosition(Vector2 fromPosition, LevelItem levelItem) { }

	protected virtual void OnLevelPostInit() { }

	private override void PWC.Level.ILevelSpawnDuringGameplay.OnSpawnDuringGameplay() { }

	private void SyncFrontState() { }

}

