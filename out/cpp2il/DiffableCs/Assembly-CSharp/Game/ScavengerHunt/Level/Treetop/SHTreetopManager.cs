namespace Game.ScavengerHunt.Level.Treetop;

public class SHTreetopManager : MonoBehaviour
{
	[SerializeField]
	private ScavengerHuntType _scavengerHuntType; //Field offset: 0x20
	[SerializeField]
	private LevelDropArea _dropArea; //Field offset: 0x28
	[SerializeField]
	private SHTreetopStartGameButton _startGameButton; //Field offset: 0x30
	[SerializeField]
	private SHTreetopTimer _timer; //Field offset: 0x38
	[SerializeField]
	private SHTreetopItemsPreview _itemsPreview; //Field offset: 0x40
	[SerializeField]
	private SHTreetopRewardHandler _rewardHandler; //Field offset: 0x48
	[SerializeField]
	private PDPrefab _collectingBoxPrefab; //Field offset: 0x50
	[SerializeField]
	private LevelDropArea _rewardTableDropArea; //Field offset: 0x58
	[SerializeField]
	private GameSoundPlayer _soundPlayer; //Field offset: 0x60
	[SerializeField]
	private UnityEvent _onHuntCompleted; //Field offset: 0x68
	private ScavengerHuntTypeHandler _handler; //Field offset: 0x70

	public ScavengerHuntTypeHandler Handler
	{
		 get { } //Length: 8
	}

	public SHTreetopManager() { }

	[CompilerGenerated]
	private void <StartNextGame>b__14_0() { }

	private void Awake() { }

	public ScavengerHuntTypeHandler get_Handler() { }

	private void OnDestroy() { }

	private void OnGameCompleted() { }

	private void OnItemEndDrop(LevelItem levelItem) { }

	private void OnItemPickUp(LevelItem levelItem) { }

	private void OnLevelPostInit() { }

	private void OnRequiredItemAdded(PDPrefab pdPrefab) { }

	private void OnRequiredItemRemoved(PDPrefab pdPrefab) { }

	private void OnTimeLeftChanged(int timeLeft) { }

	private void OnTimeUp() { }

	private void SpawnCollectingBox() { }

	public void StartNextGame() { }

	private void SyncLevelWithGame() { }

}

