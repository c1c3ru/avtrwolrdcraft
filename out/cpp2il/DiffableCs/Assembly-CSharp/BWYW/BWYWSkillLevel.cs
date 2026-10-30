namespace BWYW;

public class BWYWSkillLevel : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <AnimateCoroutine>d__8 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public BWYWSkillLevel <>4__this; //Field offset: 0x20
		public bool isIncrement; //Field offset: 0x28
		public Action onLevelIncremented; //Field offset: 0x30
		private int <levelText>5__2; //Field offset: 0x38
		private Vector3 <startScale>5__3; //Field offset: 0x3C
		private float <startZRotation>5__4; //Field offset: 0x48

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
		public <AnimateCoroutine>d__8(int <>1__state) { }

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

	[Header("Scene References")]
	[SerializeField]
	private TMP_Text _skillLevelText; //Field offset: 0x20
	[SerializeField]
	private GameObject _skillLevelParent; //Field offset: 0x28
	[Header("Settings")]
	[Range(0.1, 2)]
	[SerializeField]
	private float _animationTime; //Field offset: 0x30
	[Range(-90, 90)]
	[SerializeField]
	private int _angleOnIncrement; //Field offset: 0x34
	[Range(1, 5)]
	[SerializeField]
	private float _scaleOnIncrement; //Field offset: 0x38
	[Header("Event")]
	[SerializeField]
	private UnityEvent _onLevelIncrementedEvent; //Field offset: 0x40

	public BWYWSkillLevel() { }

	[IteratorStateMachine(typeof(<AnimateCoroutine>d__8))]
	private IEnumerator AnimateCoroutine(bool isIncrement, Action onLevelIncremented) { }

	public void IncrementLevel(bool isIncrement, Action onLevelIncremented = null) { }

	[ContextMenu("Increment Level")]
	public void IncrementLevelFromInspector() { }

	public void SetCurrentLevel(int currentlevel) { }

}

