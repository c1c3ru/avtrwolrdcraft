namespace PWC.LevelPhone.DeliveryApp;

[CreateAssetMenu(fileName = "DeliveryBusinessData", menuName = "AvatarWorld/LevelPhone/DeliveryBusinessData")]
public class DeliveryBusinessData : ScriptableObject
{
	public bool isComingSoon; //Field offset: 0x18
	public Sprite logo; //Field offset: 0x20
	public Sprite banner; //Field offset: 0x28
	public PDPrefabReference boxPDPrefabReference; //Field offset: 0x30
	public Sprite[] thumbBackgrounds; //Field offset: 0x38
	public Sprite[] categoryIcons; //Field offset: 0x40
	public ProductData[] productsData; //Field offset: 0x48

	public DeliveryBusinessData() { }

}

