namespace Game.Level;

public class LevelChangeBackgroundByZoneView : MonoBehaviour
{
	private const string RESOURCES_DIRECTORY_PATH = "Level/ChangeableBackgrounds/ZoneViews/"; //Field offset: 0x0
	private static string _cachedForSceneName; //Field offset: 0x0
	private static LevelWorldType _cachedZoneView; //Field offset: 0x8
	[SerializeField]
	private SpriteRenderer _backgroundSpriteRenderer; //Field offset: 0x20
	[SerializeField]
	private Sprite _fallbackSprite; //Field offset: 0x28
	[SerializeField]
	private string _spriteNameSuffix; //Field offset: 0x30

	public LevelChangeBackgroundByZoneView() { }

	public void ApplyBackgroundForCurrentZoneView() { }

	private void Awake() { }

	private static LevelWorldType GetCurrentZoneView() { }

	private Sprite GetSpriteForZoneView(LevelWorldType zoneView) { }

	private string GetSpritePath(LevelWorldType zoneView) { }

	private void OnDestroy() { }

	private void OnLevelPostInit() { }

	private static bool TryParseZoneView(string sceneName, out LevelWorldType zoneView) { }

}

