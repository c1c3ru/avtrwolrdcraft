namespace Game.Level;

public class LevelPC : LevelStationaryItem, IPointerClickHandler, IEventSystemHandler, IHasPersistentData, IRequirePDSceneObject
{
	[CompilerGenerated]
	private bool <IsInteractable>k__BackingField; //Field offset: 0x60
	[SerializeField]
	private Sprite _onSprite; //Field offset: 0x68
	[SerializeField]
	private Sprite _offSprite; //Field offset: 0x70
	[SerializeField]
	private GameSoundPlayer _soundPlayer; //Field offset: 0x78
	[SerializeField]
	private LevelPCMonitor _pcMonitor; //Field offset: 0x80
	[SerializeField]
	private List<ParticleSystem> _particleSystems; //Field offset: 0x88
	private bool _isOn; //Field offset: 0x90

	public private bool IsInteractable
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 12
	}

	public LevelPC() { }

	[CompilerGenerated]
	private void <OnClick>b__12_0() { }

	[CompilerGenerated]
	private void <OnClick>b__12_1() { }

	[CompilerGenerated]
	private void <ParticleSystemsSetActive>b__16_0(ParticleSystem particleSystem) { }

	[CompilerGenerated]
	public bool get_IsInteractable() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	private void OnClick() { }

	public void OnPCMonitorClick(bool isOn) { }

	public override void OnPointerClick(PointerEventData eventData) { }

	private void ParticleSystemsSetActive() { }

	private float PlayOnOffSound() { }

	[CompilerGenerated]
	private void set_IsInteractable(bool value) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	private void SyncState() { }

	private void ToggleAudioLoop() { }

}

