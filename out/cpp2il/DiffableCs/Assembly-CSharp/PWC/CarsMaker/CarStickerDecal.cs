namespace PWC.CarsMaker;

public class CarStickerDecal : MonoBehaviour
{
	private struct ResolvedSticker
	{
		public CarCategoryType Category; //Field offset: 0x0
		public Sprite Sticker; //Field offset: 0x8
		public Vector2 AreaMin; //Field offset: 0x10
		public Vector2 AreaSize; //Field offset: 0x18
		public HashSet<SpriteRenderer> ExcludedTargets; //Field offset: 0x20

	}

	private static readonly int STICKER_TEX_ID; //Field offset: 0x0
	private static readonly int STICKER_SCALE_OFFSET_ID; //Field offset: 0x4
	private static readonly int STICKER_CLAMP_U_ID; //Field offset: 0x8
	private static readonly int STICKER_SKEW_ID; //Field offset: 0xC
	private static readonly Vector4 OUTSIDE_STICKER_SCALE_OFFSET; //Field offset: 0x10
	private static readonly Vector2 NO_STICKER_CLAMP; //Field offset: 0x20
	private static readonly Vector2 UNUSED_STICKER_SPAN; //Field offset: 0x28
	[SerializeField]
	private List<SpriteRenderer> _targets; //Field offset: 0x20
	[SerializeField]
	private List<CarStickerMapping> _borrowedMappings; //Field offset: 0x28
	[SerializeField]
	private List<CarStickerSlotExclusion> _slotExclusions; //Field offset: 0x30
	[SerializeField]
	private CarFullStickerCoverage _fullStickerCoverage; //Field offset: 0x38
	private MaterialPropertyBlock _propertyBlock; //Field offset: 0x40
	private CarView _carView; //Field offset: 0x48
	private readonly Dictionary<CarCategoryType, Sprite> _stickersByCategory; //Field offset: 0x50
	private readonly List<ResolvedSticker> _resolvedStickers; //Field offset: 0x58
	private readonly List<HashSet`1<SpriteRenderer>> _excludedTargetPool; //Field offset: 0x60

	public CarFullStickerCoverage FullStickerCoverage
	{
		 get { } //Length: 8
	}

	private static CarStickerDecal() { }

	public CarStickerDecal() { }

	private static void ApplyBorrowedOffsets(SpriteRenderer target, CarStickerMapping mapping, ref Vector4 scaleOffset, ref Vector2 clampU, ref float skew) { }

	public void ClearSticker(CarCategoryType category) { }

	private HashSet<SpriteRenderer> CollectExcludedTargets(CarCategoryType slot, int slotIndex) { }

	public CarFullStickerCoverage get_FullStickerCoverage() { }

	private Vector4 GetPlacementScaleOffset(SpriteRenderer target, Vector2 areaMin, Vector2 areaSize) { }

	private Vector4 GetStickerScaleOffset(SpriteRenderer target, SpriteRenderer mapFrom, Vector2 areaMin, Vector2 areaSize) { }

	private static Vector2 GetStickerSpanAcross(SpriteRenderer target, Vector4 scaleOffset) { }

	private static Vector2 GetStickerSpanUp(SpriteRenderer target, Vector4 scaleOffset) { }

	private static bool IsInsideSticker(SpriteRenderer target, Vector4 scaleOffset) { }

	private void OnDisable() { }

	private void OnEnable() { }

	private static bool Overlaps01(Vector2 span) { }

	private Vector4 RebaseOntoTarget(Vector4 scaleOffset, SpriteRenderer mapFrom, SpriteRenderer target) { }

	private void Repaint() { }

	private void ResolveStickers() { }

	public void SetSticker(CarCategoryType category, Sprite sticker) { }

	private void TakeStickersOffTheParts() { }

	private bool TryGetAreaInCarSpace(CarCategoryType category, Sprite sticker, out Vector2 areaMin, out Vector2 areaSize) { }

	private bool TryGetAreaTransform(CarCategoryType category, out Transform areaTransform) { }

	private bool TryGetBorrowedMapping(SpriteRenderer target, out CarStickerMapping borrowedMapping) { }

	private bool TryGetStickerForTarget(SpriteRenderer target, SpriteRenderer mapFrom, out ResolvedSticker resolved, out Vector4 scaleOffset) { }

	private void WriteChannelsToParts() { }

}

