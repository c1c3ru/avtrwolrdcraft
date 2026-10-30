namespace PWC.Level;

public class LevelMultipleFruitTree : LevelFruitTree
{
	[SerializeField]
	protected bool _isRandomFruit; //Field offset: 0x70
	[SerializeField]
	protected PDPrefabReference[] _fruitPrefabs; //Field offset: 0x78

	public LevelMultipleFruitTree() { }

	protected virtual PDPrefabReference GetFruitPrefab(int pointIndex) { }

}

