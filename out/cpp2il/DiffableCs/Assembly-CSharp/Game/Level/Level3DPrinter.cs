namespace Game.Level;

public class Level3DPrinter : MonoBehaviour
{
	[SerializeField]
	private int _maxSpawns; //Field offset: 0x20
	[SerializeField]
	private LevelSpawn[] _printablesPrefabReferences; //Field offset: 0x28
	[SerializeField]
	private LevelDropArea _dropArea; //Field offset: 0x30
	[SerializeField]
	private LevelSpawner _spawner; //Field offset: 0x38
	[SerializeField]
	private string _soundName; //Field offset: 0x40
	[SerializeField]
	private GameSoundPlayer _soundPlayer; //Field offset: 0x48
	[SerializeField]
	private LevelButton _startButton; //Field offset: 0x50
	[SerializeField]
	private Level3DPrinterScreen _screen; //Field offset: 0x58
	[SerializeField]
	private GameObject _printerHandle; //Field offset: 0x60
	[SerializeField]
	private GameObject _printerHead; //Field offset: 0x68
	[SerializeField]
	private float _maskMinHeight; //Field offset: 0x70
	[SerializeField]
	private float _maxHeight; //Field offset: 0x74
	[SerializeField]
	private float _minHeight; //Field offset: 0x78
	[SerializeField]
	private float _maxLeft; //Field offset: 0x7C
	[SerializeField]
	private float _maxRight; //Field offset: 0x80
	[SerializeField]
	private SpriteMask _mask; //Field offset: 0x88
	[SerializeField]
	private GameObject _blackEffectMask; //Field offset: 0x90
	private LevelItem _currentPrintedToy; //Field offset: 0x98
	private LevelItem _currentMaskToy; //Field offset: 0xA0
	private bool _isWorking; //Field offset: 0xA8
	private int _handleTweenId; //Field offset: 0xAC
	private SpriteRenderer _currentSpriteRenderer; //Field offset: 0xB0
	private float _maskEffectStartingPosition; //Field offset: 0xB8

	public Level3DPrinter() { }

	private void EndPrint() { }

	public void OnCreate() { }

	private void Print() { }

	private LevelItem SpawnToy(int itemId) { }

	private void StartPrint() { }

}

