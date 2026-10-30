namespace PWC.Level;

public class LevelPumpableTransformableItemHandler : LevelPumpableItemHandler, ILevelMakerUICountExtraPrefab
{
	[SerializeField]
	private SpriteRenderer _spriteRenderer; //Field offset: 0x60
	[SerializeField]
	private LevelItem _prefab; //Field offset: 0x68
	private int _pumpCounter; //Field offset: 0x70

	public LevelPumpableTransformableItemHandler() { }

	public virtual void OnPumped() { }

	private override string PWC.Level.ILevelMakerUICountExtraPrefab.GetExtraPrefabGuid() { }

}

