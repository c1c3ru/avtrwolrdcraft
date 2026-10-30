namespace PWC.AvatarMaker;

[CreateAssetMenu(fileName = "AvatarMakerColorsList", menuName = "AvatarMaker/Avatar Maker Colors List")]
public class AWSpineColorsList : ScriptableObject
{
	public List<AWSpineColorModel> AvatarMakerColors; //Field offset: 0x18

	public AWSpineColorsList() { }

}

