namespace PWC.Level;

public class LevelSeedPacket : LevelSimpleDragActionItemBase
{
	[SerializeField]
	private GameObject _sprite; //Field offset: 0x358
	[SerializeField]
	private LevelPlantBase _plantPrefab; //Field offset: 0x360
	private int _tweenID; //Field offset: 0x368
	private int _potsCounter; //Field offset: 0x36C

	public LevelPlantBase PlantPrefab
	{
		 get { } //Length: 8
	}

	public LevelSeedPacket() { }

	protected virtual bool FilterTarget(ILevelConsumer target) { }

	public LevelPlantBase get_PlantPrefab() { }

	public virtual bool IsConsumerGoodTarget(ILevelConsumer consumer) { }

	protected virtual void OnEndDragInternal(PointerEventData eventData) { }

	protected virtual void OnTargetEnter(ILevelConsumer consumer) { }

	protected virtual void OnTargetExit(ILevelConsumer consumer) { }

	private void Tilt(bool value) { }

	private bool TryGetPlantPot(ILevelConsumer consumer, out LevelPlantPot plantPot) { }

}

