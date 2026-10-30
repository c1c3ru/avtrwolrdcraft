namespace PWC.CarsMaker;

public class CarSkinsManager : AvatarSpineSkinsManagerBase, IHasBreed
{
	private const string DEFAULT_WINDOW_TINT_SKIN_NAME = "Window_Tint/Window_Tint_01_Color"; //Field offset: 0x0
	private const string DEFAULT_SEAT_SKIN_NAME = "Seat/Seat_01_Color"; //Field offset: 0x0
	private const string DEFAULT_HUB_CAPS_SKIN_NAME = "Hub_Caps/Hub_Caps_01"; //Field offset: 0x0
	private const string COLORABLE_MARKER = "_Color"; //Field offset: 0x0
	private const string PACK_SUFFIX_PATTERN = "_P\d+$"; //Field offset: 0x0
	[SerializeField]
	private Transform _carParent; //Field offset: 0xB8
	private CarView _carView; //Field offset: 0xC0
	private GameObject _carVisualInstance; //Field offset: 0xC8
	[CompilerGenerated]
	private string <Breed>k__BackingField; //Field offset: 0xD0

	public override string Breed
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 8
	}

	public Transform CarParent
	{
		 get { } //Length: 8
	}

	public CarView CarView
	{
		 get { } //Length: 8
	}

	public CarSkinsManager() { }

	public virtual bool AddSkin(int categoryType, string skinName, Action<String> onSkinRemoveAction = null, bool isRecursiveCall = false) { }

	private void ApplyBreed(string breed) { }

	private void ApplyBreedDefaultColors() { }

	private void ApplyBreedDefaultSkins(Dictionary<Int32, String> defaultSkinNames) { }

	private void ApplySkinDefaultColors(int categoryType, string skinName) { }

	private void ApplySlot(CarCategoryType carCategoryType, string skinName) { }

	public void ClearCar() { }

	public virtual void ColorSkin(int categoryType, Color[] colors) { }

	private void EnsureBreed() { }

	private void EnsureCarView() { }

	private void EnsureColorsEntry(int categoryType) { }

	[CompilerGenerated]
	public override string get_Breed() { }

	public Transform get_CarParent() { }

	public CarView get_CarView() { }

	protected virtual SpineType GetDefaultSpineType() { }

	private CarFullStickerCoverage GetFullStickerCoverage() { }

	protected virtual void GetMaterialConfig(string skinName, int categoryType, bool isColorable, out AvatarSpineColoringConfig coloringConfig) { }

	protected virtual int GetParentCategory(int categoryType) { }

	protected virtual int GetParentColorCategoryType(int categoryType) { }

	public virtual HashSet<Int32> GetRequiredCategoryTypes() { }

	public virtual float GetSizeScaleFactor() { }

	protected virtual bool GetSkinsDataColorTest(int categoryType) { }

	protected virtual int GetSUTSystemCategoryKey(int categoryType) { }

	protected override string GetUsableBreed(string breed) { }

	protected virtual Dictionary<Int32, String> InitDefaultSkinNamesByCategoryType() { }

	public virtual bool IsColorable(int categoryType) { }

	private void LoadBreedVisual() { }

	private static string NormalizeDefaultSkinName(CarCategoryType categoryType, string skinName, Dictionary<Int32, String> defaultSkinNames) { }

	protected virtual void PostRemoveSkinInternal(int categoryType, Action<String> onRemoveAction) { }

	protected virtual void PreRemoveSkinInternal(int categoryType, Action<String> onRemoveAction) { }

	private void ReapplyAllSlots() { }

	private void RemoveConflictingSkins(CarCategoryType carCategoryType) { }

	public virtual bool RemoveSkin(int categoryType, bool initiateChainEvent, Action<String> onRemoveAction = null) { }

	protected virtual void RemoveSkinChainEvent(int categoryType) { }

	protected virtual void RemoveSkinInternal(int categoryType, string skinName) { }

	private void RemoveSkinsTheNewBreedCannotWearTogether() { }

	[CompilerGenerated]
	public override void set_Breed(string value) { }

	protected virtual bool ShouldUseSUTSystem(int categoryType) { }

	protected virtual bool TryAddEyesSkinInternal(int categoryType, string skinName, AvatarSpineColoringConfig coloringConfig, Color[] colors, string previousEyesSkinName) { }

	protected virtual bool TryColorSkinInternal(int categoryType, string skinName, Color[] colors) { }

	protected virtual bool TryGetAvatarSpineData(out AvatarSpineData data) { }

	public static bool TryGetCurrentCarView(out CarView carView) { }

	protected virtual bool TryGetSkinInternal(int categoryType, string skinName, out Skin skin) { }

	protected override bool TryLoadCarSpineData(out AvatarSpineData data) { }

	protected virtual bool TrySUTColorSkinInternal(int categoryType, string skinName, Action<Material> initMaterial, List<Skin> addedSkins, List<Material> addedMaterials, Color[] colors) { }

}

