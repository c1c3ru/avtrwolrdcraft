namespace Game.Level;

public class LevelBoardGameBoard : LevelItem
{
	private const int TRACK_INDEX = 0; //Field offset: 0x0
	private const string CLOSE_ANIMATION_NAME = "close"; //Field offset: 0x0
	private const string CLOSE_IDLE_ANIMATION_NAME = "close_idle"; //Field offset: 0x0
	private const string OPEN_ANIMATION_NAME = "open"; //Field offset: 0x0
	private const string OPEN_IDLE_ANIMATION_NAME = "open_idle"; //Field offset: 0x0
	private const float SPINE_OPENED_X_POSITION = 0; //Field offset: 0x0
	private const float SPINE_CLOSED_X_POSITION = 0,73; //Field offset: 0x0
	[SerializeField]
	private SkeletonAnimation _skeletonAnimation; //Field offset: 0x348
	[SerializeField]
	private GameObject _openCShape; //Field offset: 0x350
	[SerializeField]
	private GameObject _closeCShape; //Field offset: 0x358
	[SerializeField]
	private LevelDropArea _dropArea; //Field offset: 0x360
	[SerializeField]
	private GameSoundPlayer _gameSoundPlayer; //Field offset: 0x368
	private bool _isOpen; //Field offset: 0x370

	public LevelBoardGameBoard() { }

	[CompilerGenerated]
	private void <SyncState>b__15_0(TrackEntry x) { }

	private void ChangeState() { }

	public virtual Dictionary<String, Object> GetPersistentData() { }

	protected virtual void OnPointerClickInternal(PointerEventData eventData) { }

	public virtual void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	private void SyncState(bool snap) { }

}

