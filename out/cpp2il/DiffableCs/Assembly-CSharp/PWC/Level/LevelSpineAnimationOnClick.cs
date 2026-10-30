namespace PWC.Level;

public class LevelSpineAnimationOnClick : MonoBehaviour, IPointerClickHandler, IEventSystemHandler, IHasPersistentData, IRequirePDSceneObject, ILevelMakerDisabledWhileInEditMode
{
	[CompilerGenerated]
	private sealed class <AutoToggleBackCoroutine>d__12 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public LevelSpineAnimationOnClick <>4__this; //Field offset: 0x20

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
		public <AutoToggleBackCoroutine>d__12(int <>1__state) { }

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
	private SkeletonAnimation _skeletonAnimation; //Field offset: 0x20
	[SerializeField]
	private bool _isToggleAnimation; //Field offset: 0x28
	[ConditionalField("_isToggleAnimation", True, True, (array) null)]
	[SerializeField]
	private float _autoToggleBackDuration; //Field offset: 0x2C
	[SerializeField]
	private GameSoundPlayer _soundPlayer; //Field offset: 0x30
	[SerializeField]
	private string _soundName; //Field offset: 0x38
	[SerializeField]
	[SpineAnimation(null, "_skeletonAnimation", True, False, False)]
	private string _clickAnimation; //Field offset: 0x40
	[SerializeField]
	[SpineAnimation(null, "_skeletonAnimation", True, False, False)]
	private string _idleAnimation; //Field offset: 0x48

	public LevelSpineAnimationOnClick() { }

	[IteratorStateMachine(typeof(<AutoToggleBackCoroutine>d__12))]
	private IEnumerator AutoToggleBackCoroutine() { }

	private void Awake() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	private void OnDestroy() { }

	private void OnLevelPostInit() { }

	public override void OnPointerClick(PointerEventData eventData) { }

	public void RemoteClick() { }

	public void SetIdleAnimation() { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	private void SoundSetActive(bool value) { }

}

