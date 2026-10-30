//Type is in global namespace

public class LevelCenteredOnCamSpawner : LevelSimpleSpawner
{
	[SerializeField]
	private Vector2 _spawnerOffset; //Field offset: 0x98

	public LevelCenteredOnCamSpawner() { }

	protected virtual void Awake() { }

	private void OnDestroy() { }

	private void OnLevelPostInit() { }

}

