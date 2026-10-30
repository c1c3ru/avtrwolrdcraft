namespace Game.Level;

public class LevelLinkedSlide : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <UpdateTransformBySlideSlope>d__33 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public LevelLinkedSlide <>4__this; //Field offset: 0x20

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
		public <UpdateTransformBySlideSlope>d__33(int <>1__state) { }

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
	private GameSoundPlayer _soundPlayer; //Field offset: 0x20
	[SerializeField]
	private bool _hasAnotherLinkedSlide; //Field offset: 0x28
	[SerializeField]
	private LevelCrossLevelDropArea _crossDropArea; //Field offset: 0x30
	[ConditionalField("_hasAnotherLinkedSlide", True, True, (array) null)]
	[SerializeField]
	private LevelLinkedSlide _levelLinkedSlide; //Field offset: 0x38
	[SerializeField]
	private EdgeCollider2D _slidePath; //Field offset: 0x40
	[SerializeField]
	private string _slideSoundName; //Field offset: 0x48
	[SerializeField]
	private float _slideTime; //Field offset: 0x50
	[SerializeField]
	private bool _flipRotationAngle; //Field offset: 0x54
	[SerializeField]
	private bool _isMasked; //Field offset: 0x55
	private Vector2[] _pathPoints; //Field offset: 0x58
	private LTSpline _spline; //Field offset: 0x60
	private ILevelAvatar _levelAvatar; //Field offset: 0x68
	private bool _isFlipped; //Field offset: 0x70
	protected Coroutine _slideTransformUpdateCoroutine; //Field offset: 0x78
	private List<LevelItem> items; //Field offset: 0x80
	private Vector2 _closestPosition; //Field offset: 0x88
	private Vector2[] _rampPoints; //Field offset: 0x90
	private Single[] _normalAnglesAtPoints; //Field offset: 0x98
	private Single[] _normalAnglesOfSegments; //Field offset: 0xA0
	private Single[] _slopeFactorOfSegments; //Field offset: 0xA8

	public LevelLinkedSlide() { }

	private void Awake() { }

	private void CalculateClosestPoint(Vector2 point, out int segmentIndex, out float t, out Vector2 closestPoint) { }

	private void CalculateNormalAnglesForEachPoint() { }

	private float CalculateSlopeFactor(int segmentIndex) { }

	private Vector3[] ConvertArray(Vector2[] v2) { }

	private float FindAngleFromPoints(Vector2 A, Vector2 B) { }

	private void FinishSlide() { }

	public void GetAngleAndClosestPointOfRamp(Vector2 skateBoardPos, out float angle, out Vector2 closestPoint) { }

	private float GetDistanceOfPointFromLine(Vector2 point, Vector2 A, Vector2 B, out float t, out Vector2 closestPoint) { }

	private void MoveToScene() { }

	private void MoveToTheNextSlide() { }

	private void OnDestroy() { }

	private void OnItemEndDropAction(LevelItem item) { }

	private void OnLevelPostInit() { }

	private bool OverrideCharacterEndDropAnimationAction(ILevelAvatar avatar) { }

	private void PlayMovingSound() { }

	private bool PreBeginDragOverride(DragDropItemBase _, PointerEventData eventData) { }

	private bool PreEndDragOverride(DragDropItemBase _, PointerEventData eventData) { }

	private void Slide(Action onCompleteAction = null) { }

	[IteratorStateMachine(typeof(<UpdateTransformBySlideSlope>d__33))]
	protected IEnumerator UpdateTransformBySlideSlope() { }

}

