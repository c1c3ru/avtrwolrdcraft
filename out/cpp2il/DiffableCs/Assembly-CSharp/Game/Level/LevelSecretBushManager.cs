namespace Game.Level;

public class LevelSecretBushManager : MonoBehaviour, IHasPersistentData, IRequirePDSceneObject
{
	[CompilerGenerated]
	private sealed class <Blink>d__9 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public LevelSecretBushManager <>4__this; //Field offset: 0x20
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
		public <Blink>d__9(int <>1__state) { }

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
	private List<LevelSlider> _levelSliders; //Field offset: 0x20
	[SerializeField]
	private List<LevelToggleableSprite> _levelToggleableSprites; //Field offset: 0x28
	[SerializeField]
	private LevelDropArea _secretDropArea; //Field offset: 0x30
	[SerializeField]
	private UnityEvent _onSecretSolved; //Field offset: 0x38
	private bool _isOpen; //Field offset: 0x40
	private bool _wasOpenFirstTime; //Field offset: 0x41

	public LevelSecretBushManager() { }

	private void Awake() { }

	[IteratorStateMachine(typeof(<Blink>d__9))]
	private IEnumerator Blink() { }

	private void CheckAllToggleables(int i) { }

	public override Dictionary<String, Object> GetPersistentData() { }

	private void OnDestroy() { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

}

