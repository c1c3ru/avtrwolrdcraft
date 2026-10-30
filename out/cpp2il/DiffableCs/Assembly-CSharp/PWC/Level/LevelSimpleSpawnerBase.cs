namespace PWC.Level;

public abstract class LevelSimpleSpawnerBase : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerClickHandler, IBeginDragHandler, IDragHandler, ILevelMakerDisabledWhileInEditMode, IMultiplayer_Messageable, IMultiplayer_NetworkIdentityBase, ICanListenForSecrets
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass33_0
	{
		public LevelItem levelItem; //Field offset: 0x10
		public LevelSimpleSpawnerBase <>4__this; //Field offset: 0x18

		public <>c__DisplayClass33_0() { }

		internal void <SpawnOnClick>b__3() { }

		internal Transform <SpawnOnClick>g__GetDesiredParent|0() { }

		internal Vector2 <SpawnOnClick>g__GetDesiredSpawnPoint|1(Transform desiredTransform) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass33_1
	{
		public LevelItem item; //Field offset: 0x10

		public <>c__DisplayClass33_1() { }

		internal void <SpawnOnClick>b__2() { }

	}

	[SerializeField]
	protected Transform _spawnPoint; //Field offset: 0x20
	[SerializeField]
	private LevelSpawner _spawner; //Field offset: 0x28
	[Range(1, 20)]
	[SerializeField]
	private int _maxInstances; //Field offset: 0x30
	[ConditionalField("_destroyOnMaxInstances", False, True, (array) null)]
	[SerializeField]
	private bool _useFifo; //Field offset: 0x34
	[SerializeField]
	private bool _isJump; //Field offset: 0x35
	[ConditionalField("_isJump", False, True, (array) null)]
	[SerializeField]
	private bool _isBasicDrop; //Field offset: 0x36
	[SerializeField]
	private bool _spawnOnDrag; //Field offset: 0x37
	[SerializeField]
	private bool _isPoofEffect; //Field offset: 0x38
	[SerializeField]
	private bool _destroyOnMaxInstances; //Field offset: 0x39
	[ConditionalField("_spawnOnDrag", False, True, (array) null)]
	[SerializeField]
	private bool _createStack; //Field offset: 0x3A
	[SerializeField]
	private bool _shouldTryToColor; //Field offset: 0x3B
	[ConditionalField("_shouldTryToColor", True, True, (array) null)]
	[SerializeField]
	private Color _color; //Field offset: 0x3C
	[ConditionalField("_shouldTryToColor", True, True, (array) null)]
	[SerializeField]
	private PWSpriteColorType _colorType; //Field offset: 0x4C
	[SerializeField]
	private Transform _parent; //Field offset: 0x50
	[SerializeField]
	private string _soundName; //Field offset: 0x58
	private Color _runtimeColor; //Field offset: 0x60
	private CShape _cShape; //Field offset: 0x70
	[CompilerGenerated]
	private Action<LevelSimpleSpawnerBase, LevelSpawn> OnSpawnAction; //Field offset: 0x78
	[CompilerGenerated]
	private Action<LevelItem> OnPostSpawnAction; //Field offset: 0x80
	[CompilerGenerated]
	private int <Multiplayer_ComponentIndex>k__BackingField; //Field offset: 0x88

	public event Action<LevelItem> OnPostSpawnAction
	{
		[CompilerGenerated]
		 add { } //Length: 176
		[CompilerGenerated]
		 remove { } //Length: 176
	}

	public event Action<LevelSimpleSpawnerBase, LevelSpawn> OnSpawnAction
	{
		[CompilerGenerated]
		 add { } //Length: 176
		[CompilerGenerated]
		 remove { } //Length: 176
	}

	public override int Multiplayer_ComponentIndex
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 8
	}

	protected LevelSimpleSpawnerBase() { }

	[CompilerGenerated]
	public void add_OnPostSpawnAction(Action<LevelItem> value) { }

	[CompilerGenerated]
	public void add_OnSpawnAction(Action<LevelSimpleSpawnerBase, LevelSpawn> value) { }

	protected override void Awake() { }

	protected override bool CanSpawn() { }

	private void DestroySelfIfNeeded() { }

	[CompilerGenerated]
	public override int get_Multiplayer_ComponentIndex() { }

	public abstract LevelSpawn GetPrefabToSpawn() { }

	public override void OnBeginDrag(PointerEventData eventData) { }

	public override void OnDrag(PointerEventData eventData) { }

	public override void OnPointerClick(PointerEventData eventData) { }

	public override void OnPointerDown(PointerEventData eventData) { }

	protected override void OnPostSpawn(LevelItem levelItem) { }

	protected override void OnSpawn(LevelSpawn levelSpawn) { }

	private override void PWC.Level.ICanListenForSecrets.OnSecretSolvedHandler() { }

	private override void PWC.Level.ICanListenForSecrets.OnSecretUnsolvedHandler() { }

	private override void PWC.Multiplayer.IMultiplayer_Messageable.Multiplayer_ReceiveMessage(MPEventIdentifierData idData, object objectData) { }

	[CompilerGenerated]
	public void remove_OnPostSpawnAction(Action<LevelItem> value) { }

	[CompilerGenerated]
	public void remove_OnSpawnAction(Action<LevelSimpleSpawnerBase, LevelSpawn> value) { }

	[CompilerGenerated]
	public override void set_Multiplayer_ComponentIndex(int value) { }

	public void SetColor(Color color) { }

	public override void SpawnOnClick() { }

	private bool TrySpawnForBeginDragCall(out LevelSpawn newInstance) { }

}

