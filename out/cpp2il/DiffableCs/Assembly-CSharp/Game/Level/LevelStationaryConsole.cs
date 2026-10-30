namespace Game.Level;

public class LevelStationaryConsole : LevelStationaryItem, IPointerClickHandler, IEventSystemHandler, IHasPersistentData, IRequirePDSceneObject
{
	[CompilerGenerated]
	private bool <IsInteractable>k__BackingField; //Field offset: 0x60
	[CompilerGenerated]
	private bool <IsOn>k__BackingField; //Field offset: 0x61
	[SerializeField]
	private GameSoundPlayer _soundPlayer; //Field offset: 0x68
	[SerializeField]
	private Sprite _onSprite; //Field offset: 0x70
	[SerializeField]
	private Sprite _offSprite; //Field offset: 0x78
	[SerializeField]
	private LevelTelevision _television; //Field offset: 0x80

	public private bool IsInteractable
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 12
	}

	public private bool IsOn
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 12
	}

	public LevelStationaryConsole() { }

	[CompilerGenerated]
	private void <OnPointerClick>b__12_0() { }

	[CompilerGenerated]
	private void <OnPointerClick>b__12_1() { }

	[CompilerGenerated]
	private void <OnTelevisionClick>b__13_0() { }

	[CompilerGenerated]
	public bool get_IsInteractable() { }

	[CompilerGenerated]
	public bool get_IsOn() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	public override void OnPointerClick(PointerEventData eventData) { }

	public void OnTelevisionClick() { }

	private float PlayOnOffSound() { }

	[CompilerGenerated]
	private void set_IsInteractable(bool value) { }

	[CompilerGenerated]
	private void set_IsOn(bool value) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	private void SyncState() { }

}

