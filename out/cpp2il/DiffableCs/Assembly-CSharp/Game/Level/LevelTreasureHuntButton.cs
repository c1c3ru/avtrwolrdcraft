namespace Game.Level;

public class LevelTreasureHuntButton : MonoBehaviour, IHasPersistentData, IRequirePDSceneObject, ILevelSpawnDuringGameplay
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass14_0
	{
		public int finishCounter; //Field offset: 0x10
		public LevelItem[] levelItemsToHide; //Field offset: 0x18
		public Action <>9__0; //Field offset: 0x20
		public Action <>9__2; //Field offset: 0x28

		public <>c__DisplayClass14_0() { }

		internal void <PlayItemsFlyingAway>b__0() { }

		internal void <PlayItemsFlyingAway>b__2() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass14_1
	{
		public Vector2 position; //Field offset: 0x10
		public float xStart; //Field offset: 0x18
		public float xEnd; //Field offset: 0x1C
		public Vector2 startPosition; //Field offset: 0x20
		public float yEnd; //Field offset: 0x28
		public GameObject obj; //Field offset: 0x30

		public <>c__DisplayClass14_1() { }

		internal void <PlayItemsFlyingAway>b__1(float value) { }

	}

	[CompilerGenerated]
	private sealed class <PlayItemsFlyingAway>d__14 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public LevelTreasureHuntButton <>4__this; //Field offset: 0x20
		private <>c__DisplayClass14_0 <>8__1; //Field offset: 0x28
		private List<Transform> <flyingItems>5__2; //Field offset: 0x30

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
		public <PlayItemsFlyingAway>d__14(int <>1__state) { }

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

	[SerializeField]
	private LevelDropArea _dropArea; //Field offset: 0x20
	[SerializeField]
	private List<LevelDropArea> _preventedDropAreas; //Field offset: 0x28
	[SerializeField]
	private LevelButton _button; //Field offset: 0x30
	[SerializeField]
	private float _chanceToHideInHiddenDropArea; //Field offset: 0x38
	private bool _wasPressed; //Field offset: 0x3C

	public LevelTreasureHuntButton() { }

	private void Awake() { }

	private void EnsureOnReadyPostLoad() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	private Vector2[] HideAllItemsInLevel(LevelItem[] levelItemsToHide) { }

	public void OnClick() { }

	private void OnDestroy() { }

	private void OnItemEndDrop(LevelItem levelItem) { }

	private void OnItemPickUp(LevelItem levelItem) { }

	private void OnLevelPostInit() { }

	public override void OnSpawnDuringGameplay() { }

	[IteratorStateMachine(typeof(<PlayItemsFlyingAway>d__14))]
	public IEnumerator PlayItemsFlyingAway() { }

	private void SetInactiveLevelItems() { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	private void UpdateButtonState() { }

}

