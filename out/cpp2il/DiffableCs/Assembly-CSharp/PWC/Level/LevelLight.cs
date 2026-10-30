namespace PWC.Level;

[DisallowMultipleComponent]
public class LevelLight : MonoBehaviour, IPointerClickHandler, IEventSystemHandler, IHasPersistentData, IRequirePDSceneObject, IPointerDownHandler, ILevelSpawnDuringGameplay, ILevelMakerDisabledWhileInEditMode, ILevelMakerUIMenuItem
{
	[CompilerGenerated]
	private sealed class <Flicker>d__42 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public LevelLight <>4__this; //Field offset: 0x20

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
		public <Flicker>d__42(int <>1__state) { }

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

	internal enum ParticleSystemActivationType
	{
		None = 0,
		On = 1,
		Off = 2,
		Toggle = 3,
	}

	[SerializeField]
	protected bool _isOn; //Field offset: 0x20
	[SerializeField]
	private bool _isFlicker; //Field offset: 0x21
	[SerializeField]
	private GameObject[] _lightOnObjects; //Field offset: 0x28
	[SerializeField]
	private GameObject[] _lightOffObjects; //Field offset: 0x30
	[SerializeField]
	protected Sprite _onSprite; //Field offset: 0x38
	[SerializeField]
	protected Sprite _offSprite; //Field offset: 0x40
	[SerializeField]
	protected GameSoundPlayer _soundPlayer; //Field offset: 0x48
	[SerializeField]
	protected string _onSoundName; //Field offset: 0x50
	[SerializeField]
	protected string _offSoundName; //Field offset: 0x58
	[SerializeField]
	protected List<ParticleSystem> _particleSystems; //Field offset: 0x60
	[SerializeField]
	protected ParticleSystemActivationType _particleSystemActivationType; //Field offset: 0x68
	[SerializeField]
	protected SpriteRenderer _spriteRenderer; //Field offset: 0x70
	[SerializeField]
	private CShape _cShape; //Field offset: 0x78
	[Header("Spine")]
	[SerializeField]
	private bool _isSpineLoop; //Field offset: 0x80
	[SerializeField]
	private SkeletonAnimation _skeletonAnimation; //Field offset: 0x88
	[SerializeField]
	[SpineAnimation(null, "_skeletonAnimation", True, False, False)]
	private string _spineAnimationOn; //Field offset: 0x90
	[SerializeField]
	[SpineAnimation(null, "_skeletonAnimation", True, False, False)]
	private string _spineAnimationOff; //Field offset: 0x98
	[CompilerGenerated]
	private Action<Boolean> OnLampClickAction; //Field offset: 0xA0
	private LightSource[] _lightSources; //Field offset: 0xA8
	private LitSpriteRenderer _litSpriteRenderer; //Field offset: 0xB0
	[HideInInspector]
	protected ParticleSystem _particleSystem; //Field offset: 0xB8

	public event Action<Boolean> OnLampClickAction
	{
		[CompilerGenerated]
		 add { } //Length: 176
		[CompilerGenerated]
		 remove { } //Length: 176
	}

	public CShape CShape
	{
		 get { } //Length: 8
	}

	public bool IsOn
	{
		 get { } //Length: 8
	}

	public LevelLight() { }

	[CompilerGenerated]
	private void <SyncParticles>g__PlayParticle|41_0(ParticleSystem system) { }

	[CompilerGenerated]
	public void add_OnLampClickAction(Action<Boolean> value) { }

	private void Awake() { }

	[IteratorStateMachine(typeof(<Flicker>d__42))]
	private IEnumerator Flicker() { }

	public CShape get_CShape() { }

	public bool get_IsOn() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	public SpriteRenderer GetSpriteRenderer() { }

	public bool IsLightOn() { }

	private void OnDestroy() { }

	private void OnLevelPostInit() { }

	public override void OnPointerClick(PointerEventData eventData) { }

	public override void OnPointerDown(PointerEventData eventData) { }

	private void OnReadyPostLoad() { }

	protected override void PlaySound() { }

	private override void PWC.Level.ILevelSpawnDuringGameplay.OnSpawnDuringGameplay() { }

	private override void PWC.Level.Maker.ILevelMakerUIMenuItem.OnCreatedInsideUIItem() { }

	public void RemoteClick() { }

	[CompilerGenerated]
	public void remove_OnLampClickAction(Action<Boolean> value) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	public void SetState(bool isOn) { }

	public void SetStateSilent(bool isOn) { }

	protected override void SyncParticles() { }

	protected override void SyncState(bool snap = false, bool shouldSyncParticles = true) { }

}

