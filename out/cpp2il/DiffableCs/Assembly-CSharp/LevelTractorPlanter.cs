//Type is in global namespace

public class LevelTractorPlanter : LevelDragActionItemHandlerBase
{
	private LevelPlantBase _currentPlantPrefab; //Field offset: 0xA0
	[SerializeField]
	private LevelConsumerAreaBase _seedDropArea; //Field offset: 0xA8

	public LevelTractorPlanter() { }

	public void CacheSeedBagPrefab() { }

	protected virtual bool FilterTarget(ILevelConsumer target) { }

	protected virtual void OnTargetEnter(ILevelConsumer target) { }

	protected virtual void OnTargetExit(ILevelConsumer target, ExitReasonType exitReasonType) { }

	private bool TryGetPlantPot(ILevelConsumer consumer, out LevelPlantPot plantPot) { }

}

