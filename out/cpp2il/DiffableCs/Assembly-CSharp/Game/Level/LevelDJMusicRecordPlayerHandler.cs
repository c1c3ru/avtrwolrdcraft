namespace Game.Level;

public class LevelDJMusicRecordPlayerHandler : MusicRecordPlayerHandlerBase, IHasPersistentData, IRequirePDSceneObject, IItemsHolderArea
{
	[SerializeField]
	private LevelDJMusicRecordPlayerHandler _otherLevelDJMusicRecordPlayerHandler; //Field offset: 0x68
	[SerializeField]
	private ParticleSystem _particleSystem; //Field offset: 0x70
	[SerializeField]
	private GameSoundPlayer _soundPlayer; //Field offset: 0x78
	[SerializeField]
	private LevelButton _powerButton; //Field offset: 0x80
	[SerializeField]
	private LevelButton _soundEffectsButton; //Field offset: 0x88
	[SerializeField]
	private LevelSlider _levelVolumeSlider; //Field offset: 0x90
	[SerializeField]
	private LevelSlider _levelSpeedSlider; //Field offset: 0x98
	[SerializeField]
	private string _soundEffectButtonSound; //Field offset: 0xA0
	[SerializeField]
	private bool _isOn; //Field offset: 0xA8
	[SerializeField]
	private Transform _dropPoint; //Field offset: 0xB0
	private float _volume; //Field offset: 0xB8
	private float _pitch; //Field offset: 0xBC
	private int _recordTweenId; //Field offset: 0xC0
	private Camera _camera; //Field offset: 0xC8
	private Vector2 _recordOnPlayerStartPosition; //Field offset: 0xD0
	[CompilerGenerated]
	private Action<LevelItem> OnItemsHolderItemEndDropAction; //Field offset: 0xD8

	public override event Action<LevelItem> OnItemsHolderItemEndDropAction
	{
		[CompilerGenerated]
		 add { } //Length: 176
		[CompilerGenerated]
		 remove { } //Length: 176
	}

	private void _levelSpeedSliderOnSyncPosition(DragDropItemBase dragDropItemBase, Vector2 vector2) { }

	private void _levelVolumeSliderOnSyncPosition(DragDropItemBase dragDropItemBase, Vector2 vector2) { }

	public LevelDJMusicRecordPlayerHandler() { }

	[CompilerGenerated]
	public override void add_OnItemsHolderItemEndDropAction(Action<LevelItem> value) { }

	protected virtual void Awake() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	public override bool HasItemsOnSelf() { }

	protected virtual void OnDestroy() { }

	public virtual void OnPointerClick(PointerEventData eventData) { }

	protected virtual bool OnPreBeginDrag(GameObject receiver, PointerEventData eventData) { }

	protected virtual bool OnPreClick(GameObject receiver, PointerEventData eventData) { }

	public void OnSoundEffectButtonPress() { }

	public void OnSoundEffectButtonRelease() { }

	private void OnSpeedSliderEndAnimation(SliderDestinationType sliderDestinationType) { }

	private void OnVolumeSliderEndAnimation(SliderDestinationType sliderDestinationType) { }

	public void PowerButton() { }

	public virtual void PutRecord(LevelMusicRecord record, bool forceTurnOn = true) { }

	public override void ReleaseItems() { }

	[CompilerGenerated]
	public override void remove_OnItemsHolderItemEndDropAction(Action<LevelItem> value) { }

	private void ResetPitchAndVolume() { }

	public void SetButtonState(bool state) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	public void SetState(bool isOn) { }

	private void SyncState() { }

	private void ToggleMusic() { }

}

