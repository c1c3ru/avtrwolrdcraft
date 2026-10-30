namespace PWC.Inventory;

[CreateAssetMenu(menuName = "PazuWorld/Level/MKR/Tile Pack Data")]
public class MKRTilePackData : ScriptableObject
{
	public InventoryFlagType inventoryFlagType; //Field offset: 0x18
	public bool isWallTilePack; //Field offset: 0x1C
	public bool isFloorTilePack; //Field offset: 0x1D
	public bool isFloorMTilePack; //Field offset: 0x1E

	public MKRTilePackData() { }

}

