namespace StarsPass;

public class StarsAnimationManager : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass23_0
	{
		public StarsAnimationManager <>4__this; //Field offset: 0x10
		public StarsPassBarManager barManager; //Field offset: 0x18

		public <>c__DisplayClass23_0() { }

		internal void <MoveStarsToStarsPassBar>b__0() { }

	}

	public static StarsAnimationManager Instance; //Field offset: 0x0
	[SerializeField]
	private Canvas _canvas; //Field offset: 0x20
	[SerializeField]
	private RectTransform _coinsRectTransform; //Field offset: 0x28
	[SerializeField]
	private GameObject _starPrefab; //Field offset: 0x30
	[SerializeField]
	private GameObject _floatingTextGO; //Field offset: 0x38
	[SerializeField]
	private RectTransform _goToRectTransform; //Field offset: 0x40
	[FormerlySerializedAs("_dinamicStarsBarRectTransform")]
	[SerializeField]
	private RectTransform _dynamicStarsBarRectTransform; //Field offset: 0x48
	[SerializeField]
	private Transform _spawnedStarsParent; //Field offset: 0x50
	[FormerlySerializedAs("_dinamicStarsBarManager")]
	[SerializeField]
	private StarsPassBarManager _dynamicStarsBarManager; //Field offset: 0x58
	[SerializeField]
	private StarsPassBarManager _staticStarsBarManager; //Field offset: 0x60
	[Header("Star Spawn Settings")]
	[SerializeField]
	private float _spawnRadius; //Field offset: 0x68
	[SerializeField]
	private float _minSpawnDistance; //Field offset: 0x6C
	[SerializeField]
	private int _maxVisualStars; //Field offset: 0x70
	private readonly List<GameObject> _spawnedStars; //Field offset: 0x78
	private readonly List<GameObject> _starPool; //Field offset: 0x80
	private Coroutine _spawnStarsCoroutine; //Field offset: 0x88
	private Coroutine _moveStarsCoroutine; //Field offset: 0x90

	public StarsAnimationManager() { }

	public void AbortStarsAnimation() { }

	private GameObject AcquireStar(Vector3 position) { }

	private void Awake() { }

	private int CalculateVisualStarCount(int starsAmount) { }

	public bool IsUsingStatic() { }

	public void MoveStarsToStarsPassBar() { }

	private void OnDestroy() { }

	public void PlayStarsAnim(int starsAmount, bool showDefaultNumberOfStars = true, Action onComplete = null) { }

	private void ReleaseSpawnedStars() { }

	private void ReleaseStar(GameObject star) { }

	public void SpawnStars(Vector3 startPosition, int starsAmount, bool isRelativeToStars = false, bool showDefaultNumberOfStars = true, Action onComplete = null) { }

	private void Start() { }

	public void SyncBarsToCurrentTotal() { }

}

