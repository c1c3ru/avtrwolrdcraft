namespace PWC.Level;

public class LevelPlant : LevelPlantBase
{
	[SerializeField]
	protected SpriteRenderer _spriteRenderer; //Field offset: 0x40
	[SerializeField]
	protected Sprite[] _plantSprites; //Field offset: 0x48
	[SerializeField]
	protected String[] _soundNames; //Field offset: 0x50
	[SerializeField]
	protected PDPrefabReference _fruitPrefab; //Field offset: 0x58
	[SerializeField]
	private UnityEvent _onFruitSpawned; //Field offset: 0x60

	public LevelPlant() { }

	protected virtual int GetStagesCount() { }

	private void PlayPlantGrowSound(int index) { }

	protected virtual void SetPlantIndexInternal(int index, bool playSound) { }

}

