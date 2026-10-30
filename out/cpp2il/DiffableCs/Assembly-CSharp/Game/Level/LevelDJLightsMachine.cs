namespace Game.Level;

public class LevelDJLightsMachine : MonoBehaviour, IHasPersistentData, IRequirePDSceneObject
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass28_0
	{
		public List<LevelColorChangingLight> selectedLights; //Field offset: 0x10
		public LevelDJLightsMachine <>4__this; //Field offset: 0x18
		public Action<Single> <>9__2; //Field offset: 0x20

		public <>c__DisplayClass28_0() { }

		internal void <DampenLights>b__0(float t) { }

		internal void <DampenLights>b__1() { }

		internal void <DampenLights>b__2(float t) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass30_0
	{
		public LevelColorChangingLight light; //Field offset: 0x10
		public Color currentColor; //Field offset: 0x18
		public Color nextColor; //Field offset: 0x28
		public int randomColorIndex; //Field offset: 0x38

		public <>c__DisplayClass30_0() { }

		internal void <ColorLerping>b__0(float t) { }

		internal void <ColorLerping>b__1() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass30_1
	{
		public LevelColorChangingLight reflectionLight; //Field offset: 0x10
		public <>c__DisplayClass30_0 CS$<>8__locals1; //Field offset: 0x18

		public <>c__DisplayClass30_1() { }

		internal void <ColorLerping>b__2(float t) { }

		internal void <ColorLerping>b__3() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass31_0
	{
		public LevelColorChangingLight light; //Field offset: 0x10
		public Color currentColor; //Field offset: 0x18
		public Color nextColor; //Field offset: 0x28

		public <>c__DisplayClass31_0() { }

		internal void <ColorLerping>b__0(float t) { }

	}

	[CompilerGenerated]
	private sealed class <RaveLights>d__27 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public LevelDJLightsMachine <>4__this; //Field offset: 0x20

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
		public <RaveLights>d__27(int <>1__state) { }

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
	private LevelDJMusicRecordPlayerHandler _leftDJMachine; //Field offset: 0x20
	[SerializeField]
	private LevelDJMusicRecordPlayerHandler _righttDJMachine; //Field offset: 0x28
	[SerializeField]
	private List<LevelColorChangingLight> _allDJLights; //Field offset: 0x30
	[SerializeField]
	private LevelButton _activationButton; //Field offset: 0x38
	[SerializeField]
	private float _beatTiming; //Field offset: 0x40
	[SerializeField]
	private LevelSingleItemCharactersOnlyDropArea _djDropArea; //Field offset: 0x48
	[SerializeField]
	private LevelSpawner _spawner; //Field offset: 0x50
	[SerializeField]
	private LevelSpawn[] _sticklights; //Field offset: 0x58
	[SerializeField]
	private Transform[] _throwLocations; //Field offset: 0x60
	[SerializeField]
	private bool _isOn; //Field offset: 0x68
	[SerializeField]
	private UnityEvent _onThrownSticklightEvent; //Field offset: 0x70
	private List<Color> _colorOptions; //Field offset: 0x78
	private Coroutine raveLights; //Field offset: 0x80
	private bool _hasCharacter; //Field offset: 0x88
	private LevelCharacter _djCharacter; //Field offset: 0x90
	private int _maxNumberOfAllowedSwitchingLights; //Field offset: 0x98

	public LevelDJLightsMachine() { }

	[CompilerGenerated]
	private void <ActivationButtonAction>b__26_0() { }

	[CompilerGenerated]
	private void <ActivationButtonAction>b__26_1() { }

	public void ActivationButton() { }

	private void ActivationButtonAction() { }

	protected void Awake() { }

	private void ColorLerping(LevelColorChangingLight light) { }

	private void ColorLerping(LevelColorChangingLight light, Color targetColor) { }

	private void DampenLights(List<LevelColorChangingLight> selectedLights) { }

	public override Dictionary<String, Object> GetPersistentData() { }

	private void InitNozzleIfNeeded() { }

	public void MatchAllLightsReflections() { }

	public void OnDanceFloorLightClick() { }

	protected void OnDestroy() { }

	private void OnItemBeginDrop(LevelItem levelItem) { }

	private void OnItemPickUp(LevelItem levelItem) { }

	private void RandomColors(List<LevelColorChangingLight> selectedLights) { }

	[IteratorStateMachine(typeof(<RaveLights>d__27))]
	private IEnumerator RaveLights() { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	private void SetThrowDestination(LevelSticklightItemHandler sticklightItemHandler) { }

	private void ThrowSticklightAction(int sticklightColor) { }

}

