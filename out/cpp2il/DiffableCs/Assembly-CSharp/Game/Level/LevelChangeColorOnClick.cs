namespace Game.Level;

public class LevelChangeColorOnClick : MonoBehaviour, IPointerClickHandler, IEventSystemHandler, IHasPersistentData, IRequirePDSceneObject, ILevelSpawnDuringGameplay
{
	[SerializeField]
	private SpriteRenderer _spriteRenderer; //Field offset: 0x20
	[SerializeField]
	private Color[] _colors; //Field offset: 0x28
	[SerializeField]
	private bool _isRandom; //Field offset: 0x30
	[SerializeField]
	private bool _changeOnAwake; //Field offset: 0x31
	[SerializeField]
	private bool _restoreValueOnAwake; //Field offset: 0x32
	[SerializeField]
	private PWSpriteColorType _colorType; //Field offset: 0x34
	[CompilerGenerated]
	private Action<Color> OnColorChange; //Field offset: 0x38
	private int _currentIndex; //Field offset: 0x40
	private LevelSimpleSpawner _spawner; //Field offset: 0x48

	public event Action<Color> OnColorChange
	{
		[CompilerGenerated]
		 add { } //Length: 176
		[CompilerGenerated]
		 remove { } //Length: 176
	}

	public int CurrentIndex
	{
		 get { } //Length: 8
	}

	public LevelChangeColorOnClick() { }

	[CompilerGenerated]
	public void add_OnColorChange(Action<Color> value) { }

	private void Awake() { }

	private void ChangeColor() { }

	public void ForceClick() { }

	public int get_CurrentIndex() { }

	public Color GetCurrentColor() { }

	public int GetCurrentIndex() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	private void OnDestroy() { }

	private void OnLevelPostInit() { }

	public override void OnPointerClick(PointerEventData eventData) { }

	private void OnReadyPostLoad() { }

	public override void OnSpawnDuringGameplay() { }

	public void RemoteIncreseIndexByAmount(int amount) { }

	[CompilerGenerated]
	public void remove_OnColorChange(Action<Color> value) { }

	private void SetColor() { }

	public void SetColorByIndex(int index) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

}

