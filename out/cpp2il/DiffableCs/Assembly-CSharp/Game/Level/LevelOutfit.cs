namespace Game.Level;

[CreateAssetMenu(menuName = "PazuWorld/Level/Outfit")]
public class LevelOutfit : ConditionResolverAsset
{
	public String[] solvingSkins; //Field offset: 0x20
	public List<Int32> avatarIDs; //Field offset: 0x28
	public SecretFullId secretFullId; //Field offset: 0x30

	public LevelOutfit() { }

}

