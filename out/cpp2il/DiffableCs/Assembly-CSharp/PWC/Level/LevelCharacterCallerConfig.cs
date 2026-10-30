namespace PWC.Level;

[CreateAssetMenu(menuName = "PazuWorld/Level/Character Caller Config")]
public class LevelCharacterCallerConfig : ScriptableObject
{
	public int id; //Field offset: 0x18
	public bool shouldCallOnlyIfOutOfCameraView; //Field offset: 0x1C
	public string animationNameOnInCameraView; //Field offset: 0x20
	public string animationOnArrivalName; //Field offset: 0x28
	public bool animationOnArrivalLoop; //Field offset: 0x30
	public bool shouldholdItemInRightHand; //Field offset: 0x31
	public bool isCharacterFlipped; //Field offset: 0x32
	public Vector2 itemInHandPivot; //Field offset: 0x34
	public PDPrefabReference plateToUsePrefab; //Field offset: 0x40
	public PDPrefabReference[] prefabsToHoldInHand; //Field offset: 0x48

	public LevelCharacterCallerConfig() { }

}

