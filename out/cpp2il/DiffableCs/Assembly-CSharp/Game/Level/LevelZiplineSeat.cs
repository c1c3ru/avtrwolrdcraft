namespace Game.Level;

public class LevelZiplineSeat : DragDropItemBase, IHasPersistentData, IRequirePDSceneObject
{
	[CompilerGenerated]
	private sealed class <SyncPosition>d__5 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public LevelZiplineSeat <>4__this; //Field offset: 0x20
		private Vector2 <worldSpaceOffset>5__2; //Field offset: 0x28

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
		public <SyncPosition>d__5(int <>1__state) { }

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
	private LevelZiplineSeatMoveArea _moveArea; //Field offset: 0x110
	[SerializeField]
	private GameSoundPlayer _soundPlayer; //Field offset: 0x118
	private float _minXPosition; //Field offset: 0x120
	private float _maxXPosition; //Field offset: 0x124

	public LevelZiplineSeat() { }

	[CompilerGenerated]
	private void <AnimateToClosestSide>b__9_0(float _) { }

	[CompilerGenerated]
	private void <AnimateToClosestSide>b__9_1() { }

	public void AnimateToClosestSide() { }

	protected virtual void Awake() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	protected virtual void OnBeginDragInternal(PointerEventData eventData) { }

	protected virtual void OnPointerClickInternal(PointerEventData eventData) { }

	private void PlaySound() { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	[IteratorStateMachine(typeof(<SyncPosition>d__5))]
	protected virtual IEnumerator SyncPosition() { }

}

