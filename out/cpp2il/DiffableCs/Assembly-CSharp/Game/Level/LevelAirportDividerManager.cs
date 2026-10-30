namespace Game.Level;

public class LevelAirportDividerManager : MonoBehaviour, IHasPersistentData, IRequirePDSceneObject
{
	public const int NUMBER_OF_ROWS = 4; //Field offset: 0x0
	public const int NUMBER_OF_COLUMNS = 4; //Field offset: 0x0
	[SerializeField]
	protected LevelAirportDividerHandler[] _allDividers; //Field offset: 0x20
	[SerializeField]
	protected SkeletonAnimation[] _horizontalDividerSpines; //Field offset: 0x28
	[SerializeField]
	protected SkeletonAnimation[] _verticalDividerSpines; //Field offset: 0x30
	[SerializeField]
	protected LevelSecretSolveBroadcaster _levelSecretSolveBroadcaster; //Field offset: 0x38
	[SerializeField]
	private GameSoundPlayer _soundPlayer; //Field offset: 0x40
	[SerializeField]
	protected string _releaseSoundName; //Field offset: 0x48
	[SerializeField]
	protected string _attachedSoundName; //Field offset: 0x50
	private LevelAirportDividerHandler _firstTarget; //Field offset: 0x58
	private LevelAirportDividerHandler _secondTarget; //Field offset: 0x60
	private int _firstIndex; //Field offset: 0x68
	private int _secondIndex; //Field offset: 0x6C
	private int _tweenID; //Field offset: 0x70
	private Int32[] _targetShape; //Field offset: 0x78

	public LevelAirportDividerHandler FirstTarget
	{
		 get { } //Length: 8
	}

	public LevelAirportDividerHandler SecondTarget
	{
		 get { } //Length: 8
	}

	public LevelAirportDividerManager() { }

	[CompilerGenerated]
	private void <SetSecondTarget>b__21_0() { }

	private void CheckOverallShape() { }

	public LevelAirportDividerHandler get_FirstTarget() { }

	public LevelAirportDividerHandler get_SecondTarget() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	public void ResetTarget() { }

	public void SetFirstTarget(LevelAirportDividerHandler levelAirportDividerHandler) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	public void SetSecondTarget(LevelAirportDividerHandler levelAirportDividerHandler) { }

}

