namespace PWC.Level;

public class LevelUpgradeTrackerGuidsFilter : MonoBehaviour
{
	[SerializeField]
	private bool _isSavingItemsInABox; //Field offset: 0x20
	[SerializeField]
	private List<String> _guids; //Field offset: 0x28
	[SerializeField]
	private List<String> _prefabGuids; //Field offset: 0x30
	[SerializeField]
	private TextAsset[] _configFiles; //Field offset: 0x38
	[SerializeField]
	private Vector3 _boxPosition; //Field offset: 0x40

	public LevelUpgradeTrackerGuidsFilter() { }

	private void Awake() { }

	private void FillDisposableSkinsOnLevelReset(HashSet<String> skinNames) { }

	private void LevelUpgradeTracker_FillDisposableOnLevelResetPrefabGuidsAction(HashSet<String> prefabGuids) { }

	private void LevelUpgradeTracker_FillDisposableOnLevelResetSceneGuidsAction(HashSet<String> sceneGuids) { }

	private Vector3 LevelUpgradeTracker_OverrideBoxPosition() { }

	private bool LevelUpgradeTracker_OverrideKeepItems() { }

	private void OnDestroy() { }

}

