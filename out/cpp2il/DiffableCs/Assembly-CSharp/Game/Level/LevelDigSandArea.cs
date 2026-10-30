namespace Game.Level;

public class LevelDigSandArea : LevelDigArea
{
	[SerializeField]
	private Transform _spawnPoint; //Field offset: 0x58
	[SerializeField]
	private PDPrefab[] _prefabs; //Field offset: 0x60
	[SerializeField]
	private bool _isSequential; //Field offset: 0x68
	private int _nextIndex; //Field offset: 0x6C

	public LevelDigSandArea() { }

	protected virtual void Awake() { }

	public virtual void OnShovelDig() { }

}

