namespace PWC.CarsMaker;

public class CarView : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass72_0
	{
		public CarCategoryType category; //Field offset: 0x10
		public CarCategoryType parent; //Field offset: 0x14

		public <>c__DisplayClass72_0() { }

		internal bool <FindCategoryFocus>b__0(CarCategoryFocus x) { }

		internal bool <FindCategoryFocus>b__1(CarCategoryFocus x) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass77_0
	{
		public CarLayer layer; //Field offset: 0x10
		public CarView <>4__this; //Field offset: 0x18

		public <>c__DisplayClass77_0() { }

		internal bool <InitCollectionIfNeeded>b__0(SpriteRenderer renderer) { }

		internal bool <InitCollectionIfNeeded>b__1(CarLayer x) { }

	}

	private enum CarPaintPath
	{
		PWSprite = 0,
		PaintColor = 1,
		WindowTint = 2,
	}

	private const string SEAT_PRINT_BOTTOM = "Bot"; //Field offset: 0x0
	private const string SEAT_PRINT_TOP = "Top"; //Field offset: 0x0
	private static readonly String[] SEAT_PRINT_PLACES; //Field offset: 0x0
	private const string SEAT_NAME_PREFIX = "Seat_"; //Field offset: 0x0
	private const string PACK_SUFFIX_PATTERN = "_P\d+$"; //Field offset: 0x0
	private static readonly int PW_COLOR_ID; //Field offset: 0x8
	private static readonly int PAINT_COLOR_ID; //Field offset: 0xC
	private static readonly Color NEUTRAL_OVERLAY_COLOR; //Field offset: 0x10
	private static readonly int CLIP_MIN_ID; //Field offset: 0x20
	private static readonly int TILE_TEX_ID; //Field offset: 0x24
	private static readonly int TILING_X_ID; //Field offset: 0x28
	private static readonly int TILING_Y_ID; //Field offset: 0x2C
	private static readonly int TILE_STRENGTH_ID; //Field offset: 0x30
	private static readonly List<LevelDoor> EMPTY_DOORS; //Field offset: 0x38
	[SerializeField]
	private List<CarLayer> _layers; //Field offset: 0x20
	[SerializeField]
	private List<LevelDoor> _doors; //Field offset: 0x28
	[SerializeField]
	private float _makerScale; //Field offset: 0x30
	[SerializeField]
	private float _levelScale; //Field offset: 0x34
	[SerializeField]
	private float _thumbScale; //Field offset: 0x38
	[SerializeField]
	private bool _isBigVehicle; //Field offset: 0x3C
	[SerializeField]
	private float _lobbyCarScale; //Field offset: 0x40
	[SerializeField]
	private float _lobbyExtraSlotWidth; //Field offset: 0x44
	[SerializeField]
	private float _lobbyShadowScale; //Field offset: 0x48
	[SerializeField]
	private Transform _scaleParent; //Field offset: 0x50
	[SerializeField]
	private List<CarDefaultColors> _defaultColors; //Field offset: 0x58
	[SerializeField]
	private List<CarDefaultSkin> _defaultSkins; //Field offset: 0x60
	[SerializeField]
	private List<CarSpinePart> _spineParts; //Field offset: 0x68
	[SerializeField]
	private List<CarCategoryFocus> _categoryFocuses; //Field offset: 0x70
	private Dictionary<CarCategoryType, List`1<CarLayer>> _layersByCategory; //Field offset: 0x78
	private MaterialPropertyBlock _propertyBlock; //Field offset: 0x80
	private readonly Dictionary<SpriteRenderer, Sprite> _defaultSprites; //Field offset: 0x88

	public IReadOnlyList<LevelDoor> Doors
	{
		 get { } //Length: 100
	}

	public bool IsBigVehicle
	{
		 get { } //Length: 8
	}

	public float LevelScale
	{
		 get { } //Length: 20
	}

	public float LobbyCarScale
	{
		 get { } //Length: 20
	}

	public float LobbyExtraSlotWidth
	{
		 get { } //Length: 16
	}

	public float LobbyShadowScale
	{
		 get { } //Length: 20
	}

	public float MakerScale
	{
		 get { } //Length: 20
	}

	public Transform ScaleParent
	{
		 get { } //Length: 8
	}

	public float ThumbScale
	{
		 get { } //Length: 20
	}

	private static CarView() { }

	public CarView() { }

	public void ApplyLevelScale() { }

	public void ApplyMakerScale() { }

	private void ApplyScale(float scale) { }

	public void ClearColors(CarCategoryType category) { }

	public void ClearPart(CarCategoryType category) { }

	public void ClearTile(CarCategoryType category) { }

	private static bool DoesLayerTakeAColor(CarLayer layer) { }

	private CarCategoryFocus FindCategoryFocus(CarCategoryType category) { }

	public IReadOnlyList<LevelDoor> get_Doors() { }

	public bool get_IsBigVehicle() { }

	public float get_LevelScale() { }

	public float get_LobbyCarScale() { }

	public float get_LobbyExtraSlotWidth() { }

	public float get_LobbyShadowScale() { }

	public float get_MakerScale() { }

	public Transform get_ScaleParent() { }

	public float get_ThumbScale() { }

	public int GetColorGroupsCount(CarCategoryType category) { }

	public List<CarCategoryType> GetDefaultColorCategories() { }

	private static CarPaintPath GetPaintPath(Material sharedMaterial) { }

	public static string GetPartSkinName(string skinName, string partSuffix) { }

	private static string GetSeatPartName(string seatSkinName, string partSuffix) { }

	public bool HasSlot(CarCategoryType category) { }

	private void InitCollectionIfNeeded() { }

	private void NumberColorGroups() { }

	private void NumberSpineParts(CarCategoryType category, Dictionary<String, Int32> colorIndexByGroup) { }

	private void RestoreDefaultArt(CarLayer layer) { }

	public void SetColor(CarCategoryType category, Color color) { }

	public void SetColors(CarCategoryType category, Color[] colors) { }

	private void SetLayerColor(CarCategoryType category, CarLayer layer, Color color) { }

	private void SetLayersColors(CarCategoryType category, List<CarLayer> layers, Color[] colors) { }

	private void SetLayerSprite(CarLayer layer, Sprite sprite) { }

	public void SetPart(CarCategoryType category, string skinName, Func<String, Boolean, Sprite> resolveSprite) { }

	private void SetRendererColor(SpriteRenderer renderer, int propertyId, Color color) { }

	private void SetSpinePartColor(CarSpinePart spinePart, Color color, PWSpriteColorType colorType) { }

	private void SetSpinePartsColors(CarCategoryType category, Color[] colors) { }

	public void SetTile(CarCategoryType category, Texture2D tile) { }

	private bool TryGetCategoryCenter(CarCategoryType category, out Vector3 center) { }

	public bool TryGetCategoryFocus(CarCategoryType category, float defaultZoomRatio, out Vector3 worldPoint, out float zoomRatio) { }

	public bool TryGetDefaultColors(CarCategoryType category, out Color[] colors) { }

	public bool TryGetDefaultSkin(CarCategoryType category, out string skinName) { }

	public bool TryGetLayers(CarCategoryType category, out List<CarLayer>& layers) { }

}

