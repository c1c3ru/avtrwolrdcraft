namespace Game.Level;

public class LevelPreventHoldingItemsOnDropAreaHandler : MonoBehaviour, ILevelSpawnDuringGameplay
{
	[SerializeField]
	private LevelDropArea _dropArea; //Field offset: 0x20
	[SerializeField]
	private bool _preventAllTypesOfItemsHolding; //Field offset: 0x28
	[SerializeField]
	private bool _preventAvatarsHolding; //Field offset: 0x29
	[SerializeField]
	[Tooltip("ignored if _preventAvatarsHolding = false")]
	private List<SpineType> spineTypesToAllowHolding; //Field offset: 0x30
	[SerializeField]
	[Tooltip("Prefabs explicitly allowed to be held in this drop area. Overrides the prevention flags above.")]
	private List<PDPrefabReference> _allowedItemsToHold; //Field offset: 0x38
	[SerializeField]
	[Tooltip("Prefabs explicitly prevented from being held here. Takes priority over the allowed list and the flags above.")]
	private List<PDPrefabReference> _disallowedItemsToHold; //Field offset: 0x40

	public LevelPreventHoldingItemsOnDropAreaHandler() { }

	private void AllowHolding(ILevelAvatar avatar) { }

	private void Awake() { }

	private void EnsureOnReadyPostLoad() { }

	private void FreeDisallowedHeldItems(LevelCharacter character) { }

	private void FreeDisallowedHeldItems(LevelToddler toddler) { }

	private bool IsInPrefabList(List<PDPrefabReference> prefabList, string itemGuid) { }

	public bool IsPreventingHolding(LevelItem levelItem) { }

	private void OnDestroy() { }

	private void OnItemEndDrop(LevelItem item) { }

	private void OnItemPickUp(LevelItem item) { }

	private void OnLevelPostInit() { }

	public override void OnSpawnDuringGameplay() { }

	private void PreventHolding(ILevelAvatar avatar) { }

}

