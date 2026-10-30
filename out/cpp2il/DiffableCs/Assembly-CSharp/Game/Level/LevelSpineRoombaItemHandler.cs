namespace Game.Level;

public class LevelSpineRoombaItemHandler : MonoBehaviour, IHasPersistentData, IRequirePDSceneObject, ILevelSpawnDuringGameplay
{
	[CompilerGenerated]
	private sealed class <UpdatePositionCoroutine>d__21 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public LevelSpineRoombaItemHandler <>4__this; //Field offset: 0x20

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
		public <UpdatePositionCoroutine>d__21(int <>1__state) { }

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
	private ParticleSystem _particleSystem; //Field offset: 0x20
	[SerializeField]
	private GameSoundPlayer _soundPlayer; //Field offset: 0x28
	[SerializeField]
	private SkeletonAnimation _skeletonAnimation; //Field offset: 0x30
	private float _speed; //Field offset: 0x38
	private bool _isOn; //Field offset: 0x3C
	private int _moveDir; //Field offset: 0x40
	private int _tweenId; //Field offset: 0x44
	private LevelItem _levelItem; //Field offset: 0x48
	private Coroutine _moveCoroutine; //Field offset: 0x50

	private void _levelItem_OnEndLandAction(LevelDropArea obj) { }

	public LevelSpineRoombaItemHandler() { }

	private void Awake() { }

	private void EnsureOnReadyPostLoad() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	private void OnBeginDrag(DragDropItemBase arg1, PointerEventData arg2) { }

	private void OnClick(DragDropItemBase _, PointerEventData eventData) { }

	private void OnDestroy() { }

	private void OnLevelPostInit() { }

	public override void OnSpawnDuringGameplay() { }

	private void OnSpineAnimationEvent(TrackEntry trackEntry, Event e) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	private void Toggle() { }

	public void TurnOff() { }

	private void UpdateParticleSystem(bool state) { }

	[IteratorStateMachine(typeof(<UpdatePositionCoroutine>d__21))]
	private IEnumerator UpdatePositionCoroutine() { }

	private void UpdateSound(bool state) { }

	private void UpdateStateGraphics() { }

}

