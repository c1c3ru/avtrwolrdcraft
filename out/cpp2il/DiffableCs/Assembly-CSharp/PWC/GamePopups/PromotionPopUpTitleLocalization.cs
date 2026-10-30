namespace PWC.GamePopups;

[CreateAssetMenu(fileName = "PromotionPopUpTitleLocalization", menuName = "Avatar World/Promotion PopUp Title Localization")]
public class PromotionPopUpTitleLocalization : ScriptableObject
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass5_0
	{
		public string packName; //Field offset: 0x10

		public <>c__DisplayClass5_0() { }

		internal bool <GetLocalizationKey>b__0(PromotionTitleEntry e) { }

	}

	internal class PromotionTitleEntry
	{
		public string packName; //Field offset: 0x10
		public string localizationKey; //Field offset: 0x18

		public PromotionTitleEntry() { }

	}

	private const string PROMOTION_POPUP_ASSETS_FOLDER_PATH = "Assets/Game/General/Resources/GamePopups/Sprites/Promotions"; //Field offset: 0x0
	private const string STORE_PACK_ITEMS_FOLDER_PATH = "Assets/Game/Store/Resources/Store/PackItems"; //Field offset: 0x0
	private const string STORE_PACK_ITEM_PREFIX = "StorePackItem_"; //Field offset: 0x0
	[SerializeField]
	private List<PromotionTitleEntry> _promotionTitles; //Field offset: 0x18

	public PromotionPopUpTitleLocalization() { }

	public string GetLocalizationKey(string packName) { }

}

