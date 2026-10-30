namespace PWC.AvatarMaker;

public class AvatarMakerCarThumbsConfig : AvatarMakerThumbsConfigBase
{
	private const int BREED_COLUMNS = 1; //Field offset: 0x0
	private const string PREMADE_ONLY_PACK_SUFFIX = "_P0"; //Field offset: 0x0
	private const string SEAT_CENTER_PIECE = "Center"; //Field offset: 0x0
	private const string SEAT_CENTER_PIECE_PREFIX = "Center_"; //Field offset: 0x0
	private const string PACK_SUFFIX_PATTERN = "_P\d+$"; //Field offset: 0x0
	[SerializeField]
	private Sprite _breedThumbSprite; //Field offset: 0x20
	[SerializeField]
	private Sprite _breedFrameSprite; //Field offset: 0x28
	[SerializeField]
	private List<CarThumbOrder> _thumbOrders; //Field offset: 0x30
	[SerializeField]
	private Vector2 _fallbackThumbMaxSize; //Field offset: 0x38
	private readonly Dictionary<ValueTuple`2<Int32, String>, Sprite> _fallbackThumbs; //Field offset: 0x40

	public AvatarMakerCarThumbsConfig() { }

	private Sprite CreateFallbackThumb(int categoryType, string skinName) { }

	public virtual string GetBreedFromThumbName(string thumbName) { }

	public virtual void GetGridParams(int categoryType, out int padding, out float spacing, out int constraintCount, out ThumbType thumbType) { }

	public virtual void GetSkinNamesWithoutThumbs(int categoryType, List<String> skinNames) { }

	public virtual void HandlePremadeThumbs(bool includePremades, int categoryType, ref List<Sprite>& itemSprites) { }

	public virtual bool IsPackOnlyPart(string skinName) { }

	private static bool IsPremadeOnlyPart(string spriteName) { }

	public virtual bool TryFilterThumb(int categoryType, Sprite sprite) { }

	private bool TryFindThumbOrder(CarCategoryType categoryType, InventoryFlagType flagType, out List<String>& skinNames) { }

	public virtual bool TryGetChildAlignment(int categoryType, out TextAnchor childAlignment) { }

	public virtual bool TryGetFallbackThumb(int categoryType, string skinName, out Sprite sprite) { }

	public virtual bool TryGetThumbOrder(int categoryType, InventoryFlagType flagType, out List<String>& skinNames) { }

	public virtual bool TryGetThumbSprites(int categoryType, out Sprite thumbSprite, out Sprite frameSprite) { }

	private static bool TryReadSeatSkinName(string centerPiecePrefix, List<String> skinNames, int index) { }

}

