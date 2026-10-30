namespace PWC.AvatarMaker;

public class AvatarMakerCarColorsConfig : AvatarMakerColorsConfigBase
{
	[SerializeField]
	private SerializableDictionaryBase<CarCategoryType, AWSpineColorsList> _colorsByCategoryType; //Field offset: 0x20
	[SerializeField]
	private List<CarPackColors> _packColors; //Field offset: 0x28
	private readonly HashSet<AWSpineColorModel> _premiumColorModels; //Field offset: 0x30

	public AvatarMakerCarColorsConfig() { }

	private void AddOwnedPackColors(SerializableDictionaryBase<Int32, AWSpineColorsList> colorsByCategoryType) { }

	public virtual SerializableDictionaryBase<Int32, AWSpineColorsList> GetColorLists() { }

	private void InsertColors(SerializableDictionaryBase<Int32, AWSpineColorsList> colorsByCategoryType, int categoryType, AWSpineColorsList packColors, Dictionary<Int32, Int32> insertIndexByCategoryType) { }

	public virtual bool IsPremiumColor(AWSpineColorModel colorModel) { }

	public virtual bool TryGetColorList(int categoryType, InventoryFlagType flagType, out AWSpineColorsList colorsList) { }

	public virtual bool TryGetPackColorFlags(int categoryType, out List<InventoryFlagType>& flagTypes) { }

}

