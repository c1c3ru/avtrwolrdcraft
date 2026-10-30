namespace PWC.AvatarMaker;

public abstract class AvatarMakerColorsConfigBase : MonoBehaviour
{

	protected AvatarMakerColorsConfigBase() { }

	public abstract SerializableDictionaryBase<Int32, AWSpineColorsList> GetColorLists() { }

	public override bool IsPremiumColor(AWSpineColorModel colorModel) { }

	public override bool TryGetColorList(int categoryType, InventoryFlagType flagType, out AWSpineColorsList colorsList) { }

	public override bool TryGetPackColorFlags(int categoryType, out List<InventoryFlagType>& flagTypes) { }

}

