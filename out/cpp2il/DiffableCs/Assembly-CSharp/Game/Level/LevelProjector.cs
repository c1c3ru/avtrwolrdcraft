namespace Game.Level;

public class LevelProjector : LevelFoldableItem, IMultiplayer_TransformChange
{
	[CompilerGenerated]
	private sealed class <OnLandCoroutine>d__25 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public LevelProjector <>4__this; //Field offset: 0x20

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
		public <OnLandCoroutine>d__25(int <>1__state) { }

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
	private static Action<LevelProjector> OnProjectorToggleStateAction; //Field offset: 0x0
	[CompilerGenerated]
	private static Action<LevelProjector> OnPictureSyncPositionAction; //Field offset: 0x8
	[CompilerGenerated]
	private Action<Int32> OnPictureIndexSetAction; //Field offset: 0x390
	[SerializeField]
	private SpriteRenderer _picture; //Field offset: 0x398
	[SerializeField]
	private Sprite[] _sprites; //Field offset: 0x3A0
	private int _pictureIndex; //Field offset: 0x3A8
	private Coroutine _onLandCoroutine; //Field offset: 0x3B0

	public event Action<Int32> OnPictureIndexSetAction
	{
		[CompilerGenerated]
		 add { } //Length: 180
		[CompilerGenerated]
		 remove { } //Length: 180
	}

	public static event Action<LevelProjector> OnPictureSyncPositionAction
	{
		[CompilerGenerated]
		 add { } //Length: 208
		[CompilerGenerated]
		 remove { } //Length: 208
	}

	public static event Action<LevelProjector> OnProjectorToggleStateAction
	{
		[CompilerGenerated]
		 add { } //Length: 204
		[CompilerGenerated]
		 remove { } //Length: 204
	}

	public bool IsOn
	{
		 get { } //Length: 8
	}

	public SpriteRenderer Picture
	{
		 get { } //Length: 8
	}

	public LevelProjector() { }

	[CompilerGenerated]
	public void add_OnPictureIndexSetAction(Action<Int32> value) { }

	[CompilerGenerated]
	public static void add_OnPictureSyncPositionAction(Action<LevelProjector> value) { }

	[CompilerGenerated]
	public static void add_OnProjectorToggleStateAction(Action<LevelProjector> value) { }

	protected virtual void Awake() { }

	public bool get_IsOn() { }

	public SpriteRenderer get_Picture() { }

	public int GetActualSortingOrder() { }

	public virtual Dictionary<String, Object> GetPersistentData() { }

	protected virtual void OnBeginLand(LevelDropArea dropArea) { }

	protected virtual LevelDropArea OnEndLand() { }

	[IteratorStateMachine(typeof(<OnLandCoroutine>d__25))]
	private IEnumerator OnLandCoroutine() { }

	protected virtual void OnParentBeginLand(LevelItem parentLevelItem, LevelDropArea dropArea) { }

	protected virtual void OnParentEndLand(LevelItem parentLevelItem, LevelDropArea dropArea) { }

	protected virtual void OnParentSyncPosition(LevelItem parentLevelItem, Vector2 pointerPosition) { }

	protected virtual void OnSyncPosition(Vector2 pointerPosition) { }

	private override void PWC.Multiplayer.IMultiplayer_TransformChange.Multiplayer_OnTransformChange() { }

	[CompilerGenerated]
	public void remove_OnPictureIndexSetAction(Action<Int32> value) { }

	[CompilerGenerated]
	public static void remove_OnPictureSyncPositionAction(Action<LevelProjector> value) { }

	[CompilerGenerated]
	public static void remove_OnProjectorToggleStateAction(Action<LevelProjector> value) { }

	public virtual void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	protected virtual void ToggleState() { }

}

