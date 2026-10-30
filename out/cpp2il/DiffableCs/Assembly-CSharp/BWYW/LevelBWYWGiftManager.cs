namespace BWYW;

public class LevelBWYWGiftManager : MonoBehaviour
{
	public static string GiftGuid; //Field offset: 0x0
	public static int GiftId; //Field offset: 0x8
	public static SkillType SkillType; //Field offset: 0xC
	public static string giftPrefabGuid; //Field offset: 0x10
	[SerializeField]
	private LevelDropArea _dropArea; //Field offset: 0x20
	[SerializeField]
	private PDPrefabReference _dronePrefabGuid; //Field offset: 0x28
	[SerializeField]
	private PDPrefabReference _starterKitPrefabGuid; //Field offset: 0x30

	private static LevelBWYWGiftManager() { }

	public LevelBWYWGiftManager() { }

	private void Awake() { }

	private void EnsureNoGiftsInAir() { }

	private void OnDestroy() { }

	private void OnLevelPostInit() { }

	private void SpawnDrone(LevelItem levelItem) { }

	private void SpawnGift() { }

	private void SpawnStarterKit() { }

}

