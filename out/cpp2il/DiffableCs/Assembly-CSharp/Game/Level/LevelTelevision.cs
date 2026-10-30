namespace Game.Level;

[AddComponentMenu(null)]
public class LevelTelevision : LevelStationaryItem, IPointerClickHandler, IEventSystemHandler, IHasPersistentData, IRequirePDSceneObject
{
	[CompilerGenerated]
	private sealed class <ImagesAnimation>d__26 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public LevelTelevision <>4__this; //Field offset: 0x20
		private int <i>5__2; //Field offset: 0x28

		private override object System.Collections.Generic.IEnumerator<System.Object>.Current
		{
			[DebuggerHidden]
			private get { } //Length: 8
		}

		private override object System.Collections.IEnumerator.Current
		{
			[DebuggerHidden]
			private get { } //Length: 8
		}

		[DebuggerHidden]
		public <ImagesAnimation>d__26(int <>1__state) { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}

	[CompilerGenerated]
	private static Action<Boolean> OnSyncStateAction; //Field offset: 0x0
	[SerializeField]
	private SpriteRenderer _screenImage; //Field offset: 0x60
	[SerializeField]
	private Sprite[] _onSprites; //Field offset: 0x68
	[SerializeField]
	private GameSoundPlayer _soundPlayer; //Field offset: 0x70
	[SerializeField]
	private float _volume; //Field offset: 0x78
	[SerializeField]
	private string _generalTVSoundName; //Field offset: 0x80
	[SerializeField]
	private Sprite _consoleGameSprite; //Field offset: 0x88
	[SerializeField]
	private GameObject _carpetGameSpine; //Field offset: 0x90
	[SerializeField]
	private LevelStationaryConsole _stationaryConsole; //Field offset: 0x98
	private readonly WaitForSeconds _waitBetweenFrames; //Field offset: 0xA0
	private bool _isOn; //Field offset: 0xA8
	private bool _isConsoleGame; //Field offset: 0xA9
	private bool _isCarpetGame; //Field offset: 0xAA
	private bool _hasPersistentData; //Field offset: 0xAB

	public static event Action<Boolean> OnSyncStateAction
	{
		[CompilerGenerated]
		 add { } //Length: 204
		[CompilerGenerated]
		 remove { } //Length: 204
	}

	public bool IsCarpetGame
	{
		 get { } //Length: 8
	}

	public LevelTelevision() { }

	[CompilerGenerated]
	private void <OnPointerClick>b__21_0() { }

	[CompilerGenerated]
	public static void add_OnSyncStateAction(Action<Boolean> value) { }

	protected virtual void Awake() { }

	public bool get_IsCarpetGame() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	[IteratorStateMachine(typeof(<ImagesAnimation>d__26))]
	private IEnumerator ImagesAnimation() { }

	public void OnConsoleClick() { }

	protected virtual void OnDestroy() { }

	private void OnGameSetActive(bool value) { }

	private void OnLevelPostInit() { }

	public override void OnPointerClick(PointerEventData eventData) { }

	[CompilerGenerated]
	public static void remove_OnSyncStateAction(Action<Boolean> value) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	private void SyncSound() { }

	private void SyncState() { }

}

