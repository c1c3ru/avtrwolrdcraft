namespace PWC.World;

public class WorldCloud : MonoBehaviour
{
	private const float MIN_MOVE_DISTANCE = 0,01; //Field offset: 0x0
	[FormerlySerializedAs("_spriteRenderer")]
	[SerializeField]
	private SpriteRenderer _clearSpriteRenderer; //Field offset: 0x20
	[SerializeField]
	private SpriteRenderer _rainSpriteRenderer; //Field offset: 0x28
	private Transform _endPoint; //Field offset: 0x30
	private IWorldCloudSpawner _spawner; //Field offset: 0x38
	private int _rainTweenId; //Field offset: 0x40
	private int _localYTweenId; //Field offset: 0x44
	private bool _hasInit; //Field offset: 0x48

	public WorldCloud() { }

	[CompilerGenerated]
	private void <Init>b__10_0() { }

	[CompilerGenerated]
	private void <InitParented>b__11_0() { }

	[CompilerGenerated]
	private void <OnWeatherChange>b__16_0(float t) { }

	[CompilerGenerated]
	private void <OnWeatherChange>b__16_1() { }

	[CompilerGenerated]
	private void <OnWeatherChange>b__16_2(float t) { }

	[CompilerGenerated]
	private void <OnWeatherChange>b__16_3() { }

	private void Awake() { }

	private void ConfigureVisuals(Sprite clearSprite, Sprite rainSprite, int sortingOrder) { }

	private static float GetSafeTargetX(float targetX, float startX) { }

	public void Init(Sprite clearSprite, Sprite rainSprite, int sortingOrder, Transform endPoint, IWorldCloudSpawner spawner, Nullable<Single> speed = null) { }

	public void InitParented(Sprite clearSprite, Sprite rainSprite, int sortingOrder, Transform endPoint, IWorldCloudSpawner spawner, float speed) { }

	private void OnDestroy() { }

	private void OnWeatherChange(WeatherType weatherType) { }

	public void SetLocalY(float y) { }

	public void TweenLocalY(float targetY, float duration) { }

}

