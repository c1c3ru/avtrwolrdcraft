namespace Game.Level;

public class LevelNotebookItemHandler : LevelSimpleSpawner, ILevelSpawnDuringGameplay
{
	[SerializeField]
	private GameSoundPlayer _soundPlayer; //Field offset: 0x98
	[SerializeField]
	private string _spritesBasePath; //Field offset: 0xA0
	private bool _didOnReadyPostLoad; //Field offset: 0xA8
	private Sprite[] _drawingShapes; //Field offset: 0xB0
	private int _lastDrawingShapeIndex; //Field offset: 0xB8

	public LevelNotebookItemHandler() { }

	protected virtual void Awake() { }

	private void EnsureDrawingShapes() { }

	private void EnsureOnReadyPostLoad() { }

	private void OnDestroy() { }

	private void OnLevelPostInit() { }

	private void OnReadyPostLoad() { }

	protected virtual void OnSpawn(LevelSpawn levelSpawn) { }

	public override void OnSpawnDuringGameplay() { }

}

