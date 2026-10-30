namespace Game.Level;

public class LevelHairColorSpray : LevelSimpleDragActionCharacterAreaBase, ILevelMakerUIMenuItem, IMultiplayer_Messageable, IMultiplayer_NetworkIdentityBase
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass22_0
	{
		public LevelCharacter target; //Field offset: 0x10
		public LevelHairColorSpray <>4__this; //Field offset: 0x18

		public <>c__DisplayClass22_0() { }

		internal void <OnTargetEnter>b__0() { }

	}

	[SerializeField]
	protected Color _colorTop; //Field offset: 0x358
	[SerializeField]
	protected Color _colorBottom; //Field offset: 0x368
	[SerializeField]
	private ParticleSystem _particleSystem; //Field offset: 0x378
	[SerializeField]
	protected GameSoundPlayer _gameSoundPlayer; //Field offset: 0x380
	[SerializeField]
	private string _soundName; //Field offset: 0x388
	[SerializeField]
	protected SpriteRenderer _topColorSprite; //Field offset: 0x390
	[SerializeField]
	protected SpriteRenderer _bottomColorSprite; //Field offset: 0x398
	private int _targetCounter; //Field offset: 0x3A0
	protected List<LevelCharacter> _targetedLevelCharacters; //Field offset: 0x3A8
	[CompilerGenerated]
	private bool <IsManualEffectsControl>k__BackingField; //Field offset: 0x3B0

	public bool IsManualEffectsControl
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 12
	}

	public LevelHairColorSpray() { }

	protected virtual void Awake() { }

	public override void ColorTarget(LevelCharacter target) { }

	protected virtual bool FilterTarget(ILevelConsumer target) { }

	public void ForceEnterTarget(LevelCharacter target) { }

	public void ForceExitTarget(LevelCharacter target) { }

	[CompilerGenerated]
	public bool get_IsManualEffectsControl() { }

	public virtual AreaType GetAreaTypeToCheck() { }

	protected override void InitColorSprites() { }

	private void InitParticlesColor() { }

	private void Multiplayer_ShouldSendEnterAndExitEvents(ref bool value) { }

	protected virtual void OnDestroy() { }

	protected virtual void OnEndDragInternal(PointerEventData eventData) { }

	protected virtual void OnTargetEnter(ILevelConsumer consumer) { }

	protected virtual void OnTargetExit(ILevelConsumer consumer) { }

	private override void PWC.Level.Maker.ILevelMakerUIMenuItem.OnCreatedInsideUIItem() { }

	private override void PWC.Multiplayer.IMultiplayer_Messageable.Multiplayer_ReceiveMessage(MPEventIdentifierData idData, object objectData) { }

	[CompilerGenerated]
	public void set_IsManualEffectsControl(bool value) { }

	public void StartSprayEffects() { }

	public void StopSprayEffects() { }

}

