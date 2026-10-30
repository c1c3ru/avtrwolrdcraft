namespace PWC.Level;

public class LevelToggleableSprite : MonoBehaviour, IPointerClickHandler, IEventSystemHandler, IHasPersistentData, IRequirePDSceneObject
{
	[SerializeField]
	protected SpriteRenderer _spriteRenderer; //Field offset: 0x20
	[SerializeField]
	protected GameSoundPlayer _soundPlayer; //Field offset: 0x28
	[FormerlySerializedAs("_soundName")]
	[SerializeField]
	protected string _onClickSoundName; //Field offset: 0x30
	[SerializeField]
	protected string _onFirstIndexClickSoundName; //Field offset: 0x38
	[SerializeField]
	protected string _onLastIndexClickSoundName; //Field offset: 0x40
	[SerializeField]
	protected float _volume; //Field offset: 0x48
	[SerializeField]
	private bool _isRandom; //Field offset: 0x4C
	[SerializeField]
	private bool _isLoop; //Field offset: 0x4D
	[SerializeField]
	private bool _disallowToggleOnClick; //Field offset: 0x4E
	[SerializeField]
	protected Sprite[] _sprites; //Field offset: 0x50
	[SerializeField]
	protected Int32[] _excludeIndexes; //Field offset: 0x58
	private CShape _cShape; //Field offset: 0x60
	protected int _currentIndex; //Field offset: 0x68
	[CompilerGenerated]
	private Action<Int32> OnClickAction; //Field offset: 0x70
	[CompilerGenerated]
	private Action<Int32> OnLoadPersistentDataAction; //Field offset: 0x78
	[CompilerGenerated]
	private Action<Int32> OnSpriteSetAction; //Field offset: 0x80

	public event Action<Int32> OnClickAction
	{
		[CompilerGenerated]
		 add { } //Length: 176
		[CompilerGenerated]
		 remove { } //Length: 176
	}

	public event Action<Int32> OnLoadPersistentDataAction
	{
		[CompilerGenerated]
		 add { } //Length: 176
		[CompilerGenerated]
		 remove { } //Length: 176
	}

	public event Action<Int32> OnSpriteSetAction
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

	public LevelToggleableSprite() { }

	[CompilerGenerated]
	public void add_OnClickAction(Action<Int32> value) { }

	[CompilerGenerated]
	public void add_OnLoadPersistentDataAction(Action<Int32> value) { }

	[CompilerGenerated]
	public void add_OnSpriteSetAction(Action<Int32> value) { }

	private void Awake() { }

	public void ForceClick() { }

	public int get_CurrentIndex() { }

	public int GetCurrentIndex() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	protected bool IsExcludedIndex(int index) { }

	public override void OnPointerClick(PointerEventData eventData) { }

	private void PerformClick() { }

	public void PerformRemoteClick() { }

	protected override void PlaySound(string soundName) { }

	[CompilerGenerated]
	public void remove_OnClickAction(Action<Int32> value) { }

	[CompilerGenerated]
	public void remove_OnLoadPersistentDataAction(Action<Int32> value) { }

	[CompilerGenerated]
	public void remove_OnSpriteSetAction(Action<Int32> value) { }

	public void SetNextIndex() { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	public void SetPreviousIndex() { }

	protected override void SetSprite(Sprite sprite) { }

	public void SetSpriteByDecreaseOrder() { }

	public void SetSpriteByIndex(int index) { }

	public void ToggleCShape(bool isEnabled) { }

	private bool TryGetNextClickIndex(out int nextIndex) { }

	private bool TryGetRandomClickIndex(out int nextIndex) { }

	private bool TryGetSequentialClickIndex(out int nextIndex) { }

}

