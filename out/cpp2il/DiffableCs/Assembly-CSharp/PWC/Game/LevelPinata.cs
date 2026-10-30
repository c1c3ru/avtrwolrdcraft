namespace PWC.Game;

public class LevelPinata : MonoBehaviour, IHasPersistentData, IRequirePDSceneObject, ILevelSpawnDuringGameplay
{
	private const int MAX_HIT_POINTS = 5; //Field offset: 0x0
	[SerializeField]
	private LevelPinataArea _pinataArea; //Field offset: 0x20
	[SerializeField]
	private GameObject _aroundPinataArea; //Field offset: 0x28
	[SerializeField]
	private PDPrefabReference[] _gifts; //Field offset: 0x30
	[SerializeField]
	private PDPrefabReference _giftWrapper; //Field offset: 0x38
	[SerializeField]
	private PDPrefabReference[] _candies; //Field offset: 0x40
	[SerializeField]
	private Vector2 _numberOfCandiesRange; //Field offset: 0x48
	[SerializeField]
	private LevelDropArea _dropArea; //Field offset: 0x50
	[SerializeField]
	private int _interval; //Field offset: 0x58
	[SerializeField]
	private string _hitSoundName; //Field offset: 0x60
	[SerializeField]
	private bool _shouldAutoSpawn; //Field offset: 0x68
	[SerializeField]
	private SkeletonAnimation _skeletonAnimation; //Field offset: 0x70
	[SerializeField]
	[SpineAnimation(null, "_skeletonAnimation", True, False, False)]
	private String[] _hitAnimations; //Field offset: 0x78
	[SerializeField]
	[SpineAnimation(null, "_skeletonAnimation", True, False, False)]
	private String[] _idleAnimations; //Field offset: 0x80
	[SerializeField]
	[SpineAnimation(null, "_skeletonAnimation", True, False, False)]
	private string _fallAnimation; //Field offset: 0x88
	[SerializeField]
	[Space]
	private UnityEvent _onPinataDestroyedEvent; //Field offset: 0x90
	private int _hits; //Field offset: 0x98
	private bool _canHit; //Field offset: 0x9C
	private int _lastGiftIndex; //Field offset: 0xA0
	private DateTime _lastTimeGiftTaken; //Field offset: 0xA8
	private bool _didTimePass; //Field offset: 0xB0

	public LevelPinata() { }

	[CompilerGenerated]
	private void <OnHit>b__27_0() { }

	private void Awake() { }

	private void CalculateIsEnoughTimePassed() { }

	private void EnableHit(TrackEntry trackEntry) { }

	private void Fall() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	private void OnDestroy() { }

	private void OnHit() { }

	private void OnLevelPostInit() { }

	private void OnReadyPostLoad() { }

	private override void PWC.Level.ILevelSpawnDuringGameplay.OnSpawnDuringGameplay() { }

	private void RestartPinata() { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	private void SpawnCandies() { }

	private void SpawnGift() { }

}

